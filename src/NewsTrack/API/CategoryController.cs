using NT.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NewsTrack.API
{
    public class CategoryController : BaseController
    {
        // GET: api/Category
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Category/5
        /// <summary>
        /// get the detail of group with list of category along with the stories.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pageNumber"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id, int pageNumber, int pageSize)
        {
            try
            {
                return Ok(_story.GetStoriesByCategory(id, pageNumber, pageSize));
            }
            catch (Exception ex)
            {
                Logger.Error("Error getting stories list", ex);
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Category
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Category/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Category/5
        public void Delete(int id)
        {
        }
    }
}
