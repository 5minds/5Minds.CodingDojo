#define ODATA 
#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductContext _context;

        public ProductsController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
#if ODATA
        [EnableQuery]
#endif
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            return await _context.Products
                .Select(p => ItemToDTO(p))
                .ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(long id)
        {
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return ItemToDTO(product);
        }

        // PUT: api/Products/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(long id, ProductDTO productDTO)
        {
            if (id != productDTO.Id)
            {
                return BadRequest();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            product.Name = productDTO.Name;
            product.UnitPrice = productDTO.UnitPrice;

            //_context.Entry(product).State = EntityState.Modified;

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

        // POST: api/Products
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProductDTO>> CreateProduct(ProductDTO productDTO)
        {
            var product = new Product
            {
                Id = productDTO.Id,
                Name = productDTO.Name,
                UnitPrice = productDTO.UnitPrice
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetProduct", new { id = product.Id }, product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, ItemToDTO(product));
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(long id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(long id)
        {
            return _context.Products.Any(e => e.Id == id);
        }

        private static ProductDTO ItemToDTO(Product product) =>
            new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                UnitPrice = product.UnitPrice
            };
    }
}
