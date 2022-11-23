using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business.Abstract;
using Entities.Concrete;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassesController : ControllerBase
    {
        private IClassesService _classesService;

        public ClassesController(IClassesService classesService)
        {
            _classesService = classesService;
        }


        [HttpGet("GetAllClasses")]
        public IActionResult GetList()
        {
            var result = _classesService.getList();
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("AddClasses")]
        public IActionResult AddCustomer(ClassDto classDto)
        {
            var result = _classesService.Add(classDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("DeleteClass")]
        public IActionResult DeleteCustomer(ClassDto classDto)
        {
            var result = _classesService.Update(classDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("UpdateClasses")]
        public IActionResult UpdateCustomer(ClassDto classDto)
        {
            var result = _classesService.Update(classDto);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }


        [HttpGet("GetClassById")]
        public IActionResult GetListByCustomerId(int ClassId)
        {
            var result = _classesService.GetById(ClassId);
            if (result.Success)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

    }
}
