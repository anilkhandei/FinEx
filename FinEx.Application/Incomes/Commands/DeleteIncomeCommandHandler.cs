using FinEx.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinEx.Application.Incomes.Commands;

public class DeleteIncomeCommandHandler
{
    private readonly IIncomeRepository _incomeRepository;

    public DeleteIncomeCommandHandler(IIncomeRepository incomeRepository)
    {
        _incomeRepository = incomeRepository;
    }

    public async Task Handle(DeleteIncomeCommand command)
    {
        await _incomeRepository.DeleteAsync(command.Id);
    }

}
