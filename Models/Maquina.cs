using System.ComponentModel.DataAnnotations;

namespace IndustrialMonitor.Models;

public class Maquina
{
    public int Id { get; set; }

    [Required]
    public string Nome { get; set; } = string.Empty;

    public StatusMaquina Status { get; set; }

    public double Temperatura { get; set; }

    public DateTime UltimaComunicacao { get; set; }
}
