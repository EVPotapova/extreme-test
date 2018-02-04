using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Extreme_Test.Models

{
    public static class IQueryableExtensions
    {
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string ordering, bool desc = false)
        {
            return DynamicOrder(source, ordering, desc ? "OrderByDescending" : "OrderBy");
        }

        public static IOrderedQueryable<T> OrderByDescending<T>(this IQueryable<T> source, string ordering)
        {
            return OrderBy(source, ordering, true);
        }

        public static IOrderedQueryable<T> ThenBy<T>(this IQueryable<T> source, string ordering, bool desc = false)
        {
            return DynamicOrder(source, ordering, desc ? "ThenByDescending" : "ThenBy");
        }

        public static IOrderedQueryable<T> ThenByDescending<T>(this IOrderedQueryable<T> source, string ordering)
        {
            return ThenBy(source, ordering, true);
        }

        private static IOrderedQueryable<T> DynamicOrder<T>(IQueryable<T> source, string ordering, string method)
        {
            var type = typeof(T);
            var property = type.GetProperty(ordering, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);

            if (property == null)
            {
                throw new MissingMemberException(type.Name, ordering);
            }

            var parameter = Expression.Parameter(type, "p");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            MethodCallExpression resultExp = Expression.Call(typeof(Queryable),
                method,
                new Type[] { type, property.PropertyType },
                source.Expression, Expression.Quote(orderByExp));
            return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(resultExp);
        }
    }

    public class ListOptions
    {
        public ListOptions() : this(PageSizeValue.Default) { }
        public ListOptions(int pageSize) : this((PageSizeValue)pageSize) { }
        public ListOptions(PageSizeValue pageSize) { PageSize = pageSize; }


        public PageSizeValue PageSize { get; set; }

        public int Page { get; set; }

        /// <summary>
        /// Sorting fields.
        /// Formats:
        ///     1. Sort ascending: "propName" / "+propName"
        ///     2. Sort descending: "-propName"
        ///     3. Multiple: "prop1Name, -prop2Name"
        /// </summary>
        public string Sort { get; set; }

        public IEnumerable<SortDesc> GetSorts()
        {
            if (!string.IsNullOrWhiteSpace(Sort))
            {
                foreach (string str in Sort.Split(new[] { ',', ' ', ';' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var sd = SortDesc.Parse(str);
                    yield return sd;
                }
            }
        }

        public IQueryable<T> ApplySort<T>(IQueryable<T> query, string defaultSort = null)
        {
            var sortDescEnumumerator = GetSorts().GetEnumerator();

            if (sortDescEnumumerator.MoveNext())
            {
                try
                {
                    IOrderedQueryable<T> orderedQuery = query.OrderBy(sortDescEnumumerator.Current.PropertyName, sortDescEnumumerator.Current.Desc);

                    while (sortDescEnumumerator.MoveNext())
                    {
                        orderedQuery = orderedQuery.ThenBy(sortDescEnumumerator.Current.PropertyName, sortDescEnumumerator.Current.Desc);
                    }

                    return orderedQuery;
                }
                catch (MissingMemberException exc)
                {
                    throw new WrongSortPropertyException(sortDescEnumumerator.Current.PropertyName, exc);
                }
            }

            if (defaultSort != null)
            {
                var ds = SortDesc.Parse(defaultSort);
                IOrderedQueryable<T> orderedQuery = query.OrderBy(ds.PropertyName, ds.Desc);
                return orderedQuery;
            }

            return query;
        }

        //TODO: EntityFrCore error with FETCH check it later
        public IQueryable<T> ApplyPaging<T>(IQueryable<T> query)
        {
            int? pageSize = PageSize.AsInt32();

            if (pageSize == null)
            {
                return query;
            }

            int skip = pageSize.Value * (Page - 1);

            if (skip > 0)
            {
                query = query.Skip(skip);
            }

            query = query.Take(pageSize.Value);
            return query;
        }

        public int CalculatePagesCount(int itemsCount)
        {
            if (itemsCount == 0 || PageSize == PageSizeValue.NoLimit)
            {
                return 1;
            }

            var pageSize = PageSize.AsInt32().Value;
            var pagesCount = itemsCount / pageSize + (itemsCount % pageSize == 0 ? 0 : 1);

            return pagesCount;
        }
    }

    public class SortDesc
    {
        public string PropertyName { get; set; }

        public bool Desc { get; set; }

        public static SortDesc Parse(string str)
        {
            var sd = new SortDesc { PropertyName = str };

            if (str[0] == '+' || str[0] == '-')
            {
                sd.Desc = str[0] == '-';
                sd.PropertyName = str.Substring(1);
            }

            return sd;
        }
    }

    /// <summary>
    /// Predefined values for ListOptions.Count
    /// Allows integer values.
    /// </summary>
    public enum PageSizeValue
    {
        NoLimit = -0xAAAA,
        First = 1,
        Default = 10
    }

    /// <summary>
    /// Extensions for enum Zerobased.CountValue
    /// </summary>
    public static class CountValueExtensions
    {
        /// <summary>
        /// Convert Zerobased.CountValue to System.Int32 value.
        /// </summary>
        /// <param name="topValue">Value to convert.</param>
        /// <returns>
        /// Returns <value>Defaul</value> if value less then <value>1</value>.
        /// Returns <value>NULL</value> if <paramref name="topValue"/> is <value>NoLimit</value>.
        /// </returns>
        public static int? AsInt32(this PageSizeValue topValue)
        {
            int? value = null;

            if (topValue != PageSizeValue.NoLimit)
            {
                value = (int)(topValue < PageSizeValue.First ? PageSizeValue.Default : topValue);
            }

            return value;
        }
    }

    public class WrongSortPropertyException : ApplicationException
    {
        public WrongSortPropertyException(string sortProperty, Exception innerException = null)
            : base($"Property {sortProperty} does not exists in sorted entity.", innerException)
        {
            SortProperty = sortProperty;
        }

        public string SortProperty { get; }
    }
}