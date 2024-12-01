using FinEx.Core.Entities;
using FinEx.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEx.Application.Incomes.Commands;

public class AddIncomeCommandHandler
{
    private readonly IIncomeRepository _incomeRepository;

    public AddIncomeCommandHandler(IIncomeRepository incomeRepository)
    {
        _incomeRepository = incomeRepository;
    }

    public async Task Handle(AddIncomeCommand command)
    {
        var income = new Income
        {
            Amount = command.Amount,
            Date = command.Date,
            Source = command.Source,
            UserId = command.UserId,
        };

        await _incomeRepository.AddAsync(income);
    }
}
