using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinstarLab.Db.Entities;

public class CodeValue
{
    /// <summary>
    /// Порядковый номер
    /// </summary>
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    /// <summary>
    /// Код
    /// </summary>
    [Required]
    public int Code { get; set; }

    /// <summary>
    /// Значение
    /// </summary>
    [Required]
    public string Value { get; set; } = null!;
}