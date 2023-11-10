using Microsoft.AspNetCore.Mvc;
using SqlAgentDashboard.Models;
using SqlAgentDashboard.Services;

namespace ActiveDirectoryWebApp.Controllers
{
    /// <summary>
    /// User controller 
    /// </summary>
    public class JobController : Controller
    {

        private readonly JobService _jobService;

        public JobController(JobService jobService)
        {
            _jobService = jobService;
        }

        public IActionResult Index()
        {
            var jobs = _jobService.GetJobs();
            return View(jobs);
        }


        /// <summary>
        /// Get job  information
        /// </summary>
        /// <returns>Job view model</returns>
        public async Task<IActionResult> GetJobsInfo()
        {
            try
            { 
                 var jobs =  await _jobService.GetJobs();

                if (jobs != null)
                {
                    return View(jobs);

                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = HttpContext.TraceIdentifier,
                    Message = ex.Message,
                };
                return View("Error", errorViewModel); // StatusCode(500, ex.Message); // Handle exceptions
            }
        }

        [HttpPost]
        public async Task<IActionResult> ExecuteJob(string jobName)
        {
            try
            {
                var status = await _jobService.ExecuteJob(jobName);

                if (status != 1)
                {
                    return RedirectToAction("GetJobsInfo"); 

                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                var errorViewModel = new ErrorViewModel
                {
                    RequestId = HttpContext.TraceIdentifier,
                    Message = ex.Message,
                };
                return View("Error", errorViewModel); // StatusCode(500, ex.Message); // Handle exceptions
            }
            
        }
    }
}
        

     
       
    


