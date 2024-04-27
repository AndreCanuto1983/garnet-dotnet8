using Microsoft.AspNetCore.Mvc;
using Poc.Garnet.Dotnet8.Interface;

namespace Poc.Garnet.Dotnet8.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GarnetController(IPocGarnetRepository pocGarnetRepository) : ControllerBase
    {
        private readonly IPocGarnetRepository _pocGarnetRepository = pocGarnetRepository;

        /// <summary>
        /// Insert data into garnet
        /// </summary>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="201">Object created successfully</response>        
        /// <response code="400">Note the sent parameters, something may be wrong</response>
        /// <response code="401">Access not allowed</response>
        /// <response code="500">Service error</response>
        /// <response code="502">If something goes wrong in the internally called service, this return is displayed</response>
        [HttpPost]
        public async Task<IActionResult> InsertDataInGarnet(string key, string data, CancellationToken cancellationToken)
        {
            await _pocGarnetRepository.InsertAsync(key, data, cancellationToken);
            return Created();
        }

        /// <summary>
        /// Search data in garnet
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cancellationToken"></param>
        /// <response code="200">Success</response>        
        /// <response code="400">Note the sent parameters, something may be wrong</response>
        /// <response code="401">Access not allowed</response>
        /// <response code="500">Service error</response>
        /// <response code="502">If something goes wrong in the internally called service, this return is displayed</response>
        [HttpGet("{key}")]
        public async Task<IActionResult> Search(string key, CancellationToken cancellationToken)
        {
            return Ok(await _pocGarnetRepository.GetAsync(key, cancellationToken));
        }

        /// <summary>
        /// Delete data in garnet
        /// </summary>
        /// <param name="key"></param>
        /// <param name="cancellationToken"></param>        
        /// <response code="200">Success</response>        
        /// <response code="400">Note the sent parameters, something may be wrong</response>
        /// <response code="401">Access not allowed</response>
        /// <response code="500">Service error</response>
        /// <response code="502">If something goes wrong in the internally called service, this return is displayed</response>
        [HttpDelete("{Key}")]
        public async Task<IActionResult> Delete(string key, CancellationToken cancellationToken)
        {
            await _pocGarnetRepository.DeleteAsync(key, cancellationToken);
            return Ok();
        }
    }
}