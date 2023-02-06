    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgendaBlue.Data;
using AgendaBlue.Models;
using System.Text.RegularExpressions;
using AutoMapper;
using AgendaBlue.Services;
using AgendaBlue.Repositorys;
using AgendaBlue.Interfaces;
using AgendaBlue.Services.Exceptions;

namespace AgendaBlue.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AgendaController : ControllerBase




    {
        private readonly IAgendaService _context;



        public AgendaController(IAgendaService context)
        {
            _context = context;

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AgendaEntity>>> ObterTodos()
        {
            try
            {
                var obj = await _context.GetAll();

                return Ok(obj);



            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpPost]
        public async Task<ActionResult<AgendaEntity>> Cadastrar(AgendaEntity agenda)
        {
            //regex do email (email valido apenas  XXX@dominio.XX)
            string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            Regex regex = new(pattern);
            try
            {
                if (regex.IsMatch(agenda.Email))
                {
                    await _context.Add(agenda);

                    return Ok("Cadastrado com sucesso");


                }
                else
                {
                    return BadRequest("email invlaido");
                }



            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }



    [HttpGet("{id}")]
    public async Task<ActionResult> ObterPorID(int id)
    {
            try
            {
                var obj = await _context.GetById(id);
                return Ok(obj);

            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

    }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Deletar(int id)
        {
            try
            {
                await _context.GetById(id);
                await _context.Delete(id);
                return Ok("Deletado com Sucesso");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }


        [HttpPut("{id}")]
        public async Task<ActionResult<AgendaEntity>> Atualizar(int id, AgendaEntity agenda)
        {                
                   
                       

            //regex do email (email valido apenas  XXX@dominio.XX)
            string pattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

            Regex regex = new(pattern);

           

            try
            {
                await _context.GetById(id);
                
                agenda.ID = id;

                if (regex.IsMatch(agenda.Email))
                {
                    await _context.Update(agenda);

                    return Ok("Cadastrado com sucesso");


                }
                else
                {
                    return BadRequest("email invlaido");
                }



            }
            catch (PadraoException )
            {
                return BadRequest("usuario nao encontrado");
            }


        }




    }

    
}
