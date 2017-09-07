using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using NewsTrack.Filters;
using NewsTrack;
using NT.Core;
namespace NewsTrack.API
{
    [CompressFilter(Order = 1)]
    [CacheFilter(Duration = 60, Order = 2)]
    public abstract class BaseController : ApiController
    {
        #region Private Data Member

        #endregion

        #region Public Data Members

        /// <summary>
        /// Current user access for Identity information
        /// </summary>
        public AppUserPrincipal CurrentUser
        {
            get
            {
                return new AppUserPrincipal(base.User as ClaimsPrincipal);
            }
        }
        public HttpResponseMessage response
        {
            get { return _response; }
            set { _response = value; }
        }

        public Story _story { get { return new Story(); } }

        #endregion

        #region Protected Data Member

        /// <summary>
        /// Return response request
        /// </summary>
        protected HttpResponseMessage _response;

        #endregion

        #region Static Data Member

        #endregion

        #region Constructor
        /// <summary>
        /// Initialize post access object
        /// </summary>
        public BaseController()
        {

        }
        #endregion

        #region Private Member Functions

        #endregion

        #region Protected Member function
        /// <summary>
        /// Get user information
        /// </summary>
        /// <returns></returns>
        protected dynamic GetMyInfo()
        {
            return new
            {
                ID = CurrentUser.UserID,
                //Name = CurrentUser.UserName,
                FullName = CurrentUser.FullName,
                Picture = CurrentUser.ProfilePicture
            };
        }
        #endregion

        #region Public Member Function

        #endregion

        #region Static Member Function

        #endregion
    }
}
