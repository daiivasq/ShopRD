using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreWebApi.Data;
using StoreWebApi.Models;

namespace StoreWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarShopsController : ControllerBase
    {
        private readonly StoreDBContext _context;

        public CarShopsController(StoreDBContext context)
        {
            _context = context;
        }

        // GET: api/CarShops
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarShop>>> GetCarShop()
        {
            List<CarShop> shops = new List<CarShop>();
            var cars = _context.CarShop.Where(e => e != null).Include(e => e.User);
            var product = await cars.Where(e => e != null).Include(e => e.Product).ToListAsync();
            shops.AddRange(product);
            return shops;
        }

        // GET: api/CarShops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarShop>> GetCarShop(int id)
        {
            var carShop = await _context.CarShop.FindAsync(id);

            if (carShop == null)
            {
                return NotFound();
            }

            return carShop;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarShop(int id, CarShop carShop)
        {
            if (id != carShop.Id)
            {
                return BadRequest();
            }

            _context.Entry(carShop).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarShopExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CarShop>> PostCarShop(CarShop carShop)
        {
            try
            {
                if (carShop is null)
                    return StatusCode(409);
                if (carShop.ProductID == 0)
                    return NotFound();
                carShop.Type = TypeShop(carShop.Type);
                carShop.StateOrder = $"{EOrder.InCarShop}";
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCarShop", new { id = carShop.Id }, carShop);
            }
            catch (Exception)
            {

                return StatusCode(409);
            }
           
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<CarShop>> DeleteCarShop(int id)
        {
            var carShop = await _context.CarShop.FindAsync(id);
            if (carShop == null)
            {
                return NotFound();
            }

            _context.CarShop.Remove(carShop);
            await _context.SaveChangesAsync();

            return carShop;
        }
      
        private bool CarShopExists(int id)
        {
            return _context.CarShop.Any(e => e.Id == id);
        }
        string TypeShop(string type) => (EType)Enum.Parse(typeof(EType),type) switch { 
            EType.ShopCard=>$"{EType.ShopCard}",
            EType.WishCard=>$"{EType.WishCard}",
            _             => throw new ArgumentException(message:"Invalid type value.")
        
        };
    }
}
