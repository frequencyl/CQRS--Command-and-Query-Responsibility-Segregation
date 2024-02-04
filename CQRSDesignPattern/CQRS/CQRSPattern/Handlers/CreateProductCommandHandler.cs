using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.CQRSPattern.Commands;
using CQRS.DAL;

namespace CQRS.CQRSPattern.Handlers
{
    public class CreateProductCommandHandler
    {
        private readonly Context _context;

        public CreateProductCommandHandler(Context context)
        {
            _context=context;
        }
        public void Handle(CreateProductCommand command){
            _context.Products.Add(new Product
            {
                Description=command.Description,
                Name=command.Name,
                Price=command.Price,
                Status=true,
                Stock=command.Stock
            }
            );
            _context.SaveChanges();
        }
    }
}