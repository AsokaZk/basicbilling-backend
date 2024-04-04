using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Dtos
{
    public class GetBillingParams
    {
        public required string ClientId { get; set; }
    }
}
