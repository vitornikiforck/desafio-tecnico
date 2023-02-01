using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database
{
    public class BankAccountContext : DbContext
    {
        public BankAccountContext(DbContextOptions<BankAccountContext> options) : base(options) { }

        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<FinancialMovement> FinancialMovements { get; set; }
        public virtual DbSet<Idempotence> Idempotences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BankAccount>().ToTable("contacorrente");
            modelBuilder.Entity<BankAccount>().HasKey(b => b.Id);
            modelBuilder.Entity<BankAccount>().Property(b => b.Id).HasColumnName("idcontacorrente");
            modelBuilder.Entity<BankAccount>().Property(p => p.Number).HasColumnName("numero").IsRequired();
            modelBuilder.Entity<BankAccount>().Property(p => p.Name).HasColumnName("nome").HasMaxLength(100).IsRequired();
            modelBuilder.Entity<BankAccount>().Property(p => p.Active).HasColumnName("ativo").IsRequired();

            modelBuilder.Entity<FinancialMovement>().ToTable("movimento");
            modelBuilder.Entity<FinancialMovement>().HasKey(b => b.Id);
            modelBuilder.Entity<FinancialMovement>().Property(b => b.Id).HasColumnName("idmovimento");
            modelBuilder.Entity<FinancialMovement>().Property(p => p.BankAccountId).HasColumnName("idcontacorrente").IsRequired();
            modelBuilder.Entity<FinancialMovement>().Property(p => p.Date).HasColumnName("datamovimento").IsRequired();
            modelBuilder.Entity<FinancialMovement>().Property(p => p.MovementType).HasColumnName("tipomovimento").HasMaxLength(1).IsRequired();
            modelBuilder.Entity<FinancialMovement>().Property(p => p.Value).HasColumnName("valor").IsRequired();

            modelBuilder.Entity<FinancialMovement>().HasOne(p => p.BankAccount).WithMany(b => b.FinancialMovements).HasForeignKey(p => p.BankAccountId);

            modelBuilder.Entity<Idempotence>().ToTable("idempotencia");
            modelBuilder.Entity<Idempotence>().HasKey(b => b.Id);
            modelBuilder.Entity<Idempotence>().Property(b => b.Id).HasColumnName("chave_idempotencia");
            modelBuilder.Entity<Idempotence>().Property(p => p.Request).HasColumnName("requisicao").IsRequired();
            modelBuilder.Entity<Idempotence>().Property(p => p.Result).HasColumnName("resultado").IsRequired();

            base.OnModelCreating(modelBuilder);
        }
    }
}
