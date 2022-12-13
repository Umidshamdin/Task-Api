using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Dtos.Employee;
using ServiceLayer.Services.Interfaces;

namespace API.Controllers
{
    public class EmployeeController:BaseController
    {
        private readonly IEmployeeService _service;
        private readonly ILoggerService _logger;

        public EmployeeController(IEmployeeService service, ILoggerService logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInfo("Employee Get All method running");
            return Ok(await _service.GetAllAsync());
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create([FromBody] EmployeeCreateDto employeeCreateDto)
        {
            _logger.LogInfo("Employee Create method running");
            await _service.InsertAsync(employeeCreateDto);
            return Ok();
        }


        [HttpPut]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit([FromRoute] int id, [FromBody] EmployeeUpdateDto employeeUpdateDto)
        {
            _logger.LogInfo("Employee Edit method running");
            await _service.UpdateAsync(id, employeeUpdateDto);
            return Ok();
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            _logger.LogInfo("Employee Softdelete was true");
            await _service.DeleteAsync(id);
            return Ok();
        }

        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            _logger.LogInfo("Employee GetById method running");
            var result = await _service.GetAsync(id);
            return Ok(result);
        }

        [HttpGet]
        [Route("GetByName/{txt}")]
        public async Task<IActionResult> GetByName([FromRoute] string txt)
        {
            _logger.LogInfo("Employee GetByName method running");
            return Ok(await _service.GetByNameAsync(txt));
        }
    }
}
