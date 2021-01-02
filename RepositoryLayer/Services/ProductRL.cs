
using CommonLayer.Models;
using Repository;
using RepositoryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace RepositoryLayer.Services
{
    public class ProductRL:IProductRL
    {
        private readonly BookStoreContext context;

        public ProductRL(BookStoreContext context)
        {
            this.context = context;
        }
        public List<Product> GetAllProducts()
        {
            try
            {
                List<Product> list = (from e in this.context.products
                                      select new Product
                                      {
                                          product_id = e.product_id,
                                          bookName = e.bookName,
                                          bookImage=e.bookImage,
                                          author = e.author,
                                          description = e.description,
                                          quantity = e.quantity,
                                          price = e.price,
                                          discountPrice = e.discountPrice
                                      }).ToList<Product>();

                return list;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
