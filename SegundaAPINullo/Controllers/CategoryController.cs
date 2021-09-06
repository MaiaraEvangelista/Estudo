using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SegundaAPINullo.Data;
using SegundaAPINullo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SegundaAPINullo.Controllers
{
    //define uma rota específica
    [Route("categories")]
    [ApiController]

    //cria a controller  e herda da base
    public class CategoryController : ControllerBase
    {
        //[HttpGet]
        //[Route("")]
        //cria um método
        //Não trava a aplicação, e deixa que mais de uma função seja executada simultâneamente
        //public Task Get()
        //{
        //    //da um retorno
        //    return "GET";
        //}

        [HttpGet]
        [Route("")]
        //cria um método
        //Não trava a aplicação, e deixa que mais de uma função seja executada simultâneamente
       //define que o método é assíncrono (cada função na sua vez)
        public async Task<ActionResult<List<Category>>> Get()
        {
            //da um retorno
            return new List<Category>();
        }


        [HttpGet]
        // id:int = define um parâmetro de busca, apenas os números inteiros
        [Route("{id: int}")]
        //cria um método
        public async Task<ActionResult<Category>> GetById(int id)
        {
            //da um retorno
            return new Category();
        }

        [HttpPost]
        [Route("")]
        //cria um método
        //Pega a category(model), referencia, e devolve
       //indica que vai ir uma categoria no corpo da requisição
        public async Task<ActionResult<List<Category>>> Post(
            [FromBody]Category model,
            [FromServices] DataContext context
            )
            
        {
            //modelState guarda o estado do modelo passado
            //Pega o cinteúdo do model e verifica se está válido
            if (!ModelState.IsValid)
            {
                //Se não for válido, retorna um erro
                return BadRequest(ModelState);
            }

            //tentativa de criação/inserção no banco
            try
            {
                //adicionando uma categoria
                context.Categories.Add(model);
                //guarda os "dados"
                await context.SaveChangesAsync();
                //da um retorno de confirmação
                return Ok(model);
            }
            //caso dê erro
            catch (Exception)
            {
                //passa a mensagem
                return BadRequest(new { message = "Não foi possível criar a categoria!" });
            }
          
        }


        [HttpPut]
        [Route("{id:int}")]
        //cria um método
        public async Task<ActionResult<List<Category>>> Put(int id, 
            [FromBody]Category model,
            [FromServices] DataContext context)
        {
            //da um retorno
            //Verifica se o id informado é o mesmo de um modelo existente
            if (id != model.Id)
            {
                //Caso não seja, retorna uma mensgem de erro
                //new =  traz a possibilidade de criação de objetos dinâmicos
                return NotFound(new { message = "Categoria não encontrada!" });
            }

            //Faz a verificação de validamento de dados
            if (!ModelState.IsValid)
            {
                //Caso n sejam retorna um erro
                return BadRequest(ModelState);
            }

            //tentativa de atualização
            try
            {
                context.Entry<Category>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return Ok(model);
            }
            //caso dê erro
            catch (DbUpdateConcurrencyException)
            {
                //mostra a mensagem de erro
                return BadRequest(new { message = "Não foi possível fazer atualização" });
            }
          
        }


        [HttpDelete]
        [Route("{id:int}")]
        //cria um método
        public async Task<ActionResult<List<Category>>> Delete(
            [FromServices]DataContext context
            )
        {

            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);


            //da um retorno
            return Ok();
        }
    }
}
