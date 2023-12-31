﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P7_OC_Poseidon.Models;
using P7_OC_Poseidon.Models.Dtos;
using P7_OC_Poseidon.Models.Services.CurvePointService;

namespace P7_OC_Poseidon.Controllers
{
    [ApiController, Authorize]
    [Route("api/[controller]")]
    public class CurvePointsController : ControllerBase
    {
        private readonly ICurvePointService _curvePointService;

        public CurvePointsController(ICurvePointService curvePointService)
        {
            _curvePointService = curvePointService;
        }

        // GET: api/CurvePoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CurvePoint>>> GetAllCurvePoints()
        {
            var result = await _curvePointService.GetAllCurvePoints();
            if (result == null)
                return NotFound("CurvePoints not found");

            return Ok(result);
        }

        // GET: api/CurvePoints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CurvePoint>> GetCurvePoint(int id)
        {
            var result = await _curvePointService.GetSingleCurvePoint(id);
            if (result == null)
                return NotFound("CurvePoint not found");

            return Ok(result);
        }

        // PUT: api/CurvePoints/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurvePoint(int id, CurvePointDto curvePointDto)
        {
            var result = await _curvePointService.UpdateCurvePoint(id, curvePointDto);
            if (result == null)
                return NotFound("CurvePoint not found");

            return Ok(result);
        }

        // POST: api/CurvePoints
        [HttpPost]
        public async Task<ActionResult<CurvePoint>> PostCurvePoint(CurvePointDto curvePointDto)
        {
            var result = await _curvePointService.AddCurvePoint(curvePointDto);
            if (result == null)
                return NotFound("CurvePoint not found");

            return Ok(result);
        }

        // DELETE: api/CurvePoints/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurvePoint(int id)
        {
            var result = await _curvePointService.DeleteCurvePoint(id);
            if (result == null)
                return NotFound("CurvePoint not found");

            return Ok(result);
        }
    }
}
