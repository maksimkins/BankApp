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
    public int Id { get; set; }
    //[Unique]
    public string Login { get; set; }
    public string Password { get; set; }
    public decimal Account { get; set; } = 0;

    //private decimal account;
    //public decimal Account
    //{
    //    get => this.account;
    //    set
    //    {
    //        if(this.account + value > 0)
    //            this.account = value;
    //    }
    //}


    //#region CheckPassword
    //private void CheckPassword()
    //{
    //    this.CheckIfPasswordNull();
    //    this.CheckPasswordLength();
    //    this.CheckContainsDigit();
    //    this.CheckContainsCapitalaziedLetter();
    //}

    //private void CheckIfPasswordNull()
    //{
    //    if (string.IsNullOrEmpty(this.Password) || string.IsNullOrWhiteSpace(this.Password))
    //        throw new ArgumentException("Password can't be null");
    //}

    //private void CheckPasswordLength()
    //{
    //    if (this.Password.Length < 5)
    //        throw new ArgumentException("Password length can't be less than 5");
    //}

    //private void CheckContainsDigit()
    //{
    //    bool hasDigit = false;

    //    foreach (char c in this.Password)
    //    {
    //        if (char.IsDigit(c))
    //        {
    //            hasDigit = true;
    //            break;
    //        }
    //    }

    //    if (!hasDigit)
    //        throw new ArgumentException("Password must contain at least one digit");
    //}

    //private void CheckContainsCapitalaziedLetter()
    //{
    //    bool hasCapitalizedLetter = false;

    //    foreach (char c in this.Password)
    //    {
    //        if (char.IsUpper(c))
    //        {
    //            hasCapitalizedLetter = true;
    //            break;
    //        }
    //    }

    //    if (!hasCapitalizedLetter)
    //        throw new ArgumentException("Password must contain at least one capitalized letter");
    //}
    //#endregion
}
