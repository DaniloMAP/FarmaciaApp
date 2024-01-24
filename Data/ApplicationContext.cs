using FarmaciaApp.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public DbSet<Medicamento> Medicamentos { get; set; }
    public DbSet<ReacaoAdversa> ReacoesAdversas { get; set; }
    public DbSet<Fabricante> Fabricantes { get; set; }
    public DbSet<MedicamentoReacaoAdversa> MedicamentoReacoesAdversas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuração do relacionamento muitos-para-muitos entre Medicamento e ReacaoAdversa
        modelBuilder.Entity<MedicamentoReacaoAdversa>()
            .HasKey(mr => new { mr.MedicamentoId, mr.ReacaoAdversaId });

        modelBuilder.Entity<MedicamentoReacaoAdversa>()
            .HasOne(mr => mr.Medicamento)
            .WithMany(m => m.ReacoesAdversas)
            .HasForeignKey(mr => mr.MedicamentoId);

        modelBuilder.Entity<MedicamentoReacaoAdversa>()
            .HasOne(mr => mr.ReacaoAdversa)
            .WithMany(r => r.Medicamentos)
            .HasForeignKey(mr => mr.ReacaoAdversaId);
    }
}
