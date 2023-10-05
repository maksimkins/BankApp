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
    public string Login { get; set; }
    public string Password { get; set; }
    public double Account { get; set; } = 0;
}
