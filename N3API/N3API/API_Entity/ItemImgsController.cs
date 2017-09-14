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
    public class ItemImgsController : ApiController
    {
        private N3Context db = new N3Context();

        // GET: api/ItemImgs
        public IQueryable<ItemImg> GetItemImgs()
        {
            return db.ItemImgs;
        }

        // GET: api/ItemImgs/5
        [ResponseType(typeof(ItemImg))]
        public async Task<IHttpActionResult> GetItemImg(int id)
        {
            ItemImg itemImg = await db.ItemImgs.FindAsync(id);
            if (itemImg == null)
            {
                return NotFound();
            }

            return Ok(itemImg);
        }

        // PUT: api/ItemImgs/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutItemImg(int id, ItemImg itemImg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemImg.ItemImgId)
            {
                return BadRequest();
            }

            db.Entry(itemImg).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemImgExists(id))
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

        // POST: api/ItemImgs
        [ResponseType(typeof(ItemImg))]
        public async Task<IHttpActionResult> PostItemImg(ItemImg itemImg)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ItemImgs.Add(itemImg);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = itemImg.ItemImgId }, itemImg);
        }

        // DELETE: api/ItemImgs/5
        [ResponseType(typeof(ItemImg))]
        public async Task<IHttpActionResult> DeleteItemImg(int id)
        {
            ItemImg itemImg = await db.ItemImgs.FindAsync(id);
            if (itemImg == null)
            {
                return NotFound();
            }

            db.ItemImgs.Remove(itemImg);
            await db.SaveChangesAsync();

            return Ok(itemImg);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemImgExists(int id)
        {
            return db.ItemImgs.Count(e => e.ItemImgId == id) > 0;
        }
    }
}