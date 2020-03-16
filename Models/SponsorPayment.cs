using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csbc_server.Models
{
    public partial class SponsorPayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public int SponsorProfileID { get; set; }
        public decimal Amount { get; set; }
        public string PaymentType { get; set; }
        public Nullable<System.DateTime> TransactionDate { get; set; }
        public string TransactionNumber { get; set; }
        public string Memo { get; set; }
        public string ShoppingCartID { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedUser { get; set; }

        [ForeignKey("SponsorProfileID")]
        public virtual SponsorProfile SponsorProfile { get; set; }
    }
}
