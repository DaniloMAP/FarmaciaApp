using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Medicamento
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(14, MinimumLength = 14)]
    public string NumeroRegistroAnvisa { get; set; }

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required]
    public DateTime DataValidade { get; set; }

    [Required]
    [StringLength(13, MinimumLength = 13)]
    public string TelefoneSAC { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Preco { get; set; }

    [Required]
    public int QuantidadeComprimidos { get; set; }

    [Required]
    public int FabricanteId { get; set; }
    public Fabricante Fabricante { get; set; }

    public ICollection<MedicamentoReacaoAdversa> ReacoesAdversas { get; set; }

    
}
