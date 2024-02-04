using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.CQRSPattern.Queries;
using CQRS.CQRSPattern.Results;
using CQRS.DAL;

namespace CQRS.CQRSPattern.Handlers
{
    public class GetProductUpdateByIDQueryHandler
    {
        private readonly Context _context;
        public GetProductUpdateByIDQueryHandler(Context context)
        {
            _context=context;
        }
        public GetProductUpdateQueryResult Handle(GetProductUpdateByIDQuery getProductUpdateByIDQuery){
            var values= _context.Products.Find(getProductUpdateByIDQuery.ID);
            return new GetProductUpdateQueryResult {
                Description=values.Description,
                ProductName=values.Name,
                Price=values.Price,
                ID=values.ProductID,
                Stock=values.Stock
            };
        }

    
    }
}