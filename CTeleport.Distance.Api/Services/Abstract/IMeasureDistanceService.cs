using System.Threading.Tasks;

namespace CTeleport.Distance.Api.Services.Abstract
{
    public interface IMeasureDistanceService
    {
        Task<double> GetDistance(string fromAirportCode, string toAirportCode);
    }
}
