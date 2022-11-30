using System.Collections;
using Microsoft.EntityFrameworkCore;
using online_medical_services.Entities;
using online_medical_services.Helpers;
using online_medical_services.Interfaces;
using online_medical_services.Models;
using shortid;

namespace online_medical_services.Services
{
    public class ProductServices : IProducts
    {
        private Messages _messages = new Messages();
        public async Task<ResponseMessage> AddProduct(AddProductModel product)
        {
            using (Dbcon _dbcon = new Dbcon())
            {
                string productToken = ShortId.Generate();
                var details = new Product
                {
                    Brand = product.Brand,
                    CreatedOn = DateTime.Now,
                    Description = product.Description,
                    Discount = product.Discount,
                    Expiry = product.Expiry,
                    Name = product.Name,
                    Price = product.Price,
                    Returnable = product.Returnable,
                    Token = productToken,
                    Type = product.Type,
                    CreatedBy = "system"
                };
                 _dbcon.Products.Add(details);
                _dbcon.SaveChanges();
                int productId = details.Id;

                await _dbcon.ProductQuantities.AddAsync(new ProductQuantity
                {
                    ProductId= productId,
                    CreatedBy="system",
                    ProductToken= productToken,
                    CreatedOn= DateTime.Now,
                    Quantity=product.Quantity,
                    Token=ShortId.Generate(),
                });
                _dbcon.SaveChanges();
                return new ResponseMessage { Message = _messages.PRODUCT_CREATED, Status = _messages.SUCCESS };
            }
        }

        public async Task<ArrayList> ListProducts()
        {
            ArrayList arrayList= new ArrayList();
            using(Dbcon _dbcon = new Dbcon())
            {
                var details= await (from P in _dbcon.Products
                              from Q in _dbcon.ProductQuantities
                              where Q.ProductId == P.Id
                              select new
                              {
                                  P.Id,
                                  P.Brand,
                                  P.Name,
                                  P.Price,
                                  Q.Quantity
                              }).ToListAsync();
                if (details != null)
                {
                    arrayList.Add(details); 
                }
                return arrayList;
            }
        }
    }
}
