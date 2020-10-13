using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIHandson_1_3_.Models;

namespace WebAPIHandson_1_3_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult Get()
        {
            var list = new List<Emp>();
            GenerateEmpList(list);
            return Ok(list);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public IActionResult Get(int id)
        {
            var list = new List<Emp>();
            GenerateEmpList(list);
            var emp = list.Find(e => e.Id == id);
            if (emp == null)
                return NotFound();
            return Ok(emp);
        }

        private static void GenerateEmpList(List<Emp> list)
        {
            list.Add(new Emp()
            {
                Id = 1,
                Name = "L Abhishek Divecha",
                DateOfBirth = new DateTime(1999, 6, 10),
                Department = new Dept() { DeptName = "CSE" },
                Permanent = true,
                Salary = 100000,
                Skills = new List<Skill>() { new Skill() { SkillName = "SQL" }, new Skill() { SkillName = "JAVA" } }
            });
            list.Add(new Emp()
            {
                Id = 2,
                Name = "Kushagra Dash",
                DateOfBirth = new DateTime(1998, 7, 24),
                Department = new Dept() { DeptName = "ECE" },
                Permanent = false,
                Salary = 100000,
                Skills = new List<Skill>() { new Skill() { SkillName = "DOTNET" }, new Skill() { SkillName = "C#" } }
            });
        }
    }
}
