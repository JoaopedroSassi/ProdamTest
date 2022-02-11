using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdamTest.Data;
using ProdamTest.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProdamTest.Controllers
{
    [Route("companies")]
    public class CompanyController : Controller
    {
        private readonly DataContext _context;

        public CompanyController([FromServices] DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Company>>> Get()
        {
            return Ok(await _context.Companies.AsNoTracking().ToListAsync());
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Company>> GetById(int id)
        {
            return Ok(await _context.Companies.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Company>>> Post([FromBody] Company model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.Companies.Add(model);
                await _context.SaveChangesAsync();
                return Ok(model);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível criar uma Empresa" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Company>>> Put(int id, [FromBody] Company model)
        {
            if (id != model.Id)
                return NotFound(new { message = "Empresa não encontrada" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.Entry<Company>(model).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(model);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível atualizar a Empresa" });
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Company>>> Delete(int id)
        {
            Company company = await _context.Companies.FirstOrDefaultAsync(x => x.Id == id);
            if(company == null)
                return BadRequest(new { message = "Empresa não encontrada" });

            try
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Empresa removida com sucesso" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover a categoria" });
            }
        }
    }
}
