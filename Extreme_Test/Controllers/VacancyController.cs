using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Extreme_Test.Models;
using Extreme_Test.Services.Interfaces;
using Extreme_Test.Models.Filters;

namespace Extreme_Test.Controllers
{
    [Produces("application/json")]
    [Route("api/Vacancy")]
    public class VacancyController : Controller
    {
        public readonly IVacancyService VacancyService;

        public VacancyController(IVacancyService vacancyService)
        {
            VacancyService = vacancyService;
        }

        // GET: api/Vacancy
        [HttpGet]
        public async Task<IActionResult> GetListAsync(VacancyFilter filter, ListOptions listOptions)//TODO: From Uri
        {
            try
            {
                await RefreshVacanciesAsync();
                var response = await VacancyService.GetListOfVacanciesAsync(filter, listOptions);
                

                return Ok(response);
            }
            catch (WrongSortPropertyException)
            {
                return BadRequest();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }


        }

        [HttpPost("refresh")]
        public async Task<IActionResult> RefreshVacanciesAsync()
        {
            try
            {
                await VacancyService.SaveNewVacanciesAsync("https://api.zp.ru/v1/vacancies?geo_id=994");//TODO: config
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }


        }

        // GET: api/Vacancy/5
        [HttpGet("{e1Id}")]
        public async Task<IActionResult> GetAsync(int e1Id)
        {
            try
            {
                var res = await VacancyService.GetVacancyAsync(e1Id);

                if (res == null)
                    return NotFound($"Vacancy with Id {e1Id} is not found!");
                else
                    return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

    }
}
