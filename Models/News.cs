using System.ComponentModel.DataAnnotations;

namespace App.Admin.Models;

public class News
{
    [Key]
    public int Id { get; set; }

    public string Title { get; set; }

    public string CoverImagePath { get; set; }

    public string Content { get; set; }

    public DateTime DatePublished { get; set; } = DateTime.Now;
}