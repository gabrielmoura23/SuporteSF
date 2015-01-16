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

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Descrição do Problema")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres para o campo [{0}]")]
        [DisplayName("Sistema Operacional")]
        public string SistemaOperacional { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres para o campo [{0}]")]
        [DisplayName("Problema Recorrente?")]
        public string ProblemaRecorrente { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres para o campo [{0}]")]
        [DisplayName("Prioridade")]
        public string Prioridade { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(200, ErrorMessage = "Máximo 200 caracteres para o campo [{0}]")]
        [EmailAddress(ErrorMessage = "Preencha um E-mail válido")]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(2, ErrorMessage = "Máximo 2 caracteres para o campo [{0}]")]
        [DisplayName("DDD Telefone")]
        public string DddTelefone { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(15, ErrorMessage = "Máximo 15 caracteres para o campo [{0}]")]
        [DisplayName("Telefone")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres para o campo [{0}]")]
        [DisplayName("Melhor Horário de Atendimento")]
        public string MelhorHorarioAtendimento { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [MaxLength(50, ErrorMessage = "Máximo 50 caracteres para o campo [{0}]")]
        [DisplayName("Status")]
        public string Status { get; set; }

        [Required(ErrorMessage = "Preencha o campo [{0}]")]
        [DisplayName("Termo Aceito?")]
        public bool FlgTermoAceito { get; set; }

        [ScaffoldColumn(false)]
        [DisplayName("Data de Abertura")]
        public DateTime DtAbertura { get; set; }

        public Guid IdUsuarioCadastro { get; set; }
        public System.Nullable<System.DateTime> DtAlteracao { get; set; }
        public Guid IdUsuarioAlteracao { get; set; }

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