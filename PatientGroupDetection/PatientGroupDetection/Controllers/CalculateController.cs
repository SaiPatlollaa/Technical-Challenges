using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PatientGroupDetection.Application.Entities;
using PatientGroupDetection.Application.Repository;

namespace PatientGroupDetection.Controllers
{
    [ApiController]
    [Route("api/patient-groups/[controller]")]
    public class CalculateController : ControllerBase
    {
        [HttpPost]
        public async Task<int> GetPatientGroupCount(PersonMatrix personMatrix)
        {
            try
            {
                var patientRepository = new PatientRepository();
                var count = patientRepository.GetPatientGroupCount(personMatrix.Matrix);
                return count;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return 0;
            
        }
    }
}
