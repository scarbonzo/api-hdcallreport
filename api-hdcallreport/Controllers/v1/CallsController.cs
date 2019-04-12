using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

[ApiController]
[Produces("application/json")]
[Route("api/v1/[controller]")]
public class CallsController : ControllerBase
{
    private readonly CallAnalyzerContext _context;

    public CallsController(CallAnalyzerContext context)
    {
        _context = context;
    }

    public ActionResult GetCalls(int Year, int Month)
    {
        var query = _context.Calls.AsQueryable();

        var allcalls = query
            .Where(c => c.OriginalCalledPartyNumber == "\"8300\"")
            .Where(c => c.Year == Year)
            .Where(c => c.Month == Month)
            .ToList();

        var summary = new Summary
        {
            Year = Year,
            Month = Month,
            LSNJ = allcalls.Count(c => c.CallingPartyNumber.Length == 6 && c.CallingPartyNumber.Substring(1, 1) == "8"),
            NNJLS = allcalls.Count(c => c.CallingPartyNumber.Length == 6 && c.CallingPartyNumber.Substring(1, 1) == "3"),
            SJLS = allcalls.Count(c => c.CallingPartyNumber.Length == 6 && c.CallingPartyNumber.Substring(1, 1) == "6"),
            CJLS = allcalls.Count(c => c.CallingPartyNumber.Length == 6 && c.CallingPartyNumber.Substring(1, 1) == "2"),
            ENLS = allcalls.Count(c => c.CallingPartyNumber.Length == 6 && c.CallingPartyNumber.Substring(1, 1) == "4"),
            LSNWJ = allcalls.Count(c => c.CallingPartyNumber.Length == 6 && c.CallingPartyNumber.Substring(1, 1) == "5"),
            External = allcalls.Count(c => c.CallingPartyNumber.Length > 6)
        };

        summary.Calculate();

        return Ok(summary);
    }
}