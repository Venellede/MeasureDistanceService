using System.Threading.Tasks;

namespace CTeleport.Distance.Api.Services.Abstract
{
    public interface IMeasureDistanceService
    {
        Task<Model.Distance> GetDistance(string fromAirportCode, string toAirportCode);
    }
}
