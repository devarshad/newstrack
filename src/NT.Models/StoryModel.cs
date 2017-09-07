using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace NT.Models
{
    /// <summary>
    /// Story Detail
    /// </summary>
    public class StoryModel
    {
        public long Id { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }
        public string Descripition { get; set; }
        public string Link { get; set; }
        public string LinkIcon { get; set; }
        public string Linkcaption { get; set; }
        public long UserID { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal Longitude { get; set; }
        public decimal Lattitude { get; set; }
        public String GroupName { get; set; }
        public String CategoryName { get; set; }
        public bool Liked { get; set; }
        public int TotalLikes { get; set; }
        public int TotalDisLikes { get; set; }
        public int ViewsCount { get; set; }
        public Nullable<bool> Active { get; set; }
        public IEnumerable<CommentModel> StoryComments { get; set; }
        public IEnumerable<StoryDataModel> StoryData { get; set; }

    }

    /// <summary>
    /// List of Stories with category detail
    /// </summary>
    public class StoriesByCategoryModel
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string GroupName { get; set; }
        public IEnumerable<StoryModel> Stories { get; set; }
    }

    /// <summary>
    /// List of categoris with its Stories for a Group
    /// </summary>
    public class StoryByGroupModel
    {
        public int Id { get; set; }
        public string GroupName { get; set; }
        public IEnumerable<StoriesByCategoryModel> StoriesByCategory { get; set; }
    }
}
