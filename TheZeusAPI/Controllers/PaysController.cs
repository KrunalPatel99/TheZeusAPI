using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheZeusAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TheZeusAPI.Controllers
{
    [Route("api/[controller]")]
    public class PaysController : Controller
    {
        //connect
        DbModel db;

        public PaysController(DbModel db)
        {
            this.db = db;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<PayInfo> Get()
        {
            return db.PayInfo.ToList();
       
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var PayInfo = db.PayInfo.SingleOrDefault(p => p.PayStubId == id);
            if(PayInfo == null) {
                return NotFound();
            }
            else
            {
                return Ok(PayInfo);
            }
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]PayInfo payInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.PayInfo.Add(payInfo);
                db.SaveChanges();
                return CreatedAtAction("Post", new { id = payInfo.PayStubId }, payInfo);

            }
            
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody]PayInfo payInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                db.Entry(payInfo).State = EntityState.Modified;
                db.SaveChanges();
                return AcceptedAtAction("Put", new { id = payInfo.PayStubId }, payInfo);
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var payInfo = db.PayInfo.SingleOrDefault(p => p.PayStubId == id);
            if(payInfo == null)
            {
                return NotFound();
            }
            else
            {
                db.PayInfo.Remove(payInfo);
                return Ok();
            }
        }
    }
}
