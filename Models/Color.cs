using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace csbc_server.Models
{
    public partial class Color
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public Nullable<int> CompanyID { get; set; }
        public string ColorName { get; set; }
        public Nullable<bool> Discontinued { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public string CreatedUser { get; set; }
    }
}
