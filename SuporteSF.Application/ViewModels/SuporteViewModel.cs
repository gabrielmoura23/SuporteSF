using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SuporteSF.Application.ViewModels
{
    public class SuporteViewModel
    {
        public SuporteViewModel()
        {
            
        }

        [Key]
        public int IdSuporte { get; set; }

        [Required(ErrorMessage = "Preencha o campo Descrição")]
        [MinLength(10, ErrorMessage = "Mínimo {0} caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo Sistema Operacional")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Sistema Operacional")]
        public string SistemaOperacional { get; set; }

        [Required(ErrorMessage = "Preencha o campo Problema Recorrente")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Problema Recorrente?")]
        public string ProblemaRecorrente { get; set; }

        [Required(ErrorMessage = "Preencha o campo Prioridade")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Prioridade")]
        public string Prioridade { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-mail")]
        [MaxLength(200, ErrorMessage = "Máximo {0} caracteres")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [MaxLength(2, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("DDD Telefone")]
        public string DddTelefone { get; set; }

        [MaxLength(15, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Preencha o campo Melhor Horário de Atendimento")]
        [MaxLength(255, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Melhor Horário de Atendimento")]
        public string MelhorHorarioAtendimento { get; set; }

        [Required(ErrorMessage = "Preencha o campo Status")]
        [MaxLength(50, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("Status")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Preencha o campo Termo Aceito")]
        [DisplayName("Termo Aceito?")]
        public bool FlgTermoAceito { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Data de Abertura")]
        public DateTime DtAbertura { get; set; }

        public int IdUsuarioCadastro { get; set; }
        public System.Nullable<System.DateTime> DtAlteracao { get; set; }
        public Guid GuidUsuarioAlteracao { get; set; }

        [DisplayName("Data de Atendimento")]
        public System.Nullable<System.DateTime> DtAtendimento { get; set; }

        [DisplayName("Data de Fechamento")]
        public System.Nullable<System.DateTime> DtFechamento { get; set; }

        [DisplayName("Descrição da Solução")]
        public string DescricaoSolucao { get; set; }

        [DisplayName("Valor da Contribuição")]
        public System.Nullable<decimal> ValorContribuicao { get; set; }
    }
}