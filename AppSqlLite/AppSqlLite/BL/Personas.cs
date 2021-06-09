using System;
using AppSqlLite.Services;
using AppSqlLite.Models;
using AppSqlLite.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppSqlLite.BL
{
    public class Personas : IPersona
    {
        public async Task<bool> Delete(PersonaModel personaModel)
        {
            using (var personaContext = new PersonaContext())
            {
                var tracking = personaContext.Remove(personaModel);
                await personaContext.SaveChangesAsync();
                var isDeleted = tracking.State == EntityState.Deleted;
                return isDeleted;
            }
        }

        public async Task<bool> DeleteAllPersonas()
        {
            using (var personaContext = new PersonaContext())
            {
                personaContext.RemoveRange(personaContext.TBPersona);
                await personaContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<List<PersonaModel>> GetListPersonas()
        {
            using (var personaContext = new PersonaContext())
            {
                return await personaContext.TBPersona.ToListAsync();
            }
        }

        public async Task<PersonaModel> GetPersona(int PersonaId)
        {
            using (var personaContext = new PersonaContext())
            {
                return await personaContext.TBPersona.Where(p => p.IdPersona == PersonaId).FirstOrDefaultAsync();
            }
        }

        public async Task<bool> Insert(PersonaModel personaModel)
        {
            using (var personaContext = new PersonaContext())
            {
                personaContext.Add(personaContext);
                await personaContext.SaveChangesAsync();
            }
            return true;
        }

        public async Task<bool> Update(PersonaModel personaModel)
        {
            using (var personaContext = new PersonaContext())
            {
                var tracking = personaContext.Update(personaModel);
                await personaContext.SaveChangesAsync();

                var isModified = tracking.State == EntityState.Modified;
                return isModified;
            }
        }
    }
}
