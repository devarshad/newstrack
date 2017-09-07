using System;
using NT.Models;
namespace NT.Data
{
    public interface IStory : IDisposable
    {
        StoriesByCategoryModel GetStoriesByCategory(int ID, int PageNumber, int PageSize);
        StoryByGroupModel GetStoriesByGroup(int ID, int PageNumber, int PageSize);
        StoryModel GetStoryByID(long ID);
    }
}