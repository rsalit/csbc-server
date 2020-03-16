using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csbc_server.Models
{
    public partial class SponsorProfile
    {
        [Key] //declaring key even though it doesn't exist in DB - it should!
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SponsorProfileID { get; set; }

        public int CompanyID { get; set; }

        public Nullable<int> HouseID { get; set; }

        public string ContactName { get; set; }

        public string SpoName { get; set; }

        public string EMAIL { get; set; }

        public string URL { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Phone { get; set; }

        public string TypeOfBuss { get; set; }

        public Nullable<System.DateTime> CreatedDate { get; set; }

        public string CreatedUser { get; set; }

        public bool? ShowAd { get; set; }

        public DateTime? AdExpiration { get; set; }

        public virtual ICollection<Sponsor> Sponsors { get; set; }
    }
}
