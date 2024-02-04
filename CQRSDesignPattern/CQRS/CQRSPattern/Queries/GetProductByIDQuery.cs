using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.CQRSPattern.Queries
{
    public class GetProductByIDQuery
    {
        public GetProductByIDQuery(int id)
        {
            ID = id;
        }

        public int ID { get; set; }
    }
}