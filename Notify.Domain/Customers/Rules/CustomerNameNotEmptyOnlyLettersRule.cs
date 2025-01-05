using Notify.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Domain.Customers.Rules;

public class CustomerNameNotEmptyOnlyLettersRule(string name) : IBusinessRule
{
    public bool IsBroken() => string.IsNullOrWhiteSpace(name) || !name.All(char.IsLetter);

    public string Message => "Customer name cannot be empty and must contain only letters.";
}
