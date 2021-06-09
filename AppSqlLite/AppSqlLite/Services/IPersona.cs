using System;
using AppSqlLite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AppSqlLite.Services
{
    public interface IPersona
    {
        Task<List<PersonaModel>> GetListPersonas();
        Task<PersonaModel> GetPersona(int PersonaId);
        Task<bool> Insert(PersonaModel personaModel);
        Task<bool> Update(PersonaModel personaModel);
        Task<bool> Delete(PersonaModel personaModel);
        Task<bool> DeleteAllPersonas();
    }
}
