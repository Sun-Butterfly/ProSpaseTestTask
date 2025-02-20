using System.Text;

namespace ProSpaceTestTask.Services;

class Service : IService
{
    public string GenerateCustomerCode()
    {
        var number = Random.Shared.Next(1000);
        var year = DateTime.UtcNow.Year;
        return $"{number:0000}-{year:0000}";
    }

    public int GetRoleId()
    {
        return 2;
    }
}