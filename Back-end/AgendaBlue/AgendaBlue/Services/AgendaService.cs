using AgendaBlue.Interfaces;
using AgendaBlue.Models;
using AgendaBlue.Repositorys;
using AgendaBlue.Services.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace AgendaBlue.Services
{
    public class AgendaService : IAgendaService
    {
        public readonly IAgendaRepository _repositorio;

        public AgendaService(IAgendaRepository repositorio)
        {
            _repositorio = repositorio;
        }
        

        public async Task Add(AgendaEntity agendaEntity)
        {
            //validação se email, nome e telefone já existem no banco de dados
            var ObjAgenda = await _repositorio.Match(agendaEntity);



            try
            {
                if (ObjAgenda != null)
                {


                    await _repositorio.Add(agendaEntity);






                }

            }
            catch (PadraoException)
            {
                throw new PadraoException("Usuario Já Cadastrado");
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                 

                
                
                    await _repositorio.Delete(id);


               

            }
            catch (PadraoException)
            {
                throw new PadraoException("Usuario não encontrado");
            }

        }

        public async Task<IEnumerable<AgendaEntity>> GetAll()
        {

            try
            {

                return await _repositorio.GetAll();

            }
            catch (PadraoException)
            {
                throw new PadraoException("Usuario não encontrado");
            }

        }

        public async Task<AgendaEntity> GetById(int id)
        {
            try
            {
                return await _repositorio.GetById(id);

            }
            catch (PadraoException)
            {
                throw new PadraoException("Usuario não encontrado");
            }


        }



        public async Task Update(AgendaEntity agendaEntity)
        {
           
           
            try
            {
                await _repositorio.Match(agendaEntity);
                
                
                    await _repositorio.Update(agendaEntity);
                

               


            }
            catch (PadraoException)
            {
                throw new PadraoException("Usuario servico");
            }
        }
    }
}
