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

        [Required(ErrorMessage = "O número de registro da Anvisa é obrigatório.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O número de registro da Anvisa deve ter 14 caracteres.")]
        public string NumeroRegistroAnvisa { get; set; }

        [Required(ErrorMessage = "O nome do medicamento é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome do medicamento não pode exceder 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A data de validade é obrigatória.")]
        public DateTime DataValidade { get; set; }

        [Required(ErrorMessage = "O telefone do SAC é obrigatório.")]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "O telefone do SAC deve ter 13 caracteres.")]
        public string TelefoneSAC { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Column(TypeName = "decimal(18, 2)")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser maior que zero.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "A quantidade de comprimidos é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A quantidade deve ser pelo menos 1.")]
        public int QuantidadeComprimidos { get; set; }

        [Required(ErrorMessage = "O fabricante é obrigatório.")]
        public int FabricanteId { get; set; }
        public Fabricante Fabricante { get; set; }

        public ICollection<MedicamentoReacaoAdversa> ReacoesAdversas { get; set; }
    }
}
