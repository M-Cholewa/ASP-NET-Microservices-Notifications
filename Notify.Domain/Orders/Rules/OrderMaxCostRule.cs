using Notify.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notify.Domain.Orders.Rules;

public class OrderMaxCostRule(IReadOnlyCollection<OrderProduct> orderProducts) : IBusinessRule
{
    public bool IsBroken() => orderProducts.Sum(p => p.UnitPrice * p.Quantity) > 15000;
    public string Message => "Order cost cannot exceed 15000.";
}
