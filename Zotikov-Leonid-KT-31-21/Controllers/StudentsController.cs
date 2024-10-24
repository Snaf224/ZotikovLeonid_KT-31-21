using Zotikov_Leonid_KT_31_21.Filters.StudentFilters;
using Zotikov_Leonid_KT_31_21.Interfaces.StudentsInterfaces;
using Zotikov_Leonid_KT_31_21.Models;
using Microsoft.AspNetCore.Mvc;

namespace Zotikov_Leonid_KT_31_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentService _studentService;

        public StudentsController(ILogger<StudentsController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpPost(Name = "GetStudentsByGroup")]
        public async Task<IActionResult> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByGroupAsync(filter, cancellationToken);

            return Ok(students);
        }

        //[HttpPost("GetStudentsByFio")]
        //public async Task<IActionResult> GetStudentsByFioAsync(StudentFioFilter filter, CancellationToken cancellationToken = default)
        //{
        //    var fio = await _studentService.GetStudentsByFioAsync(filter, cancellationToken);

        //    return Ok(fio);
        //}

        //[HttpPost(Name = "GetStudentsByIsDeleted")]
        //public async Task<IActionResult> GetStudentsByIsDeletedAsync(DeletionStatusFilter filter, CancellationToken cancellationToken = default)
        //{
        //    var fio = await _studentService.GetStudentsByFioAsync(filter, cancellationToken);

        //    return Ok(fio);
        //}
    }
}
