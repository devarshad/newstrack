using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NT.Models;
using NT.Data;
namespace NT.Core
{
    /// <summary>
    /// Access all method used for user opertations
    /// </summary>
    public class User
    {
        #region Private Data Member
        /// <summary>
        /// Data access object
        /// </summary>
        private DataRepository _dr = null;
        #endregion

        #region Public function
        /// <summary>
        /// function to search a user by its username, fullname, email address or phone number
        /// </summary>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        public _IdentityUser FindUser(string searchKey)
        {
            if (!searchKey.Validate())
                return null;
            using (_dr = new DataRepository())
            {
                return _dr.FindUser(searchKey);
            }
        }

        public bool ConfirmEmail(long id)
        {
            if (id <= 0)
                return false;
            using (_dr = new DataRepository())
            {
                return _dr.ConfirmEmail(id);
            }
        }
        #endregion
    }
}
