using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FarmaciaApp.Models
{
    public class Medicamento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string NumeroRegistroAnvisa { get; set; }
        public string Nome { get; set; }

        private DateTime _dataValidade;
        public DateTime DataValidade
        {
            get => _dataValidade;
            set => _dataValidade = DateTime.SpecifyKind(value, DateTimeKind.Utc);
        }

        public string TelefoneSAC { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Preco { get; set; }

        public int QuantidadeComprimidos { get; set; }

        public int FabricanteId { get; set; }
        public Fabricante Fabricante { get; set; }

        public ICollection<MedicamentoReacaoAdversa> ReacoesAdversas { get; set; }
    }
}
