using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AnngularProjectCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnngularProjectCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentDetailsController : ControllerBase
    {

        private readonly PaymentDetailContext _context;

        public PaymentDetailsController(PaymentDetailContext context)
        {
            _context = context;
        }
        // GET: api/PaymentDetails
        [HttpGet]
        public async Task<JsonResult> GetPaymentDetail()
        {
            return new JsonResult( await _context.PaymentDetails.ToListAsync());
        }

        // GET api/PaymentDetails/5
        [HttpGet("{id}")]
        public async Task<JsonResult> GetPaymentDetail(int id)
        {
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);
            if (paymentDetail==null)
            {
                return new JsonResult( NotFound());
            }
            return new JsonResult( paymentDetail);
        }

        // POST: api/PaymentDetails
        [HttpPost]
        public async Task<JsonResult> PostPaymentDetail(PaymentDetail Item)
        {
            _context.PaymentDetails.Add(Item);
            await _context.SaveChangesAsync();
            //return CreatedAtAction("GetPaymentDetail", new { id = todoItem.Id }, Item);
            return new JsonResult(new { id = Item.PMId , Item });
        }

        // PUT api/<PaymentDetailsController>/5
        [HttpPut("{id}")]

        public async Task<JsonResult> PutPaymentDetail(int id, PaymentDetail Item)
        {
            if (id != Item.PMId)
            {
                return new JsonResult(BadRequest());
            }

            _context.Entry(Item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.PaymentDetails.Any(p => p.PMId == id))
                {
                    
                    return new JsonResult( NotFound());
                }
                else
                {
                    throw;
                }
            }

            return new JsonResult( NoContent());
        }


        // DELETE api/<PaymentDetailsController>/5
        [HttpDelete("{id}")]
        public async Task<JsonResult> DeletePaymentDetail(int id)
        {
            var todoItem = await _context.PaymentDetails.FindAsync(id);
            if (todoItem == null)
            {
                return  new JsonResult(NotFound());
            }

            _context.PaymentDetails.Remove(todoItem);
            await _context.SaveChangesAsync();

            return  new JsonResult(NoContent());
        }
    }
}
