using System.Net.Http;
using System.Web.Http;
using System.Net;
using System.Linq;
using System;
using System.Collections.Generic;
using Service.Models.DB;
using System.Threading.Tasks;
using System.Web.Http.Description;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Service.Controllers
{
    public class PartSOAPController : ApiController
    {
    

        //Below is Not Restful

        [Route("api/PartSOAP/GetPartFromDTO")]
        [HttpStringHtmlEncodeDecodeFilter]
        //[AllowAnonymous()]
        [HttpGet()]
        public HttpResponseMessage GetPartFromDTO()
        {
            var part = new Part();
            var customField = new CustomField();
            Persistence.Part queryPart = new Persistence.Part();
            using (var DbContext = new Persistence.ApplicationDbContext())
            {
                queryPart = (from entity in DbContext.Parts.Include("PartCustomField").Include("PartCustomField.CustomField")
                             where entity.ID == new Guid("0d686151-7e36-4fed-bdc4-11df2c2d22e4")
                             select entity).FirstOrDefault();
            }


            if (queryPart == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Address with ID = is not found or is not available to you!");
            }
            part.ID = queryPart.ID;
            part.IsActive = queryPart.IsActive;
            part.Name = queryPart.Name;
            foreach (var p in queryPart.PartCustomField)
            {
                CustomField x = new CustomField();
                x.ID = p.CustomField.ID;
                x.IsActive = p.CustomField.IsActive;
                x.Name = p.CustomField.Name;
                if (part.CustomFields == null)
                {
                    part.CustomFields = new List<CustomField>();
                }
                part.CustomFields.Add(x);
            }

            return Request.CreateResponse(HttpStatusCode.OK, part);
        }




        [Route("api/PartSOAP/GetPartFromEF")]
        [HttpStringHtmlEncodeDecodeFilter]
        //[AllowAnonymous()]
        [HttpGet()]
        public HttpResponseMessage GetPartFromEF()
        {
            var part = new Part();
            var customField = new CustomField();
            Persistence.Part queryPart = new Persistence.Part();
            using (var DbContext = new Persistence.ApplicationDbContext())
            {
                queryPart = (from entity in DbContext.Parts.Include("PartCustomField").Include("PartCustomField.CustomField")
                             where entity.ID == new Guid("0d686151-7e36-4fed-bdc4-11df2c2d22e4")
                             select entity).FirstOrDefault();


                if (queryPart == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Address with ID = is not found or is not available to you!");
                }

                return Request.CreateResponse(HttpStatusCode.OK, queryPart);
            }
        }





    }
}