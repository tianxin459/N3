using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using N3DB;
using N3DB.Entity;

namespace N3API.API_Entity
{
    public class AdPicturesController : ApiController
    {
        private N3Context db = new N3Context();

        // GET: api/AdPictures
        public IQueryable<AdPicture> GetAdPictures()
        {
            return db.AdPictures;
        }

        // GET: api/AdPictures/5
        [ResponseType(typeof(AdPicture))]
        public async Task<IHttpActionResult> GetAdPicture(int id)
        {
            AdPicture adPicture = await db.AdPictures.FindAsync(id);
            if (adPicture == null)
            {
                return NotFound();
            }

            return Ok(adPicture);
        }

        // PUT: api/AdPictures/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAdPicture(int id, AdPicture adPicture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != adPicture.AdPictureId)
            {
                return BadRequest();
            }

            db.Entry(adPicture).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdPictureExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/AdPictures
        [ResponseType(typeof(AdPicture))]
        public async Task<IHttpActionResult> PostAdPicture(AdPicture adPicture)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.AdPictures.Add(adPicture);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = adPicture.AdPictureId }, adPicture);
        }

        // DELETE: api/AdPictures/5
        [ResponseType(typeof(AdPicture))]
        public async Task<IHttpActionResult> DeleteAdPicture(int id)
        {
            AdPicture adPicture = await db.AdPictures.FindAsync(id);
            if (adPicture == null)
            {
                return NotFound();
            }

            db.AdPictures.Remove(adPicture);
            await db.SaveChangesAsync();

            return Ok(adPicture);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AdPictureExists(int id)
        {
            return db.AdPictures.Count(e => e.AdPictureId == id) > 0;
        }
    }
}