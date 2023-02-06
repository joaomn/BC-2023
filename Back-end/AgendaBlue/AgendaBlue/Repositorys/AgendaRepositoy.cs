using AgendaBlue.Data;
using AgendaBlue.Interfaces;
using AgendaBlue.Models;
using AgendaBlue.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace AgendaBlue.Repositorys
{
    public class AgendaRepositoy : IAgendaRepository
    {

        private readonly AGDDbContext _context;

        public AgendaRepositoy(AGDDbContext context)
        {
            _context = context;
        }

        public async Task Add(AgendaEntity agendaEntity)
        {                     
                                       
             await _context.AGD_BLUE.AddAsync(agendaEntity);
             await _context.SaveChangesAsync();              
                      
        }
            

        public async Task Delete(int id)
        {
            var objAgenda = await _context.AGD_BLUE.FindAsync(id);

            if (objAgenda != null) 
            {
                _context.AGD_BLUE.Remove(objAgenda);
                await _context.SaveChangesAsync();
            }
            
        }

        public async Task<AgendaEntity> Found(AgendaEntity agenda)
        {

            var obj =  await _context.AGD_BLUE.AnyAsync(x => x.ID == agenda.ID);

            if (!obj)
            {
                return agenda;

            }

            throw new PadraoException("Usuario não encontrado");


        }

        public async Task<IEnumerable<AgendaEntity>> GetAll()
        {
           return await _context.AGD_BLUE.ToListAsync();
            
        }

        public async Task<AgendaEntity> GetById (int id)
        {
            var agendaEntity = await _context.AGD_BLUE.FindAsync(id);
            if (agendaEntity == null)
            {
                throw new PadraoException("Usuario não encontrado");
            }
            return agendaEntity;
        }

        public async Task<AgendaEntity> Match(AgendaEntity agendaEntity)
        {
            var obj =  await _context.AGD_BLUE.AnyAsync(e => e.Email == agendaEntity.Email
            && e.PhoneNumber == agendaEntity.PhoneNumber
            && e.Nome == agendaEntity.Nome);

            if (!obj)
            {
                return  agendaEntity;
            }

            throw new PadraoException("Usuario já cadastrado");



        }

        public async Task Update(AgendaEntity agendaEntity)
        {
            var agenda =  _context.AGD_BLUE.Find(agendaEntity.ID);                    


           
                if (agenda != null)
                {
                    
                    agenda.Nome = agendaEntity.Nome;
                    agenda.PhoneNumber = agendaEntity.PhoneNumber;
                    agenda.Email = agendaEntity.Email;



                    _context.Entry(agenda).State = EntityState.Modified;
                    
                    await _context.SaveChangesAsync();



                }

                                              

            

            

        }
    }
}
