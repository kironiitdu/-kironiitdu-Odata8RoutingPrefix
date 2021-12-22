// Copyright saxu@microsoft.com.  All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataApiVersion.Models.v1;

namespace ODataApiVersion.Controllers.v1
{
    [Route("odata")]
    [Route("v{version}")]
    public class CustomersController : ODataController
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
        public IActionResult Get()
        {
            return Ok(customers);
        }

        [EnableQuery]
        [HttpGet("odata/Customers({key})")]
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
