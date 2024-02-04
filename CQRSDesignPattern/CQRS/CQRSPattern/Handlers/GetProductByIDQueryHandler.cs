using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.CQRSPattern.Queries;
using CQRS.CQRSPattern.Results;
using CQRS.DAL;

namespace CQRS.CQRSPattern.Handlers
{
    public class GetProductByIDQueryHandler
    {
        private readonly Context _context;
        public GetProductByIDQueryHandler(Context context)
        {
            _context=context;
        }
        public GetProductByIDQueryResult Handle(GetProductByIDQuery getProductByIDQuery){
            var values=_context.Set<Product>().Find(getProductByIDQuery.ID);
            return new GetProductByIDQueryResult{
                ProductName=values.Name,
                Price=values.Price,
                ID=values.ProductID,
                Stock=values.Stock
            }; 
        }
    }
}