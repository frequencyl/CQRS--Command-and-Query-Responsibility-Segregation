using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.CQRSPattern.Commands;
using CQRS.DAL;

namespace CQRS.CQRSPattern.Handlers
{
    public class DeleteProductCommandHandler
    {
        private readonly Context _context;

        public DeleteProductCommandHandler(Context context)
        {
            _context=context;
        }
        public void Handle(DeleteProductCommand deleteProductCommand){
            var values=_context.Products.Find(deleteProductCommand.ID);
            _context.Products.Remove(values);
            _context.SaveChanges();
        }
    }
}