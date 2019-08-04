using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ProfileAPI.Models;

namespace ProfileAPI.Controllers
{
    public class UsersContactDetailsController : ApiController
    {
        private ProfileAPIContext db = new ProfileAPIContext();

        // GET: api/UsersContactDetails
        public IQueryable<ContactDetails> GetContactDetails()
        {
            ContactDetails contactDetails = new ContactDetails();
            return db.ContactDetails;
        }

        // GET: api/UsersContactDetails/5
        [ResponseType(typeof(ContactDetails))]
        public IHttpActionResult GetContactDetails(int id)
        {
            ContactDetails contactDetails = db.ContactDetails.Find(id);
            if (contactDetails == null)
            {
                return NotFound();
            }

            return Ok(contactDetails);
        }

        // PUT: api/UsersContactDetails/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutContactDetails(int id, ContactDetails contactDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != contactDetails.Id)
            {
                return BadRequest();
            }

            db.Entry(contactDetails).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContactDetailsExists(id))
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

        // POST: api/UsersContactDetails
        [ResponseType(typeof(ContactDetails))]
        public IHttpActionResult PostContactDetails(ContactDetails contactDetails)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ContactDetails.Add(contactDetails);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = contactDetails.Id }, contactDetails);
        }

        // DELETE: api/UsersContactDetails/5
        [ResponseType(typeof(ContactDetails))]
        public IHttpActionResult DeleteContactDetails(int id)
        {
            ContactDetails contactDetails = db.ContactDetails.Find(id);
            if (contactDetails == null)
            {
                return NotFound();
            }

            db.ContactDetails.Remove(contactDetails);
            db.SaveChanges();

            return Ok(contactDetails);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ContactDetailsExists(int id)
        {
            return db.ContactDetails.Count(e => e.Id == id) > 0;
        }
    }
}