using Microsoft.AspNetCore.Mvc;
using POInterview.Application.Contracts;
using POInterview.Application.Models;

namespace POInterview.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BookingsController : ControllerBase
{
    private readonly IBookingService _bookingService;

    public BookingsController(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [HttpPost(Name = "BookResource")]
    public async Task<IActionResult> BookResourceAsync(BookingDto booking)
    {
        await _bookingService.BookResourceAsync(booking);
        return Created();
    }
}
