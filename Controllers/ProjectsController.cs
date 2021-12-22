using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using ODataApiVersion.Models.v1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ODataApiVersion.Controllers
{
    [ODataAttributeRoutingAttribute]
    public class ProjectsController : ControllerBase
    {
        private Customer[] customers = new Customer[]
        {
            new Customer
            {
                Id = 1,
                ApiVersion = "v1.0",
                Name = "Kiron",
                PhoneNumber = "111-222-3333"
            },
            new Customer
            {
                Id = 2,
                ApiVersion = "v1.0",
                Name = "Farid",
                PhoneNumber = "456-ABC-8888"
            }
        };

        [EnableQuery]
        [HttpGet("odata/Projects")]
        public IActionResult Get()
        {
            return Ok(customers);
        }

       
        [HttpGet("odata/Projects/{key}")]
        public IActionResult Get(int key)
        {
            var customer = customers.FirstOrDefault(c => c.Id == key);
            if (customer == null)
            {
                return NotFound($"Cannot find customer with Id={key}.");
            }

            return Ok(customer);
        }
    }
}
