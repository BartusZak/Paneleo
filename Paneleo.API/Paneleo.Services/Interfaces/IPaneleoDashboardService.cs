using System.Threading.Tasks;
using Paneleo.Models.ModelDto;
using Paneleo.Models.ModelDto.Dashboard;

namespace Paneleo.Services.Interfaces
{
    public interface IPaneleoDashboardService
    {
        Task<Response<DashboardStatisticsDto>> GetStatisticsAsync();
    }
}