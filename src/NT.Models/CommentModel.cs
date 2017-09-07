using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace NT.Models
{
    public class CommentModel
    {
        public long Id { get; set; }
        [Required]
        [Display(Name = "Message")]
        public string Message { get; set; }
        public long StoryID { get; set; }
        public long UserID { get; set; }
        public string PostedByName { get; set; }
        public string PostedByAvatar { get; set; }
        public bool Liked { get; set; }
        public int TotalLikes { get; set; }
        public int TotalDisLikes { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
