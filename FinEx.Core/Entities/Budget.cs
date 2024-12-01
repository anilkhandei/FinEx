using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEx.Core.Entities;

public class Budget
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public DateTime Month { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}
