using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using prs_server_net6_c37.Models;
using prs_server_net6_c37.ViewModels;

namespace prs_server_net6_c37.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase {
        private readonly PrsContext _context;

        public VendorsController(PrsContext context) {
            _context = context;
        }

        // GET: api/Vendors/Po/5
        [HttpGet("po/{id}")]
        public async Task<ActionResult<Po>> GetPoForVendor(int id) {
            if (_context.Vendors == null) {
                return NotFound();
            }
            Po po = new();
            // get the vendor
            po.Vendor = await _context.Vendors.FindAsync(id);
            // get all the requirestlines
            var rawPolines = from v in _context.Vendors
                             join p in _context.Products
                                 on v.Id equals p.VendorId
                             join l in _context.Requestlines
                                 on p.Id equals l.ProductId
                             join r in _context.Requests
                                 on l.RequestId equals r.Id
                             where v.Id == id && r.Status == "APPROVED"
                             select new {
                                 Poline = new Poline {
                                     Product = p.Name, PartNbr = p.PartNbr, Price = p.Price, Quantity = l.Quantity
                                 }
                             };
            po.Polines = from p in rawPolines
                         group p by p.Poline.Product into pogrp
                         orderby pogrp.Key
                         select new Poline {
                             Product = pogrp.Key,
                             PartNbr = pogrp.First().Poline.PartNbr,
                             Price = pogrp.First().Poline.Price,
                             Quantity = pogrp.Sum(x => x.Poline.Quantity)
                         };
            po.PoTotal = po.Polines.Sum(x => x.LineTotal);
            return po;
        }

        // GET: api/Vendors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vendor>>> GetVendors() {
            if (_context.Vendors == null) {
                return NotFound();
            }
            return await _context.Vendors.ToListAsync();
        }

        // GET: api/Vendors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vendor>> GetVendor(int id) {
            if (_context.Vendors == null) {
                return NotFound();
            }
            var vendor = await _context.Vendors.FindAsync(id);

            if (vendor == null) {
                return NotFound();
            }

            return vendor;
        }

        // PUT: api/Vendors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVendor(int id, Vendor vendor) {
            if (id != vendor.Id) {
                return BadRequest();
            }

            _context.Entry(vendor).State = EntityState.Modified;

            try {
                await _context.SaveChangesAsync();
            } catch (DbUpdateConcurrencyException) {
                if (!VendorExists(id)) {
                    return NotFound();
                } else {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Vendors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vendor>> PostVendor(Vendor vendor) {
            if (_context.Vendors == null) {
                return Problem("Entity set 'PrsContext.Vendors'  is null.");
            }
            _context.Vendors.Add(vendor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVendor", new { id = vendor.Id }, vendor);
        }

        // DELETE: api/Vendors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendor(int id) {
            if (_context.Vendors == null) {
                return NotFound();
            }
            var vendor = await _context.Vendors.FindAsync(id);
            if (vendor == null) {
                return NotFound();
            }

            _context.Vendors.Remove(vendor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VendorExists(int id) {
            return (_context.Vendors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
