using System;
using NT.Models;
using NT.Data;
namespace NT.Core
{
    public class Story
    {
        private IStory _istory { get { return new DataRepository(); } }

        /// <summary>
        /// get story detail
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public StoryModel GetStoryByID(long ID)
        {
            return _istory.GetStoryByID(ID);
        }

        /// <summary>
        /// get stories for a categories
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public StoriesByCategoryModel GetStoriesByCategory(int ID, int PageNumber, int PageSize)
        {
            return _istory.GetStoriesByCategory(ID, PageNumber, PageSize);
        }

        /// <summary>
        /// get stories for a Group
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public StoryByGroupModel GetStoriesByGroup(int ID, int PageNumber, int PageSize)
        {
            return _istory.GetStoriesByGroup(ID, PageNumber, PageSize);
        }
    }
}
