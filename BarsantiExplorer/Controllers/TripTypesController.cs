using BarsantiExplorer.Models;
using BarsantiExplorer.Models.Entities;
using BarsantiExplorer.Models.Requests.TripTypes;
using BarsantiExplorer.Models.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Dynamic.Core;

namespace BarsantiExplorer.Controllers;

[ApiController]
[Route("api/trip-types")]
public class TripTypesController : BaseController
{
    public TripTypesController(BarsantiDbContext context, IConfiguration appSettings) : base(context, appSettings)
    {
    }

    /// <summary>
    ///  Get filtered trip-types
    /// </summary>
    /// <response code="200">Returns filtered trip-types</response>
    [HttpGet("")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(List<TripType>), StatusCodes.Status200OK)]
    public IActionResult GetTripTypes([FromQuery] GetTripTypesRequest queryParams)
    {
        var tripTypes = DB.TripTypes.Where(el => el.DeletedAt == null);

        if (queryParams.Search != null)
        {
            tripTypes = tripTypes.Where(el =>
                el.Name.Contains(queryParams.Search));
        }

        if (queryParams.Sort != null)
        {
            tripTypes = tripTypes.OrderBy(queryParams.Sort);
        }

        return Ok(tripTypes);
    }

    /// <summary>
    /// Get a trip-type
    /// </summary>
    /// <response code="200">Returns the trip-type data</response>
    /// <response code="404">If the trip-type was not found</response>
    [HttpGet("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(TripTypeResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetTripType(int id)
    {
        var tripType = DB.TripTypes
            .Where(el => el.DeletedAt == null)
            .FirstOrDefault(el => el.Id == id);

        if (tripType == null)
        {
            return NotFound();
        }

        return Ok(tripType);
    }
    ///<summary
    ///+Create a new trip-type
    /// </summary>
    /// <response code="200">Returns the new trip-type data</response> 
    [Authorize]
    [HttpPost("")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(TripTypeResponse), StatusCodes.Status200OK)]
    public IActionResult CreateTripType([FromForm] CreateTripTypesRequest request)
    {
        var tripType = new TripType
        {
            Name = request.Name
        };
        DB.TripTypes.Add(tripType);
        DB.SaveChanges();
        return Ok(tripType);
    }
    /// <summary>
    /// Delete a trip type
    /// </summary>
    /// <response code="200">Returns true if the trip type was deleted successfully</response>
    [Authorize]
    [HttpDelete("{id}")]
    [Produces("application/json")]
    [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
    public IActionResult DeleteTripType(int id)
    {
        var tripType = DB.TripTypes
            .Where(el => el.DeletedAt == null)
            .FirstOrDefault(el => el.Id == id);

        if (tripType == null)
        {
            return NotFound();
        }

        tripType.DeletedAt = DateTime.Now;
        DB.SaveChanges();
        return Ok(true);
    }
}