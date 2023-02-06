using AgendaBlue.Models;

namespace AgendaBlue.Interfaces
{
    public interface IAgendaService

    {
        Task<IEnumerable<AgendaEntity>> GetAll();
        Task<AgendaEntity> GetById(int id);
        Task Update(AgendaEntity agendaEntity);
        Task Delete(int id);
        Task Add(AgendaEntity agendaEntity);

        
    }

}

