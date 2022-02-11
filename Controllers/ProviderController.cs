using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProdamTest.Data;
using ProdamTest.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace ProdamTest.Controllers
{
    [Route("providers")]
    public class ProviderController : Controller
    {
        private readonly DataContext _context;

        public ProviderController([FromServices] DataContext context)
            => _context = context;   

        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Provider>>> Get()
            => Ok(await _context.Providers.Include(x => x.Company).AsNoTracking().ToListAsync());

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Provider>> GetById(int id)
            => Ok(await _context.Providers.Include(x => x.Company).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id));

        [HttpGet]
        [Route("{name}")]
        public async Task<ActionResult<Provider>> GetByName(string name)
            => Ok(await _context.Providers.Include(x => x.Company).AsNoTracking().FirstOrDefaultAsync(x => x.Name == name));


        [HttpGet]
        [Route("{code}/{isPf:bool}")]
        public async Task<ActionResult<Provider>> GetByCPF(string code, bool isPf)
        {
            if (isPf)
                return Ok(await _context.Providers.Include(x => x.Company).AsNoTracking().FirstOrDefaultAsync(x => x.Cpf == code));

            return Ok(await _context.Providers.Include(x => x.Company).AsNoTracking().FirstOrDefaultAsync(x => x.CNPJ == code));
        }

        [HttpGet]
        [Route("{date:DateTime}")]
        public async Task<ActionResult<Provider>> GetByDate(DateTime date)
            => Ok(await _context.Providers.Include(x => x.Company).AsNoTracking().FirstOrDefaultAsync(x => x.HiringDate == date));


        [HttpPost]
        [Route("")]
        public async Task<ActionResult<List<Provider>>> Post([FromBody] Provider model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            TimeSpan dif = DateTime.Now.Subtract(model.BirthDate);
            if (model.IsPf && (dif.Days/365) < 18)
                return BadRequest(new { message = "Fornecedores pessoa física, menores de idade, não podem ser associados!"});

            try
            {
                _context.Providers.Add(model);
                await _context.SaveChangesAsync();
                return Ok(model);
            }
            catch
            {
                return BadRequest(new { message = "Não foi possível criar um Fornecedor" });
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<ActionResult<List<Provider>>> Put(int id, [FromBody] Provider model)
        {
            if (id != model.Id)
                return NotFound(new { message = "Fornecedor não encontrada" });

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _context.Entry<Provider>(model).State = EntityState.Modified;
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
        public async Task<ActionResult<List<Provider>>> Delete(int id)
        {
            Provider provider = await _context.Providers.FirstOrDefaultAsync(x => x.Id == id);
            if (provider == null)
                return BadRequest(new { message = "Fornecedor não encontrado" });

            try
            {
                _context.Providers.Remove(provider);
                await _context.SaveChangesAsync();
                return Ok(new { message = "Fornecedor removido com sucesso" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível remover a categoria" });
            }
        }
    }
}
