using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NT.Core;
using NT.Logging;
namespace NewsTrack.API
{
    public class GroupController : BaseController
    {
        // GET: api/Group
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Group/5
        /// <summary>
        /// Get detail of category with the list of stories bvelogs to it.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id, int pageNumber, int pageSize)
        {
            try
            {
                return Ok(_story.GetStoriesByGroup(id, pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                Logger.Error("Error getting categories list", ex);
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Group
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Group/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Group/5
        public void Delete(int id)
        {
        }
    }
}
