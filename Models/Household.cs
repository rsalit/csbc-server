using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace csbc_server.Models
{
    public partial class Household
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int HouseID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string Email { get; set; }
        public Nullable<bool> EmailList { get; set; }
        public string SportsCard { get; set; }
        public Nullable<int> Guardian { get; set; }
        public Nullable<bool> FeeWaived { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public Nullable<int> TEMID { get; set; }
    }
}
