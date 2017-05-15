using _2013215462_ENT;
using _2013215462_PER.EntitiesConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _2013215462_PER
{
    public class DiazDbContext : DbContext
    {
        public DbSet<AdministradorEquipo> AdministradorEquipo { get; set; }
        public DbSet<AdministradorLinea> AdministradorLinea { get; set; }
        public DbSet<CentroAtencion> CentroAtencion { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Direccion> Direccion { get; set; }
        public DbSet<Distrito> Distrito { get; set; }
        public DbSet<EquipoCelular> EquipoCelular { get; set; }
        public DbSet<EstadoEvaluacion> EstadoEvaluacion { get; set; }
        public DbSet<Evaluacion> Evaluacion { get; set; }
        public DbSet<LineaTelefonica> LineaTelefonica { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<TipoEvaluacion> TipoEvaluacion { get; set; }
        public DbSet<TipoLinea> TipoLinea { get; set; }
        public DbSet<TipoPago> TipoPago { get; set; }
        public DbSet<TipoPlan> TipoPlan { get; set; }
        public DbSet<TipoTrabajador> TipoTrabajador { get; set; }
        public DbSet<Trabajador> Trabajador { get; set; }
        public DbSet<Venta> Venta { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AdministradorEquipoConfiguration());
            modelBuilder.Configurations.Add(new AdministradorLineaConfiguration());
            modelBuilder.Configurations.Add(new CentroAtencionConfiguration());
            modelBuilder.Configurations.Add(new ClienteConfiguration());
            modelBuilder.Configurations.Add(new ContratoConfiguration());
            modelBuilder.Configurations.Add(new DepartamentoConfiguration());
            modelBuilder.Configurations.Add(new DireccionConfiguration());
            modelBuilder.Configurations.Add(new DistritoConfiguration());
            modelBuilder.Configurations.Add(new EquipoCelularConfiguration());
            modelBuilder.Configurations.Add(new EstadoEvaluacionConfiguration());
            modelBuilder.Configurations.Add(new EvaluacionConfiguration());
            modelBuilder.Configurations.Add(new LineaTelefonicaConfiguration());
            modelBuilder.Configurations.Add(new PlanConfiguration());
            modelBuilder.Configurations.Add(new ProvinciaConfiguration());
            modelBuilder.Configurations.Add(new TipoEvaluacionConfiguration());
            modelBuilder.Configurations.Add(new TipoLineaConfiguration());
            modelBuilder.Configurations.Add(new TipoPagoConfiguration());
            modelBuilder.Configurations.Add(new TipoPlanConfiguration());
            modelBuilder.Configurations.Add(new TipoTrabajadorConfiguration());
            modelBuilder.Configurations.Add(new TrabajadorConfiguration());
            modelBuilder.Configurations.Add(new VentaConfiguration());
           
            base.OnModelCreating(modelBuilder);

        }
    }
}
