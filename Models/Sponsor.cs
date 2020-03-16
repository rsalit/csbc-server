using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csbc_server.Models
{
    public partial class Sponsor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SponsorID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<int> SeasonID { get; set; }
        public Nullable<int> HouseID { get; set; }
        //public string ContactNameDELETE { get; set; }
        //public string SpoNameDELETE { get; set; }
        public string ShirtName { get; set; }
        //public string EMAILDELETE { get; set; }
        //public string URLDELETE { get; set; }
        //public string AddressDELETE { get; set; }
        //public string CityDELETE { get; set; }
        //public string StateDELETE { get; set; }
        //public string ZipDELETE { get; set; }
        //public string PhoneDELETE { get; set; }
        public string ShirtSize { get; set; }
        public Nullable<decimal> SpoAmount { get; set; }
        //public string TypeOfBussDELETE { get; set; }
        public string Color1 { get; set; }
        public int Color1ID { get; set; }
        public string Color2 { get; set; }
        public int Color2ID { get; set; }
        public Nullable<int> ShoppingCartID { get; set; }
        public Nullable<bool> MailCheck { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public int SponsorProfileID { get; set; }
        public Nullable<decimal> FeeID { get; set; }

        [ForeignKey("SponsorProfileID")]
        public virtual SponsorProfile SponsorProfile { get; set; }
    }


}
