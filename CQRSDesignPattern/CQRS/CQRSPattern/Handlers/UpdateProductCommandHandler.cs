using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.CQRSPattern.Commands;
using CQRS.DAL;

namespace CQRS.CQRSPattern.Handlers
{
    public class UpdateProductCommandHandler
    {
        private readonly Context _context;

        public UpdateProductCommandHandler(Context context)
        {
            _context = context;
        }
        public void Handle(UpdateProductCommand updateProductCommand){
            var values=_context.Products.Find(updateProductCommand.ID);
            values.Name = updateProductCommand.ProductName;
            values.Price=updateProductCommand.Price;
            values.Stock=updateProductCommand.Stock;
            values.Description=updateProductCommand.Description;
            values.Status=true;
            _context.SaveChanges();
        }
    }
}