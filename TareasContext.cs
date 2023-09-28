using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiSample.Models;

namespace WebApiSample
{
    public class TareasContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }
        public TareasContext(DbContextOptions<TareasContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /* ModelBuilder table Categoria */
            modelBuilder.Entity<Categoria>(categoria => 
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(c => c.CategoriaId);

                categoria.Property(c => c.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(c => c.Descripcion);
            }); 

            /* ModelBuilder table Tarea */
            modelBuilder.Entity<Tarea>(tarea => 
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(t => t.TareaId);
                
                tarea.HasOne(t => t.Categoria).WithMany(t => t.Tareas).HasForeignKey(t => t.CategoriaId);
                
                tarea.Property(t => t.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(t => t.Descripcion);
                tarea.Property(t => t.PrioridadTarea);
                tarea.Property(t => t.FechaCreacion);
                tarea.Ignore(t => t.Resumen);
            });

        }
    }
}