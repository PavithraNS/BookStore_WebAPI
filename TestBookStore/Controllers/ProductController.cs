using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace BookStroreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductBL productBL;
        IConfiguration configuration;

        public ProductController(IProductBL productBL, IConfiguration configuration)
        {
            this.productBL = productBL;
            this.configuration = configuration;
        }
        [HttpGet("GetProducts")]
        public IActionResult GetAllProducts()
        {
            try
            {
                List<Product> empList = this.productBL.GetAllProducts();
                if (empList != null)
                {
                    return this.Ok(new { success = true, Message = "get Employee records successfully", data = empList });
                }
                else
                {
                    return this.NotFound(new { success = false, Message = "get Employee records unsuccessfully" });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, Message = e.Message });
            }
        }
    }
}
