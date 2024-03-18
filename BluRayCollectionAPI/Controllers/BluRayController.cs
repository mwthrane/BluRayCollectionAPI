using Microsoft.AspNetCore.Mvc;
using BluRayCollectionAPI.Models;
using BluRayCollectionAPI.Services;
using System.Collections.Generic;

namespace BluRayCollectionAPI.Controllers;
[ApiController]
[Route("api/[controller]")]

    public class BluRayController : ControllerBase
    {
        private readonly BluRayService _bluRayService;

    public BluRayController(BluRayService bluRayService)
    {
            _bluRayService = bluRayService;
        }

    [HttpGet]
    public async Task<ActionResult<List<Blurays>>> Get() =>
        await _bluRayService.GetBluraysAsync();
    
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Blurays>> Get(string id)
    {
            var bluray = await _bluRayService.GetBlurayAsync(id);
            if (bluray == null)
        {
                return NotFound();
            }
            return bluray;
        }

    [HttpPost]
        public async Task<ActionResult<Blurays>> Create(Blurays bluray)
    {
            await _bluRayService.CreateAsync(bluray);
            return CreatedAtRoute("GetBluray", new { id = bluray.Id.ToString() }, bluray);
        }

    [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Blurays blurayIn)
    {
            var bluray = _bluRayService.GetBlurayAsync(id);
            if (bluray == null)
        {
                return NotFound();
            }
            await _bluRayService.UpdateAsync(id, blurayIn);
            return NoContent();
        }

    [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
    {
            var bluray = _bluRayService.GetBlurayAsync(id);
            if (bluray == null)
        {
                return NotFound();
            }
            await _bluRayService.RemoveAsync(id);
            return NoContent();
        }
    }