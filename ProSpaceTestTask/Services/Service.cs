using System.Text;
using Microsoft.EntityFrameworkCore;

namespace ProSpaceTestTask.Services;

class Service : IService
{
    private readonly DatabaseContext _db;

    public Service(DatabaseContext db)
    {
        _db = db;
    }

    public string GenerateCustomerCode()
    {
        var number = Random.Shared.Next(9999);
        var year = DateTime.UtcNow.Year;
        return $"{number:0000}-{year:0000}";
    }

    public int GetRoleId()
    {
        return 2;
    }

    public string GenerateItemCode()
    {
        var number1 = Random.Shared.Next(99);
        var number2 = Random.Shared.Next(9999);
        var letter = new string(new[]
        {
            (char)Random.Shared.Next('A', 'Z' + 1),
            (char)Random.Shared.Next('A', 'Z' + 1)
        });
        var number3 = Random.Shared.Next(99);
        return $"{number1:00}-{number2:0000}-{letter}{number3:00}";
    }

    public async Task<long> GetOrderNumber(Guid customerId, CancellationToken cancellationToken)
    {
        var customer = await _db.Customers
            .Include(customer => customer!.Orders)
            .FirstOrDefaultAsync(x => x.Id == customerId, cancellationToken);
        return customer!.Orders.Count + 1;
    }
}