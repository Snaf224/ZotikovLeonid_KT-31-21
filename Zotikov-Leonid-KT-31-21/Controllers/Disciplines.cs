using Zotikov_Leonid_KT_31_21.Filters.StudentFilters;
using Zotikov_Leonid_KT_31_21.Interfaces.StudentsInterfaces;
using Zotikov_Leonid_KT_31_21.Models;
using Microsoft.AspNetCore.Mvc;

namespace Zotikov_Leonid_KT_31_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DisciplinesController : Controller
    {
        private readonly ILogger<DisciplinesController> _logger;
        private readonly IDisciplineService _disciplineService;

        public DisciplinesController(ILogger<DisciplinesController> logger, IDisciplineService disciplineService)
        {
            _logger = logger;
            _disciplineService = disciplineService;
        }

        [HttpPost("AddDiscipline")]
        public async Task<IActionResult> AddDisciplineAsync(int studentId, string disciplineName, CancellationToken cancellationToken = default)
        {
            try
            {
                await _disciplineService.AddDisciplineAsync(studentId, disciplineName, cancellationToken);
                return Ok("Дисциплина успешно добавлена.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Ошибка при добавлении дисциплины: {ex.Message}");
            }
        }

        //[HttpPut("UpdateDiscipline/{disciplineId}")]
        //public async Task<IActionResult> UpdateDisciplineAsync(int disciplineId, string newDisciplineName, CancellationToken cancellationToken = default)
        //{
        //    try
        //    {
        //        await _disciplineService.UpdateDisciplineAsync(disciplineId, newDisciplineName, cancellationToken);
        //        return Ok("Дисциплина успешно обновлена.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Ошибка при обновлении дисциплины: {ex.Message}");
        //    }
        //}

        //[HttpDelete("DeleteDiscipline/{disciplineId}")]
        //public async Task<IActionResult> DeleteDisciplineAsync(int disciplineId, CancellationToken cancellationToken = default)
        //{
        //    try
        //    {
        //        await _disciplineService.DeleteDisciplineAsync(disciplineId, cancellationToken);
        //        return Ok("Дисциплина успешно удалена.");
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest($"Ошибка при удалении дисциплины: {ex.Message}");
        //    }
        //}
    }
}
