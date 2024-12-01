using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEx.Application.Incomes.Commands;

public class UpdateIncomeCommand
{
    public int ID { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Source { get; set; }
    public int UserId { get; set; }
}
