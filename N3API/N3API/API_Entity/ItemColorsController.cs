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
    public class ItemColorsController : ApiController
    {
        private N3Context db = new N3Context();

        // GET: api/ItemColors
        public IEnumerable<ItemColor> GetItemColors()
        {
            return db.ItemColors.ToList();
        }

        // GET: api/ItemColors/5
        [ResponseType(typeof(ItemColor))]
        public async Task<IHttpActionResult> GetItemColor(int id)
        {
            ItemColor itemColor = await db.ItemColors.FindAsync(id);
            if (itemColor == null)
            {
                return NotFound();
            }

            return Ok(itemColor);
        }

        // PUT: api/ItemColors/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutItemColor(int id, ItemColor itemColor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != itemColor.ItemColorId)
            {
                return BadRequest();
            }

            db.Entry(itemColor).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemColorExists(id))
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

        // POST: api/ItemColors
        [ResponseType(typeof(ItemColor))]
        public async Task<IHttpActionResult> PostItemColor(ItemColor itemColor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ItemColors.Add(itemColor);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = itemColor.ItemColorId }, itemColor);
        }

        // DELETE: api/ItemColors/5
        [ResponseType(typeof(ItemColor))]
        public async Task<IHttpActionResult> DeleteItemColor(int id)
        {
            ItemColor itemColor = await db.ItemColors.FindAsync(id);
            if (itemColor == null)
            {
                return NotFound();
            }

            db.ItemColors.Remove(itemColor);
            await db.SaveChangesAsync();

            return Ok(itemColor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemColorExists(int id)
        {
            return db.ItemColors.Count(e => e.ItemColorId == id) > 0;
        }
    }
}