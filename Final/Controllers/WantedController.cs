using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Final.Data;
using Final.Model;
using Microsoft.EntityFrameworkCore;

namespace InterpolFbiAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class WantedController : ControllerBase
{
    private readonly FinalContext _context;

    private readonly ILogger<WantedController> _logger;


    public WantedController(ILogger<WantedController> logger, FinalContext ctx)
    {
        _logger = logger;
        _context = ctx;
    }

    [HttpGet(Name = "GetWanted")]
    public async Task<IActionResult> Get()
    {
        var item = _context.InterpolFbi.FirstOrDefault();
        return Ok(item);
    }

}
