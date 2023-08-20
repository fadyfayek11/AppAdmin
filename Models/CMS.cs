using System.ComponentModel.DataAnnotations;

namespace App.Admin.Models;

public class CMS
{
    [Key]
    public int Id { get; set; }
    public string Key { get; set; }
    public string Value { get; set; }
}