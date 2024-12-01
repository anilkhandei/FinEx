using FinEx.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEx.Application.Incomes.Commands;

public class UpdateIncomeCommandHandler
{
    private readonly IIncomeRepository _incomeRepository;

    public UpdateIncomeCommandHandler(IIncomeRepository incomeRepository)
    {
        _incomeRepository = incomeRepository;
    }

    public async Task Handle(UpdateIncomeCommand command)
    {
        var income = await _incomeRepository.GetByIdAsync(command.ID);

        if (income != null)
        {
            income.Amount = command.Amount;
            income.Date = command.Date;
            income.Source = command.Source;
            income.UserId = command.UserId;
            await _incomeRepository.UpdateAsync(income);
        }
    }
}
