using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiSample.Models;

namespace WebApiSample.Services
{
    public class TareasService : ITareasService
    {
        TareasContext context;

        public TareasService(TareasContext dbContext)
        {
            context = dbContext;
        }

        public IEnumerable<Tarea> Get()
        {
            return context.Tareas;
        }

        public async Task Save(Tarea tarea)
        {
            context.Tareas.Add(tarea);
            await context.SaveChangesAsync();
        }

        public async Task Update(Guid id, Tarea tarea)
        {
            var tareaActual = context.Tareas.Find(id);

            if (tareaActual != null)
            {
                tareaActual.Titulo = tarea.Titulo;
                tareaActual.Descripcion = tarea.Descripcion;
                tareaActual.Resumen = tarea.Resumen;
                tareaActual.FechaCreacion = tarea.FechaCreacion;
                tareaActual.PrioridadTarea = tarea.PrioridadTarea;

                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(Guid id)
        {
            var tareaActual = context.Tareas.Find(id);

            if (tareaActual != null)
            {
                context.Tareas.Remove(tareaActual);
                await context.SaveChangesAsync();
            }
        }
    }

    public interface ITareasService
    {
        IEnumerable<Tarea> Get();
        Task Save(Tarea tarea);
        Task Update(Guid id, Tarea tarea);
        Task Delete(Guid id);
    }
}