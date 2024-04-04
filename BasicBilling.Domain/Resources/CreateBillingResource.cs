using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Resources
{
    public class CreateBillingResource
    {
        public required int Period { get; set; }
        public required string Category { get; set; }
    }
}
