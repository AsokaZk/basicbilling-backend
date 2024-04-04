using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class BillingDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int Charge { get; set; }
        public int Period { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
    }
}
