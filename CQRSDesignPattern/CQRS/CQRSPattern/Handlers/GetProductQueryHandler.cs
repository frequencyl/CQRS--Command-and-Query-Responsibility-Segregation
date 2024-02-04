using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.CQRSPattern.Results;
using CQRS.DAL;

namespace CQRS.CQRSPattern.Handlers
{
    public class GetProductQueryHandler
    {
        private readonly Context _context;

        public GetProductQueryHandler(Context context)
        {
            _context=context;
        }
        public List<GetProductQueryResult> Handle()
        {
            var values=_context.Products.Select(x=>new GetProductQueryResult{
                ID=x.ProductID, ProductName=x.Name, Price=x.Price, Stock=x.Stock
            }).ToList();
            return values;
        }
    }
}