using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebHospital.Controllers
{
    public class ValuesController : ApiController
    {
        HospitalContext db = new HospitalContext();
        // GET api/values
        public IEnumerable<Pacients> Get()
        {
            return db.Pacients;
        }

        // GET api/values/5
        public Pacients Get(string fullname)
        {
            Pacients pac = db.Pacients.Find(fullname);
            return pac;
        }

        [HttpPost]
        // POST api/values
        public void CreatePacients([FromBody] Pacients pacients)
        {
            db.Pacients.Add(pacients);
            db.SaveChanges();
        }

        [HttpPut]
        // PUT api/values/5
        public void EditBook(string fullname, [FromBody] Pacients pacients)
        {
            if(fullname == pacients.fullname)
            {
                db.Entry(pacients).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        [HttpDelete]
        // DELETE api/values/5
        public void Delete(string fullname)
        {
            Pacients pacients = db.Pacients.Find(fullname);
            if(fullname!=null)
            {
                db.Pacients.Remove(pacients);
                db.SaveChanges();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
