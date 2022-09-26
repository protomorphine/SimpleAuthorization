using System.ComponentModel.DataAnnotations.Schema;

namespace SimpleAuthorization.Core.Entities;

public class Organization
{
    [Column("id")]
    public long Id { get; set; }
    
    [Column("name")]
    public string Name { get; set; }

    public List<User> Users { get; set; }
}