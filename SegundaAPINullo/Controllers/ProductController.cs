using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SegundaAPINullo.Data;
using SegundaAPINullo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundaAPINullo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {


        [HttpGet]
        [Route("")]
        //cria um método
        //Não trava a aplicação, e deixa que mais de uma função seja executada simultâneamente
        //define que o método é assíncrono (cada função na sua vez)
        public async Task<ActionResult<List<Product>>> Get(
            [FromServices] DataContext context)
        {

            var products = await context.Products.Include(x => x.Category).AsNoTracking().ToListAsync();

            return products;
           
        }



        [HttpGet]
        [Route("{id:int}")]
        //cria um método
        //Não trava a aplicação, e deixa que mais de uma função seja executada simultâneamente
        //define que o método é assíncrono (cada função na sua vez)
        public async Task<ActionResult<List<Product>>> GetById(
            int id,
            [FromServices] DataContext context)
        {

            var product = await context.Products.Include(x => x.Category).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            return product;
            
        }



        [HttpGet]
        [Route("")]
        //cria um método
        //Não trava a aplicação, e deixa que mais de uma função seja executada simultâneamente
        //define que o método é assíncrono (cada função na sua vez)
        public async Task<ActionResult<List<Product>>> GetByCategory(
            [FromServices] DataContext context,
            int id)
        {

            var products = await context.Products.Include(x => x.Category).AsNoTracking().Where(x => x.CategoryId == id).ToListAsync();

            return products;
           
        }


        [HttpPost]
        [Route("")]
        //cria um método
        //Pega a product(model), referencia, e devolve
        //indica que vai ir uma product no corpo da requisição
        public async Task<ActionResult<List<Product>>> Post(
           [FromBody] Product model,
           [FromServices] DataContext context
           )

        {
            //modelState guarda o estado do modelo passado
            //Pega o cinteúdo do model e verifica se está válido
            if (!ModelState.IsValid)
            {
                //faz a adição
                context.Products.Add(model);
                
                //salva as mudanças
                await context.SaveChangesAsync();
                //retorna o produto
                return Ok(model);
            }
            //caso dê erro
            else
            {
                //da um retorno
                return BadRequest(ModelState);
            }

        }
    }
}
