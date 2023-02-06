using AgendaBlue.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaBlue.Interfaces
{
    public interface IAgendaRepository
    {
        Task<IEnumerable<AgendaEntity>> GetAll();
        Task<AgendaEntity> GetById(int id);
        Task Update( AgendaEntity agendaEntity);
        Task Delete(int id);
        Task Add(AgendaEntity agendaEntity);

        Task<AgendaEntity> Match(AgendaEntity agendaEntity);
        Task<AgendaEntity> Found(AgendaEntity agenda);
    }
}
