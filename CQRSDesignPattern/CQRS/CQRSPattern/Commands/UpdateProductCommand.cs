using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CQRS.CQRSPattern.Commands
{
    public class UpdateProductCommand
    {
        public int ID { get; set; }
        public string ?ProductName { get; set; }
    public int ?Stock { get; set; }
    public decimal ?Price { get; set; }
    public string ?Description { get; set; }
    public bool ?Status { get; set; }
    }
}