using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csbc_server.Models
{
    public partial class Team
    {
        [Key]
        public int TeamID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public int SeasonID { get; set; }
        public int DivisionID { get; set; }
        public Nullable<int> CoachID { get; set; }
        public Nullable<int> AssCoachID { get; set; }
        public Nullable<int> SponsorID { get; set; }
        [MaxLength(50)]
        public string TeamName { get; set; }
        [MaxLength(50)]
        public string TeamColor { get; set; }
        public int TeamColorID { get; set; }
         [MaxLength(4)]
        public string TeamNumber { get; set; }
        public Nullable<int> Round1 { get; set; }
        public Nullable<int> Round2 { get; set; }
        public Nullable<int> Round3 { get; set; }
        public Nullable<int> Round4 { get; set; }
        public Nullable<int> Round5 { get; set; }
        public Nullable<int> Round6 { get; set; }
        public Nullable<int> Round7 { get; set; }
        public Nullable<int> Round8 { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedUser { get; set; }

        [ForeignKey("SeasonID")]
        public virtual Season Season { get; set; }
        [ForeignKey("DivisionID")]
        public virtual Division Division { get; set; }
        [ForeignKey("CoachID")]
        public virtual Coach Coach { get; set; }
        [ForeignKey("AssCoachID")]
        public virtual Coach AsstCoach { get; set; }
       
        [ForeignKey("TeamColorID")]
        public virtual Color Color { get; set; }

    }

 
}
