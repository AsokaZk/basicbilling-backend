using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.Runtime.Serialization;

namespace Domain.Entities
{
    public class Billing
    {
        public Billing()
        {
        }
        public Billing(int period, int clientId, int billingCategoryId, int billingStatusId, string charge = "200")
        {
            this.Charge = charge;
            this.Period = period;
            this.ClientId = clientId;
            this.BillingCategoryId = billingCategoryId;
            this.BillingStatusId = billingStatusId;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Charge { get; set; }
        public int Period { get; set; }
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        [IgnoreDataMember]
        public virtual Client Client { get; set; }
        public int BillingCategoryId { get; set; }
        [ForeignKey("BillingCategoryId")]
        [IgnoreDataMember]
        public virtual BillingCategory BillingCategory { get; set; }
        public int BillingStatusId { get; set; }
        [ForeignKey("BillingStatusId")]
        [IgnoreDataMember]
        public virtual BillingStatus BillingStatus { get; set; }
    }
}
