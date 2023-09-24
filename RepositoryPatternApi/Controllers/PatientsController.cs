using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryPatternApi.Models;
using RepositoryPatternApi.Repositories.Implementations;
using RepositoryPatternApi.Repositories.Interfaces;

namespace RepositoryPatternApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : Controller
    {
        private IPatient _patientrepo;
        public PatientsController(IPatient ptnt)
        {
             _patientrepo = ptnt;
        }

        [HttpGet]
        [Route("Index")]
        public IActionResult Index()
        {
            var a = _patientrepo.GetAllPatients();
            if(a == null)
            {
                return NotFound();
            }
            return Ok(a);
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult GetById(int id)
        {
            Patient p = _patientrepo.GetPatientById(id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }

        [HttpPost]
        [Route("Creates")]
        public IActionResult Creates(Patient pt)
        {
            int rs = _patientrepo.CreatePatient(pt);
            if(rs <= 0)
            {
                return BadRequest("Failed");
            }
            else
            return Ok("Added! " + rs);
        }

        [HttpPut]
        [Route("Edit")]
        public IActionResult Edit(Patient pt)
        {
            int rs = _patientrepo.UpdatePatient(pt);
            if (rs <= 0)
            {
                return BadRequest("Failed");
            }
            else
                return Ok("Updated! " + rs);
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            int rs = _patientrepo.DeletePatient(id);
            if (rs <= 0)
            {
                return BadRequest("Failed");
            }
            else
                return Ok("Deleted! " + rs);
        }
    }
}
