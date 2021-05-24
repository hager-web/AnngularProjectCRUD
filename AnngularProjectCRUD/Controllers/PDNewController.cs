using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using AnngularProjectCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AnngularProjectCRUD.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PDNewController : ControllerBase
    {

        private readonly PaymentDetailContext _context;

        public PDNewController(PaymentDetailContext context)
        {
            _context = context;
        }

        // GET: api/PDNew/Get
        [HttpPost]
        public JsonResult Get([FromBody] string val)
        {
            //val = val;
            return new JsonResult(new { res=val,_context.PaymentDetails });
            //return new string[] { value1", "value2" };
        }

        // GET: api/PDNew/Get2
        [HttpGet]
        public IEnumerable<string> Get2()
        {
            return new string[] { "value1", "value2","value3" };
        }

        // GET: api/PDNew/GetPaymentDetail
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentDetail>>> GetPaymentDetail()
        {
            return await _context.PaymentDetails.ToListAsync();
        }

        // GET api/PDNew/GetPaymentDetail/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentDetail>> GetPaymentDetail(int id)
        {
            var paymentDetail = await _context.PaymentDetails.FindAsync(id);
            if (paymentDetail == null)
            {
                return NotFound();
            }
            return paymentDetail;
        }

        // GET api/PDNew/Get/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/PDNew/Post
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // POST api/PDNew/PostPaymentDetail
        [HttpPost]
        public async Task<dynamic> PostPaymentDetail([FromForm] string Item)
        {
           JObject obj = JObject.Parse(Item);
            //JToken TokenItem = obj["PaymentDetail"];
            // PaymentDetail pd = obj.ToObject< PaymentDetail>();

            //DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(PaymentDetail));
            //MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(Item));
            //stream.Position = 0;
            //PaymentDetail pd = (PaymentDetail)jsonSerializer.ReadObject(stream);

            //PaymentDetail pd = JsonConvert.DeserializeObject<PaymentDetail>(Item);
            //var Item2 = PaymentDetail(Item)

            PaymentDetail pd = new PaymentDetail();
            pd.CardOwnerName = obj["CardOwnerName"].ToString();
            pd.CardNumber = obj["CardNumber"].ToString();
            pd.ExpirationDate = obj["ExpirationDate"].ToString();
            pd.CVV = obj["CVV"].ToString();
            
            if( obj["PMId"].ToString() == null || obj["PMId"].ToString() == "" || obj["PMId"].ToString() == "0")
            {
                _context.PaymentDetails.Add(pd);
            }
            else
            {
                pd.PMId = int.Parse(obj["PMId"].ToString());
                _context.Entry(pd).State = EntityState.Modified;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            
            var x = CreatedAtAction(nameof(GetPaymentDetail), new { id = pd.PMId }, pd);
            //return CreatedAtAction("GetPaymentDetail", new { id = todoItem.Id }, Item);
            return pd;
        }


        // DELETE api/PDNew/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]string id)
        {

            var todoItem = await _context.PaymentDetails.FindAsync(int.Parse(id));
            if (todoItem == null)
            {
                return NotFound();
            }

            _context.PaymentDetails.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
