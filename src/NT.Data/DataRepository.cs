using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NT.Models;

namespace NT.Data
{
    /// <summary>
    /// Repository class to access database object and enable database intraction functions
    /// </summary>
    public class DataRepository : IDisposable, IStory
    {
        #region Private Data Member
        /// <summary>
        /// main database entity object to access NT database member and function
        /// </summary>
        private NTEntities _ntdb = null;
        #endregion

        #region Public function

        #region User function
        /// <summary>
        /// function to search a user by its username, fullname, email address or phone number
        /// </summary>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        public _IdentityUser FindUser(string searchKey)
        {
            using (_ntdb = new NTEntities())
            {
                try
                {
                    var _user = _ntdb.AspNetUsers.FirstOrDefault(x => x.Email == searchKey || x.FullName.Contains(searchKey) || x.PhoneNumber == searchKey);
                    _IdentityUser _identityuser = null;
                    if (_user != null)
                    {
                        _identityuser = new _IdentityUser
                        {
                            Id = _user.Id,
                            Fullname = _user.FullName,
                            Email = _user.Email,
                            PhoneNumber = _user.PhoneNumber
                        };
                    }
                    return _identityuser;
                }
                catch (Exception ex)
                {
                    ex.HelpLink = "It can be due to bad search keywork supplied or data type mismatch.";
                    ex.Data.Add("Location : ", "Exception occured while fetching user detail.");
                    ex.Data.Add("Applpication Tier : ", "3. NT.Data");
                    ex.Data.Add("Class : ", "DataRepository");
                    ex.Data.Add("Method : ", "FindUserAsync");
                    ex.Data.Add("Input Parameters : ", string.Format("searchKey: {0}", searchKey));
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Custom method for Confirm email for those users having external login.
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns>bool status to represent that email jhas been confirmed or not.</returns>
        public bool ConfirmEmail(long id)
        {
            using (_ntdb = new NTEntities())
            {
                try
                {
                    var _user = _ntdb.AspNetUsers.Find(id);
                    if (_user != null)
                    {
                        _user.EmailConfirmed = true;
                        _ntdb.SaveChanges();
                        return true;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    ex.HelpLink = "It can be due to bad search keywork supplied or data type mismatch.";
                    ex.Data.Add("Location : ", "Exception occured while updating user confirmation email status.");
                    ex.Data.Add("Applpication Tier : ", "3. NT.Data");
                    ex.Data.Add("Class : ", "DataRepository");
                    ex.Data.Add("Method : ", "ConfirmEmail");
                    ex.Data.Add("Input Parameters : ", string.Format("id: {0}", id));
                    throw ex;
                }
            }
        }
        #endregion

        #region Story function

        /// <summary>
        /// get the detail of story by Story ID
        /// </summary>
        /// <param name="ID">Story ID</param>
        /// <returns>Return StoryModel object containing story detail with comment and related images.</returns>
        public StoryModel GetStoryByID(long ID)
        {
            using (_ntdb = new NTEntities())
            {
                try
                {
                    return _ntdb.Stories
                        .Select(sT => new StoryModel
                        {
                            Id = sT.ID,
                            Title = sT.Title,
                            Descripition = sT.Descripition,
                            UserID = sT.UserID,

                            CreatedOn = sT.CreatedOn,
                            GroupName = sT.Category.Group.Name,
                            CategoryName = sT.Category.Name,
                            ViewsCount = sT.ViewsCount,
                            Active = sT.IsActive,
                            StoryComments = sT.Comments.Select(cM => new CommentModel
                            {
                                Id = cM.ID,
                                StoryID = cM.StoryID,
                                Message = cM.Text,
                                UserID = cM.UserID,
                                PostedByName = cM.AspNetUser.FullName,
                                PostedByAvatar = cM.AspNetUser.ProfilePicture,
                                CreatedOn = cM.CreatedOn
                            }),
                            StoryData = sT.StoryDatas.Select(sTD => new StoryDataModel
                            {
                                Id = sTD.ID,
                                StoryID = sTD.StoryID,
                                AltText = sT.Title,
                                Url = sTD.Url,
                                ThumbnailUrl = sTD.ThumbnailUrl,
                                Type = (Enums.StoryDataType)sTD.Type
                            })
                        })
                        .FirstOrDefault(sT => sT.Id == ID);
                }
                catch (Exception ex)
                {
                    ex.HelpLink = "It can be due to bad ID supplied or data type mismatch.";
                    ex.Data.Add("Location : ", "Exception occured while fetching story detail.");
                    ex.Data.Add("Applpication Tier : ", "3. NT.Data");
                    ex.Data.Add("Class : ", "DataRepository");
                    ex.Data.Add("Method : ", "GetStoryByID");
                    ex.Data.Add("Input Parameters : ", string.Format("ID: {0}", ID));
                    throw ex;
                }
            }
        }

        /// <summary>
        /// get the list of Stories with category detail by Category ID
        /// </summary>
        /// <param name="ID">Category ID</param>
        /// <returns>Return StoriesByCategoryModel object containing category detail with stories of that category by story detail with comment and related images.</returns>
        public StoriesByCategoryModel GetStoriesByCategory(int ID, int PageNumber, int PageSize)
        {
            int _recordsToSkip = PageSize * PageNumber;
            using (_ntdb = new NTEntities())
            {
                try
                {
                    return _ntdb.Categories
                        .Select(cT => new StoriesByCategoryModel
                        {
                            Id = cT.ID,
                            CategoryName = cT.Name,
                            GroupName = cT.Group.Name,
                            Stories = cT.Stories
                                        .Select(sT => new StoryModel
                                        {
                                            Id = sT.ID,
                                            Title = sT.Title,
                                            Descripition = sT.Descripition,
                                            UserID = sT.UserID,
                                            CreatedOn = sT.CreatedOn,
                                            GroupName = sT.Category.Group.Name,
                                            CategoryName = sT.Category.Name,
                                            ViewsCount = sT.ViewsCount,
                                            Active = sT.IsActive,
                                            StoryComments = sT.Comments.Select(cM => new CommentModel
                                            {
                                                Id = cM.ID,
                                                StoryID = cM.StoryID,
                                                Message = cM.Text,
                                                UserID = cM.UserID,
                                                PostedByName = cM.AspNetUser.FullName,
                                                PostedByAvatar = cM.AspNetUser.ProfilePicture,
                                                CreatedOn = cM.CreatedOn
                                            }),
                                            StoryData = sT.StoryDatas.Select(sTD => new StoryDataModel
                                            {
                                                Id = sTD.ID,
                                                StoryID = sTD.StoryID,
                                                AltText = sT.Title,
                                                Url = sTD.Url,
                                                ThumbnailUrl = sTD.ThumbnailUrl,
                                                Type = (Enums.StoryDataType)sTD.Type
                                            }).Take(1)
                                        }).OrderByDescending(x => x.Id).Skip(_recordsToSkip).Take(PageSize)
                        })
                        .FirstOrDefault(sT => sT.Id == ID);
                }
                catch (Exception ex)
                {
                    ex.HelpLink = "It can be due to bad ID supplied or data type mismatch.";
                    ex.Data.Add("Location : ", "Exception occured while fetching category detail with stories list.");
                    ex.Data.Add("Applpication Tier : ", "3. NT.Data");
                    ex.Data.Add("Class : ", "DataRepository");
                    ex.Data.Add("Method : ", "GetStoriesByCategory");
                    ex.Data.Add("Input Parameters : ", string.Format("ID: {0}", ID));
                    throw ex;
                }
            }
        }

        /// <summary>
        /// get the list of Categories with its detail along with list of stories of each categories by Group ID
        /// </summary>
        /// <param name="ID">Group ID</param>
        /// <returns>Return StoryByGroupModel object containing group detail with list of Categories with its detail along with list of stories of each categories of that group by story detail with comment and related images.</returns>
        public StoryByGroupModel GetStoriesByGroup(int ID, int PageNumber, int PageSize)
        {
            int _recordsToSkip = PageSize * PageNumber;
            using (_ntdb = new NTEntities())
            {
                try
                {
                    return _ntdb.Groups
                        .Select(gR => new StoryByGroupModel
                        {
                            Id = gR.ID,
                            GroupName = gR.Name,
                            StoriesByCategory = gR.Categories.Select(cT => new StoriesByCategoryModel
                            {
                                Id = cT.ID,
                                CategoryName = cT.Name,
                                GroupName = cT.Group.Name,
                                Stories = cT.Stories
                                            .Select(sT => new StoryModel
                                            {
                                                Id = sT.ID,
                                                Title = sT.Title,
                                                Descripition = sT.Descripition,
                                                UserID = sT.UserID,
                                                CreatedOn = sT.CreatedOn,
                                                GroupName = sT.Category.Group.Name,
                                                CategoryName = sT.Category.Name,
                                                ViewsCount = sT.ViewsCount,
                                                Active = sT.IsActive,
                                                StoryComments = sT.Comments.Select(cM => new CommentModel
                                                {
                                                    Id = cM.ID,
                                                    StoryID = cM.StoryID,
                                                    Message = cM.Text,
                                                    UserID = cM.UserID,
                                                    PostedByName = cM.AspNetUser.FullName,
                                                    PostedByAvatar = cM.AspNetUser.ProfilePicture,
                                                    CreatedOn = cM.CreatedOn
                                                }),
                                                StoryData = sT.StoryDatas.Select(sTD => new StoryDataModel
                                                {
                                                    Id = sTD.ID,
                                                    StoryID = sTD.StoryID,
                                                    AltText = sT.Title,
                                                    Url = sTD.Url,
                                                    ThumbnailUrl = sTD.ThumbnailUrl,
                                                    Type = (Enums.StoryDataType)sTD.Type
                                                }).Take(1)
                                            })
                            }).OrderByDescending(x => x.Id).Skip(_recordsToSkip).Take(PageSize)
                        })
                        .FirstOrDefault(sT => sT.Id == ID);
                }
                catch (Exception ex)
                {
                    ex.HelpLink = "It can be due to bad ID supplied or data type mismatch.";
                    ex.Data.Add("Location : ", "Exception occured while fetching group detail with categories list along with stories list.");
                    ex.Data.Add("Applpication Tier : ", "3. NT.Data");
                    ex.Data.Add("Class : ", "DataRepository");
                    ex.Data.Add("Method : ", "GetStoriesByGroup");
                    ex.Data.Add("Input Parameters : ", string.Format("ID: {0}", ID));
                    throw ex;
                }
            }
        }

        #endregion

        #region Helper function

        /// <summary>
        /// Overriden method for object dispose method.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        #endregion
    }
}
