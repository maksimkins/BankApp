using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank.Models;

public class Client
{
    [Key]
    public int Id { get; set; }
    [MaxLength(20)]
    public string Login { get; set; }
    [MaxLength(20)]
    public string Password { get; set; }
    public double Account { get; set; } = 0;

    public override string ToString() => $"{this?.Login}";
}
