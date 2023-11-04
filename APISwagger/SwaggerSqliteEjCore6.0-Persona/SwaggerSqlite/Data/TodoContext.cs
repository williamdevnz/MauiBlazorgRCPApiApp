using Microsoft.EntityFrameworkCore;
using SwaggerSqlite.Domain;
using System.Linq.Expressions;

namespace SwaggerSqlite.Data
{
    public class TodoContext<T> : DbContext where T : class
    {
        public DbSet<T> DbSet { get; set; }

        //public DbSet<Empleados> Empleados { get; set; }
        //public DbSet<Departamentos> Departamentos { get; set; }


        public TodoContext(DbContextOptions<TodoContext<T>> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aquí especifica el nombre de la tabla para la entidad T
            modelBuilder.Entity<T>().ToTable(typeof(T).Name);

            base.OnModelCreating(modelBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    // Por ejemplo, si Empleados y Departamentos tienen propiedades adicionales,
        //    // puedes configurar sus relaciones aquí.

        //    if (typeof(T) == typeof(Empleados))
        //    {
        //        // Configuraciones específicas para Empleados
        //        modelBuilder.Entity<Empleados>().HasIndex(e => e.IdEmpleado);
        //    }
        //    else if (typeof(T) == typeof(Departamentos))
        //    {
        //        // Configuraciones específicas para Departamentos
        //        modelBuilder.Entity<Departamentos>().HasIndex(d => d.IdDepto);
        //    }

        //    // Otras configuraciones comunes para todas las entidades

        //    base.OnModelCreating(modelBuilder);
        //}

        public async Task MigrateDatabaseAsync()
        {
            try
            {
                await Database.MigrateAsync();
            }
            catch (Exception ex)
            {
                // Manejar excepciones si es necesario
                Console.WriteLine(ex.Message);
            }
        }

        public async Task AddAsync(T entity)
        {
            await DbSet.AddAsync(entity);
        }

        public void Update(T entity)
        {
            DbSet.Attach(entity);
            Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            DbSet.Remove(entity);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<List<T>> FindByAsync(Expression<Func<T, bool>> predicate)
        {
            return await DbSet.Where(predicate).ToListAsync();
        }


    }

    //public class TodoContext : TodoContext<object>
    //{
    //    public DbSet<Empleados> Empleados { get; set; }
    //    public DbSet<Departamentos> Departamentos { get; set; }
    //    public TodoContext(DbContextOptions<TodoContext<object>> options) : base(options)
    //    {
    //    }
    //}
}
