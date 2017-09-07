using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web;
namespace NT.Models
{
    public class StoryDataModel
    {
        public long Id { get; set; }
        public long StoryID { get; set; }
        public string AltText { get; set; }
        [DataType(DataType.Html)]
        public string Caption { get; set; }
        [DataType(DataType.Upload)]
        HttpPostedFileBase File { get; set; }
        [Required]
        [DataType(DataType.ImageUrl)]
        public string Url { get; set; }
        [DataType(DataType.ImageUrl)]
        public string ThumbnailUrl { get; set; }
        private DateTime CreatedDate { get; set; }
        public Enums.StoryDataType Type { get; set; }
    }
}
