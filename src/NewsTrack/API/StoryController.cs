using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NT.Logging;

namespace NewsTrack.API
{
    public class StoryController : BaseController
    {
        // GET: api/Story
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Story/5
        /// <summary>
        /// get the detail of Story
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(_story.GetStoryByID(id));
            }
            catch (Exception ex)
            {
                Logger.Error("Error getting story detail", ex);
                return BadRequest(ex.Message);
            }
        }

        // POST: api/Story
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Story/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Story/5
        public void Delete(int id)
        {
        }
    }
}
