using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csbc_server.Models
{
    public partial class Division
    {
        [Key]
        public int DivisionID { get; set; }

        public Nullable<int> CompanyID { get; set; }

        public Nullable<int> SeasonID { get; set; }

        public string Div_Desc { get; set; }

        public Nullable<int> DirectorID { get; set; }

        public Nullable<int> CoDirectorID { get; set; }

        public string Gender { get; set; }

        public Nullable<System.DateTime> MinDate { get; set; }

        public Nullable<System.DateTime> MaxDate { get; set; }

        public string Gender2 { get; set; }

        public Nullable<System.DateTime> MinDate2 { get; set; }

        public Nullable<System.DateTime> MaxDate2 { get; set; }

        public string DraftVenue { get; set; }

        public Nullable<System.DateTime> DraftDate { get; set; }

        public string DraftTime { get; set; }

        public bool Stats { get; set; }

        public Nullable<System.DateTime> CreatedDate { get; set; }

        public string CreatedUser { get; set; }

        //     [ForeignKey("DirectorID")]
        //     public virtual Person Director { get; set; }
    }
}
