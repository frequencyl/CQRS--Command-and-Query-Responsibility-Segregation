using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.CQRSPattern.Commands
{
    public class DeleteProductCommand
    {
        public int ID { get; set; }

        public DeleteProductCommand(int id)
        {
            ID = id;
        }
    }
}