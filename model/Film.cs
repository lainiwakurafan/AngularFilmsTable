using System;
using System.ComponentModel.DataAnnotations;

public class Film
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MinLength(4)]
    public string Title { get; set; }
    [Required]
    [MinLength(4)]
    public string Directors { get; set; }
    [Required]
    public int Year { get; set; }
    public bool Watched { get; set; }
}