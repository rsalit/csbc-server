using System;
using System.ComponentModel.DataAnnotations;

namespace csbc_server.Models
{
    public class WebContent
    {
        [Key]
        public int WebContentId { get; set; }
        public int? CompanyId { get; set; } = 1;
        public string Page { get; set; }
        public int WebContentTypeId { get; set; } = 1;
        public string Type { get; set; }
        public string Title { get; set; }
        public int? ContentSequence {get; set;}
        public string SubTitle { get; set; }
        public string Location{ get; set; }
        public string DateAndTime { get; set; }
        public string Body { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUser { get; set; }

        // [ForeignKey("WebContentTypeId")]
        // public virtual WebContentType WebContentType { get; set; }
    }
}