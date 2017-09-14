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
    public class ItemSizesController : ApiController
    {
        private N3Context db = new N3Context();

        // GET: api/ItemSizes
        public IQueryable<ItemSize> GetItemSizes()
        {
            return db.ItemSizes;
        }

        // GET: api/ItemSizes/5
        [ResponseType(typeof(ItemSize))]
        public async Task<IHttpActionResult> GetItemSize(int id)
        {
            ItemSize itemSize = await db.ItemSizes.FindAsync(id);
            if (itemSize == null)
            {
                return NotFound();
            }

            return Ok(itemSize);
        }

        // PUT: api/ItemSizes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutItemSize(int id, ItemSize itemSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemSize.ItemSizeId)
            {
                return BadRequest();
            }

            db.Entry(itemSize).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemSizeExists(id))
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

        // POST: api/ItemSizes
        [ResponseType(typeof(ItemSize))]
        public async Task<IHttpActionResult> PostItemSize(ItemSize itemSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ItemSizes.Add(itemSize);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = itemSize.ItemSizeId }, itemSize);
        }

        // DELETE: api/ItemSizes/5
        [ResponseType(typeof(ItemSize))]
        public async Task<IHttpActionResult> DeleteItemSize(int id)
        {
            ItemSize itemSize = await db.ItemSizes.FindAsync(id);
            if (itemSize == null)
            {
                return NotFound();
            }

            db.ItemSizes.Remove(itemSize);
            await db.SaveChangesAsync();

            return Ok(itemSize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemSizeExists(int id)
        {
            return db.ItemSizes.Count(e => e.ItemSizeId == id) > 0;
        }
    }
}