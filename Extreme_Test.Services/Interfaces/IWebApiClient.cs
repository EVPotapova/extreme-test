using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Extreme_Test.Services.Interfaces
{
    public interface IWebApiClient
    {
        Task<T> GetAsync<T>(string url);
    }
}
