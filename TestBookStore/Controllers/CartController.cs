﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using CommonLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookStroreWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartBL cartBL;
        IConfiguration configuration;

        public CartController(ICartBL cartBL, IConfiguration configuration)
        {
            this.cartBL = cartBL;
            this.configuration = configuration;
        }
        [HttpPost("AddCart")]
        public IActionResult AddCart(CartItem cart)
        {
            try
            {
                string LoggedInUser=HttpContext.Session.GetString("LogedInUser");
                cart.loginUser = LoggedInUser;
                if (this.cartBL.AddCart(cart))
                {
                    return this.Ok(new { success = true, Message = "CartItem added successfully" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new { success = false, Message = "CartItem is not added " });
                }
            }
            catch (Exception e)
            {
                var sqlException = e.InnerException as SqlException;

                if (sqlException.Number == 2601 || sqlException.Number == 2627)
                {
                    return StatusCode(StatusCodes.Status409Conflict,
                        new { success = false, ErrorMessage = "Cannot insert duplicate values." });
                }
                else
                {
                    return this.BadRequest(new { success = false, Message = e.Message });
                }

            }
        }

        [HttpPost("UpdateCart")]
        public IActionResult UpdateCart(CartItem cart)
        {
            try
            {
                string LoggedInUser = HttpContext.Session.GetString("LogedInUser");
                cart.loginUser = LoggedInUser;
                if (this.cartBL.UpdateCart(cart))
                {
                    return this.Ok(new { success = true, Message = "CartItem Updated successfully" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new { success = false, Message = "CartItem is not updated " });
                }
            }
            catch (Exception e)
            {
                var sqlException = e.InnerException as SqlException;

                if (sqlException.Number == 2601 || sqlException.Number == 2627)
                {
                    return StatusCode(StatusCodes.Status409Conflict,
                        new { success = false, ErrorMessage = "Please provide quantityToBug" });
                }
                else
                {
                    return this.BadRequest(new { success = false, Message = e.Message });
                }

            }
        }

        [HttpGet("GetCartItems")]
        public IActionResult GetCartItems()
        {
            try
            {
                string LoggedInUser = HttpContext.Session.GetString("LogedInUser");
                //cart.loginUser = LoggedInUser;
                var result=this.cartBL.GetCartItems(LoggedInUser);
                if (result!=null)
                {
                    return this.Ok(new { success = true, Message = "fetching All CardItems",result });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new { success = false, Message = "CartItem is not added " });
                }
            }
            catch (Exception e)
            {
                var sqlException = e.InnerException as SqlException;

                if (sqlException.Number == 2601 || sqlException.Number == 2627)
                {
                    return StatusCode(StatusCodes.Status409Conflict,
                        new { success = false, ErrorMessage = "Cannot insert duplicate values." });
                }
                else
                {
                    return this.BadRequest(new { success = false, Message = e.Message });
                }

            }
        }

        [HttpPost("RemoveCartItem")]
        public IActionResult RemoveCartItem(int productId)
        {
            try
            {
                CartItem cart = new CartItem();
                string LoggedInUser = HttpContext.Session.GetString("LogedInUser");
                cart.loginUser = LoggedInUser;
                cart.product_id = productId;
                if (this.cartBL.RemoveCartItem(cart))
                {
                    return this.Ok(new { success = true, Message = "CartItem removed successfully" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new { success = false, Message = "CartItem is not removed " });
                }
            }
            catch (Exception e)
            {
                var sqlException = e.InnerException as SqlException;

                if (sqlException.Number == 2601 || sqlException.Number == 2627)
                {
                    return StatusCode(StatusCodes.Status409Conflict,
                        new { success = false, ErrorMessage = "CartId not exists" });
                }
                else
                {
                    return this.BadRequest(new { success = false, Message = e.Message });
                }

            }
        }

        [HttpPost("ReduceBookQuantity")]
        public IActionResult ReduceBookQuantity(int productId,int quantityToRemove)
        {
            try
            {
                CartItem cart = new CartItem();
                string LoggedInUser = HttpContext.Session.GetString("LogedInUser");
                cart.loginUser = LoggedInUser;
                cart.quantityToBuy = quantityToRemove;
                cart.product_id = productId;
                if (this.cartBL.ReduceBookQuantity(cart))
                {
                    return this.Ok(new { success = true, Message = "CartItem removed successfully" });
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new { success = false, Message = "CartItem is not removed " });
                }
            }
            catch (Exception e)
            {
                var sqlException = e.InnerException as SqlException;

                if (sqlException.Number == 2601 || sqlException.Number == 2627)
                {
                    return StatusCode(StatusCodes.Status409Conflict,
                        new { success = false, ErrorMessage = "CartId not exists" });
                }
                else
                {
                    return this.BadRequest(new { success = false, Message = e.Message });
                }

            }
        }
    }
}
