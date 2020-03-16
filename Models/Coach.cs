using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csbc_server.Models
{
    public partial class Coach
    {
        [Key]
        public int CoachID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public Nullable<int> SeasonID { get; set; }
        public int PeopleID { get; set; }
        public Nullable<int> PlayerID { get; set; }
        public string ShirtSize { get; set; }
        public string CoachPhone { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedUser { get; set; }

        [ForeignKey("PeopleID")]
        public virtual Person Person { get; set; }
    }
}
