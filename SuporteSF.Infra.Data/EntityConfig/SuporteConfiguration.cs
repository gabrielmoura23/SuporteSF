using System.Data.Entity.ModelConfiguration;
using SuporteSF.Domain.Entities;

namespace SuporteSF.Infra.Data.EntityConfig
{
    public class SuporteConfiguration : EntityTypeConfiguration<Suporte>
    {
        public SuporteConfiguration()
        {
            ToTable("Tab_Suporte");

            HasKey(c => c.IdSuporte);

            Property(c => c.Descricao)
                .IsRequired()
                .HasMaxLength(null);

            Property(c => c.SistemaOperacional)
                .IsRequired()
                .HasMaxLength(100);

            Property(c => c.ProblemaRecorrente)
                .IsRequired()
                .HasMaxLength(50);
        
            Property(c => c.Prioridade)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.DddTelefone)
                .IsRequired()
                .HasMaxLength(2);

            Property(c => c.Telefone)
                .IsRequired()
                .HasMaxLength(15);

            Property(c => c.MelhorHorarioAtendimento)
                .IsRequired()
                .HasMaxLength(255);

            Property(c => c.Status)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.FlgTermoAceito)
                .IsRequired();

            Property(c => c.DescricaoSolucao)
                .HasMaxLength(null);
             
            Ignore(t => t.ResultadoValidacao);

            // Table & Column Mappings
            //this.ToTable("Tab_Suporte");
            //public int IdSuporte { get; set; }
            //public string Descricao { get; set; }
            //public string SistemaOperacional { get; set; }
            //public string ProblemaRecorrente { get; set; }
            //public string Prioridade { get; set; }
            //public string Email { get; set; }
            //public string DddTelefone { get; set; }
            //public string Telefone { get; set; }
            //public string MelhorHorarioAtendimento { get; set; }
            //public string Status { get; set; }
            //public bool FlgTermoAceito { get; set; }
            //public System.DateTime DtAbertura { get; set; }
            //public int IdUsuarioCadastro { get; set; }
            //public System.Nullable<System.DateTime> DtAlteracao { get; set; }
            //public string GuidUsuarioAlteracao { get; set; }
            //public System.Nullable<System.DateTime> DtAtendimento { get; set; }
            //public System.Nullable<System.DateTime> DtFechamento { get; set; }
            //public string DescricaoSolucao { get; set; }
            //public System.Nullable<decimal> ValorContribuicao { get; set; }
        }
    }
}
