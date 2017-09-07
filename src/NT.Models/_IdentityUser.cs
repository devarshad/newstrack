using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NT.Models
{
    public class _IdentityUser
    {
        /// <summary>
        /// user id(primary key)
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// user full name
        /// </summary>
        public string Fullname { get; set; }
        /// <summary>
        /// user email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// user phone number
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
