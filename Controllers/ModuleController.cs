using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VarsityManagementAPI.Data;
using VarsityManagementAPI.DTOs;
using VarsityManagementAPI.Interfaces;
using VarsityManagementAPI.Models;

namespace VarsityManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModule _module;
        private readonly IMapper _mapper;

        public ModuleController(IModule module, IMapper mapper)
        {
            _mapper = mapper;
            _module = module;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public IActionResult GetModules()
        {
            var modules = _mapper.Map<List<ModuleDTO>>(_module.GetModules()); ;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(modules);
        }

        [HttpGet("{moduleId}")]
        [ProducesResponseType(200, Type = typeof(Module))]
        [ProducesResponseType(400)]
        public IActionResult GetModule(int moduleId)
        {
            if (!_module.ModuleExists(moduleId))
            {
                return NotFound();
            }

            var module = _mapper.Map<ModuleDTO>(_module.GetModule(moduleId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(module);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        public IActionResult CreateModule([FromBody] ModuleDTO createModule)
        {
            if (createModule == null)
            {
                return BadRequest(ModelState);
            }

            var module = _module.GetModules().Where(c => c.ModuleName.Trim()
                            .ToUpper() == createModule.ModuleName
                                .TrimEnd().ToUpper()).FirstOrDefault();
            if (module != null)
            {
                ModelState.AddModelError("", "The module already exists!");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var moduleMap = _mapper.Map<Module>(createModule);

            if (!_module.CreateModule(moduleMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Success");
        }

        [HttpPut("{moduleId}")]
        [ProducesResponseType(204)]
        public IActionResult UpdateModule(int moduleId, [FromBody] ModuleDTO updateModule)
        {
            if (updateModule == null)
            {
                return BadRequest(ModelState);
            }

            if (moduleId != updateModule.ModuleId)
            {
                return BadRequest(ModelState);
            }

            if (!_module.ModuleExists(moduleId))
            {
                return BadRequest(new { Error = "Module not found" });
            }

            var moduleMap = _mapper.Map<Module>(updateModule);

            if (!_module.UpdateModule(moduleMap))
            {
                ModelState.AddModelError("", "Something went wrong while saving.");
                return StatusCode(500, ModelState);
            }
            return NoContent();
        }
    }
}
