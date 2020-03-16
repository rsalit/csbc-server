using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csbc_server.Models
{
    public partial class Person
    {
        [Key]
        public int PeopleID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        [Column("MainHouseID")]
        public int? HouseID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Workphone { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public Nullable<bool> Suspended { get; set; }
        public string LatestSeason { get; set; }
        public string LatestShirtSize { get; set; }
        public Nullable<int> LatestRating { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<bool> BC { get; set; }
        public string Gender { get; set; }
        public string SchoolName { get; set; }
        public Nullable<int> Grade { get; set; }
        public Nullable<int> GiftedLevelsUP { get; set; }
        public Nullable<bool> FeeWaived { get; set; }
        public Nullable<bool> Player { get; set; }
        public Nullable<bool> Parent { get; set; }
        public Nullable<bool> Coach { get; set; }
        public Nullable<bool> AsstCoach { get; set; }
        public Nullable<bool> BoardOfficer { get; set; }
        public Nullable<bool> BoardMember { get; set; }
        public Nullable<bool> AD { get; set; }
        public Nullable<bool> Sponsor { get; set; }
        public Nullable<bool> SignUps { get; set; }
        public Nullable<bool> TryOuts { get; set; }
        public Nullable<bool> TeeShirts { get; set; }
        public Nullable<bool> Printing { get; set; }
        public Nullable<bool> Equipment { get; set; }
        public Nullable<bool> Electrician { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedUser { get; set; }
        public Nullable<int> TEMPID { get; set; }

        [ForeignKey("HouseID")]
        public virtual Household Household { get; set; } //this should be part of data model - but its not
    }
}
