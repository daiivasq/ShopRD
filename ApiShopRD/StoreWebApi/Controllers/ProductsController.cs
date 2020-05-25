using System;
using System.Collections.Generic;
using System.IO;
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
    public class ProductsController : ControllerBase
    {
        private readonly StoreDBContext _context;

        private readonly IWebHostEnvironment webHostEnvironment;

        public ProductsController(StoreDBContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            try
            {
                return await _context.Products.Where(e=>e!=null).ToListAsync();
            }
            catch (Exception)
            {

                return NotFound();
            }
            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);

                if (product == null)
                    return NotFound();

                return product;
            }
            catch (Exception)
            {

                return NotFound();
            }

        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.Id }, product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return product;
        }

        [HttpGet("name")]
        public async Task<ActionResult<IEnumerable<Product>>> SearchProduct(string name)
        {
            try
            {
                return await _context.Products.Where(e => e.Name.Contains(name)).ToListAsync();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
        [HttpPut("id")]
        public async Task<ActionResult<Product>> PutImageProduct(int id, IFormFile image)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product is null)
                    return NotFound();
                product.Photo ??= new List<Image>();
                string path = await ImagePost(image);
                product.Photo.Add(new Image
                {
                    ImageUrl = path,
                    ImageByte = Encoding.ASCII.GetBytes(path)
                });
                return product;

            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        async Task<string> ImagePost(IFormFile image)
        {
            try
            {
                var upload = Path.Combine($"{webHostEnvironment.WebRootPath}", "Uploads");
                using FileStream stream = new FileStream(Path.Combine(upload, image.FileName), FileMode.Create);
                await image.CopyToAsync(stream);
                return Path.Combine(upload, image.FileName);
            }
            catch (Exception)
            {
                return null;
            }
        }
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
