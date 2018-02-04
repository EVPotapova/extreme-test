using System;
using System.Collections.Generic;
using System.Text;

namespace Extreme_Test.Models
{
    public class Query
    {
        public List<int> State { get; set; }
        public List<int> geo_id { get; set; }
        public string headers_facets { get; set; }
        public string period { get; set; }
        public string search_type { get; set; }
    }

    public class HeadersFacet
    {
        public string header { get; set; }
        public int count { get; set; }
    }

    public class Deprecation
    {
        public string code { get; set; }
        public string field { get; set; }
        public string message { get; set; }
    }

    public class Resultset
    {
        public int count { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
    }

    public class Metadata
    {
        public Query query { get; set; }
        public List<HeadersFacet> headers_facets { get; set; }
        public List<Deprecation> deprecations { get; set; }
        public Resultset resultset { get; set; }
    }

    public class Currency
    {
        public int id { get; set; }
        public string title { get; set; }
        public string alias { get; set; }
    }

    public class Education
    {
        public int id { get; set; }
        public string title { get; set; }
        public object alias { get; set; }
    }

    public class ExperienceLength
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class WorkingType
    {
        public int id { get; set; }
        public string title { get; set; }
        public object alias { get; set; }
    }

    public class Schedule
    {
        public int id { get; set; }
        public string title { get; set; }
        public object alias { get; set; }
    }

    public class Publication
    {
        public int id { get; set; }
        public int geo_id { get; set; }
        public int? order_id { get; set; }
        public int vacancy_id { get; set; }
        public int company_id { get; set; }
        public string type { get; set; }
        public string action { get; set; }
        public bool is_active { get; set; }
        public bool is_free { get; set; }
        public bool logo_in_list { get; set; }
        public bool is_service_finished { get; set; }
        public int live_time { get; set; }
        public DateTime expired_at { get; set; }
        public DateTime published_at { get; set; }
        public DateTime created_at { get; set; }
        public bool is_dummy { get; set; }
        public bool is_deleted { get; set; }
        public object prolong_data { get; set; }
    }

    public class City
    {
        public int id { get; set; }
        public string title { get; set; }
        public string locative { get; set; }
    }

    public class Coordinate
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class District
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class Microdistrict
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class Line
    {
        public int id { get; set; }
        public string title { get; set; }
        public object color { get; set; }
    }

    public class Subway
    {
        public int id { get; set; }
        public string title { get; set; }
        public Line line { get; set; }
    }

    public class Contact
    {
        public int icq { get; set; }
        public string skype { get; set; }
        public object email { get; set; }
        public string url { get; set; }
        public string street { get; set; }
        public string building { get; set; }
        public object room { get; set; }
        public string name { get; set; }
        public object firstname { get; set; }
        public object lastname { get; set; }
        public object patronymic { get; set; }
        public List<object> phones { get; set; }
        public City city { get; set; }
        public string address_description { get; set; }
        public Coordinate coordinate { get; set; }
        public District district { get; set; }
        public Microdistrict microdistrict { get; set; }
        public Subway subway { get; set; }
        public string address { get; set; }
    }

    public class City2
    {
        public int id { get; set; }
        public string title { get; set; }
        public string locative { get; set; }
    }

    public class Coordinate2
    {
        public double lat { get; set; }
        public double lon { get; set; }
    }

    public class Address
    {
        public int id { get; set; }
        public int company_id { get; set; }
        public int city_id { get; set; }
        public City2 city { get; set; }
        public string street { get; set; }
        public string building { get; set; }
        public string description { get; set; }
        public Coordinate2 coordinate { get; set; }
    }

    public class PaymentType
    {
        public int id { get; set; }
        public string title { get; set; }
        public string alias { get; set; }
    }

    public class Logo
    {
        public string id { get; set; }
        public string url { get; set; }
        public object size { get; set; }
    }

    public class Employees
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class Rubric
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class Reviews
    {
        public int average { get; set; }
        public int count { get; set; }
    }

    public class Company
    {
        public int id { get; set; }
        public string title { get; set; }
        public Logo logo { get; set; }
        public List<object> interviews { get; set; }
        public List<object> onedays { get; set; }
        public List<object> photos { get; set; }
        public bool show_logo { get; set; }
        public int state { get; set; }
        public int validate_state { get; set; }
        public Employees employees { get; set; }
        public int parent_id { get; set; }
        public List<Rubric> rubrics { get; set; }
        public Reviews reviews { get; set; }
        public bool expert_recruitment { get; set; }
    }

    public class Photo
    {
        public string url { get; set; }
        public string id { get; set; }
    }

    public class Owner
    {
        public int id { get; set; }
        public string type { get; set; }
        public Photo photo { get; set; }
    }

    public class Speciality
    {
        public int id { get; set; }
        public string title { get; set; }
    }

    public class Rubric2
    {
        public int id { get; set; }
        public string title { get; set; }
        public List<Speciality> specialities { get; set; }
    }

    public class Vacancy
    {
        public int id { get; set; }
        public DateTime add_date { get; set; }
        public object archive_date { get; set; }
        public int owner_id { get; set; }
        public string header { get; set; }
        public int state { get; set; }
        public int validate_state { get; set; }
        public string visibility_type { get; set; }
        public bool removal { get; set; }
        public int site_id { get; set; }
        public int bonus { get; set; }
        public int salary_min { get; set; }
        public int salary_max { get; set; }
        public Currency currency { get; set; }
        public Education education { get; set; }
        public ExperienceLength experience_length { get; set; }
        public WorkingType working_type { get; set; }
        public Schedule schedule { get; set; }
        public bool logo_in_list { get; set; }
        public Publication publication { get; set; }
        public string user_type { get; set; }
        public string description { get; set; }
        public Contact contact { get; set; }
        public Address address { get; set; }
        public string payment_type_alias { get; set; }
        public PaymentType payment_type { get; set; }
        public Company company { get; set; }
        public DateTime mod_date { get; set; }
        public int views { get; set; }
        public bool is_anonymous { get; set; }
        public Owner owner { get; set; }
        public bool is_moderated { get; set; }
        public object imported_via { get; set; }
        public List<object> subways { get; set; }
        public List<object> tags { get; set; }
        public List<object> institutions { get; set; }
        public List<object> jobs { get; set; }
        public bool show_email { get; set; }
        public bool show_phone { get; set; }
        public bool use_messages { get; set; }
        public bool is_commerce { get; set; }
        public bool is_upped { get; set; }
        public bool is_premium { get; set; }
        public List<object> toponyms { get; set; }
        public bool is_overlimit { get; set; }
        public object log_state_update { get; set; }
        public bool favorite { get; set; }
        public bool hided { get; set; }
        public string url { get; set; }
        public int salary_min_rub { get; set; }
        public int salary_max_rub { get; set; }
        public List<Rubric2> rubrics { get; set; }
        public string requirements_short { get; set; }
        public string requirements { get; set; }
        public int priority { get; set; }
        public string salary { get; set; }
        public string salary_formatted { get; set; }
        public bool Can_accept_replies { get; set; }
        public bool Has_cpa { get; set; }
    }

    public class ApiResponse
    {
        public Metadata Metadata { get; set; }
        public List<Vacancy> Vacancies { get; set; }
    }
}
