using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace FarmaciaApp.Models;

public class ReacaoAdversa
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Descricao { get; set; }
    public ICollection<MedicamentoReacaoAdversa> Medicamentos { get; set; }

}
