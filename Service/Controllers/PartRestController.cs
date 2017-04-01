using System.Net.Http;
using System.Web.Http;
using System.Net;
using System.Linq;
using System;
using System.Collections.Generic;
using Service.Models;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Service.Controllers
{
    public class PartRestController : ApiController
    {
        private readonly Persistence.ApplicationDbContext _context;

        public PartRestController(Persistence.ApplicationDbContext context)
        {
            _context = context;
        }

        public PartRestController() { _context = new Persistence.ApplicationDbContext(); }

        // Options: api/Part
        [Route("api/PartRest")]
        [HttpOptions()]
        public HttpResponseMessage Options()
        {
            var resp = new HttpResponseMessage(HttpStatusCode.OK);
            //resp.Headers.Add("Allow", "OPTIONS, GET, HEAD, POST, PUT, DELETE");
            //resp.Headers.Add("Access-Control-Allow-Origin", "*");
            //resp.Headers.Add("Access-Control-Allow-Methods", "GET,DELETE,PUT,POST");

            return resp;
        }

        // GET: api/Part
        [Route("api/PartRest")]
        [HttpGet]
        [ResponseType(typeof(Persistence.Part))]
        public IEnumerable<Persistence.Part> Get()
        {
            return _context.Parts.Include("PartCustomField").Include("PartCustomField.CustomField");
        }

        // GET: api/Part?id=0d686151-7e36-4fed-bdc4-11df2c2d22e4
        // or
        // GET: api/Part/0d686151-7e36-4fed-bdc4-11df2c2d22e4
        [Route("api/PartRest")]
        [Route("api/PartRest/{id}")]
        [HttpGet()]
        [ResponseType(typeof(Persistence.Part))]
        public async Task<IHttpActionResult> Get([FromUri] Guid? id)
        {
            if (!ModelState.IsValid | id == null | id == Guid.Empty)
            {
                Models.Shared.APIError apiError = new Models.Shared.APIError
                {
                    status = 400,
                    code = 400001,
                    message = $"The ID is not valid or empty",
                    developerMessage = "The parameters dictionary contains a null entry for parameter 'id' of non-nullable type 'System.Guid' for method Get(System.Guid)",
                    moreinfo = "Https://example.com/doc/error/400001",
                    requestId = Guid.NewGuid().ToString()
                };

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, apiError));
            }

            var part = await _context.Parts.FirstOrDefaultAsync(m => m.ID == id);

            if (part == null)
            {
                Models.Shared.APIError apiError = new Models.Shared.APIError
                {
                    status = 404,
                    code = 404001,
                    message = $"Unable to find a part with the ID {id}",
                    developerMessage = "None",
                    moreinfo = "Https://example.com/doc/error/404001",
                    requestId = Guid.NewGuid().ToString()
                };

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, apiError));
            }

            return ResponseMessage(Request.CreateResponse(HttpStatusCode.OK, part));
        }

        // PUT: api/Part?id=0d686151-7e36-4fed-bdc4-11df2c2d22e4
        // or
        // PUT: api/Part/0d686151-7e36-4fed-bdc4-11df2c2d22e4
        [Route("api/PartRest")]
        [Route("api/PartRest/{id}")]
        [HttpPut()]
        [ResponseType(typeof(Persistence.Part))]
        public async Task<IHttpActionResult> Put([FromUri] Guid? id, [FromBody] Persistence.Part part)
        {
            if (!ModelState.IsValid | id == null | id == Guid.Empty)
            {
                Models.Shared.APIError apiError = new Models.Shared.APIError
                {
                    status = 400,
                    code = 400001,
                    message = $"The ID is not valid or empty",
                    developerMessage = "The parameters dictionary contains a null entry for parameter 'id' of non-nullable type 'System.Guid' for method Get(System.Guid)",
                    moreinfo = "Https://example.com/doc/error/400001",
                    requestId = Guid.NewGuid().ToString()
                };

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, apiError));
            }

            if (id != part.ID)
            {
                Models.Shared.APIError apiError = new Models.Shared.APIError
                {
                    status = 400,
                    code = 400002,
                    message = $"The ID in URI and in the Body are not equal",
                    developerMessage = "The parameters dictionaries parameter 'id' and 'Part.ID' are not equal Put(System.Guid, Part)",
                    moreinfo = "Https://example.com/doc/error/400002",
                    requestId = Guid.NewGuid().ToString()
                };

                return ResponseMessage(Request.CreateResponse(HttpStatusCode.BadRequest, apiError));
            }

            _context.Entry(part).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartExists(id))
                {
                    Models.Shared.APIError apiError = new Models.Shared.APIError
                    {
                        status = 404,
                        code = 404002,
                        message = $"Unable to find a part with the ID {id}",
                        developerMessage = "DbUpdateConcurrencyException please retry you trastion",
                        moreinfo = "Https://example.com/doc/error/404002",
                        requestId = Guid.NewGuid().ToString()
                    };

                    return ResponseMessage(Request.CreateResponse(HttpStatusCode.NotFound, apiError));
                }
                else
                {
                    throw;
                }
            }
            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NoContent, ""));

        }

        // PUT: api/Part?id=0d686151-7e36-4fed-bdc4-11df2c2d22e4
        // or
        // PUT: api/Part/0d686151-7e36-4fed-bdc4-11df2c2d22e4
        [Route("api/PartRest")]
        [Route("api/PartRest/{id}")]
        [HttpPost()]
        [ResponseType(typeof(Persistence.Part))]
        public async Task<IHttpActionResult> Post([FromUri] Guid id, [FromBody] Persistence.Part part)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != part.ID)
            {
                return BadRequest();
            }

            _context.Parts.Add(part);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return base.Created(new Uri(Request.RequestUri.ToString()), part);

        }

        // Delete: api/Parts?id=0d686151-7e36-4fed-bdc4-11df2c2d22e4
        // or
        // Delete: api/Parts/0d686151-7e36-4fed-bdc4-11df2c2d22e4
        [Route("api/PartRest")]
        [Route("api/PartRest/{id}")]
        [HttpDelete()]
        [ResponseType(typeof(Persistence.Part))]
        public async Task<IHttpActionResult> Delete([FromUri] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var part = await _context.Parts.SingleOrDefaultAsync(m => m.ID == id);
            if (part == null)
            {
                return NotFound();
            }

            _context.Parts.Remove(part);
            await _context.SaveChangesAsync();

            return Ok(part);
        }

        private bool PartExists(Guid? id)
        {
            return _context.Parts.Any(e => e.ID == id);
        }

    }
}