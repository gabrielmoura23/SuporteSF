using SuporteSF.Domain.Validation;
using SuporteSF.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuporteSF.Domain.Entities
{
    public class Suporte
    {
        public Suporte()
        {

        }

        public int IdSuporte { get; set; }
        public string Descricao { get; set; }
        public string SistemaOperacional { get; set; }
        public string ProblemaRecorrente { get; set; }
        public string Prioridade { get; set; }
        public string Email { get; set; }
        public string DddTelefone { get; set; }
        public string Telefone { get; set; }
        public string MelhorHorarioAtendimento { get; set; }
        public string Status { get; set; }
        public bool FlgTermoAceito { get; set; }
        public System.DateTime DtAbertura { get; set; }
        public Guid IdUsuarioCadastro { get; set; }
        public System.Nullable<System.DateTime> DtAlteracao { get; set; }
        public Guid IdUsuarioAlteracao { get; set; }
        public System.Nullable<System.DateTime> DtAtendimento { get; set; }
        public System.Nullable<System.DateTime> DtFechamento { get; set; }
        public string DescricaoSolucao { get; set; }
        public System.Nullable<decimal> ValorContribuicao { get; set; }

        public ValidationResult ResultadoValidacao { get; private set; }
        public bool IsValid()
        {
            var fiscal = new SuporteEstaAptoParaCadastroNoSistema();
            ResultadoValidacao = fiscal.Validar(this);
            return ResultadoValidacao.IsValid;
        }
    }
}
