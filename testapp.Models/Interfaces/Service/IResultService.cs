using testapp.Models.DbModels;
using testapp.Models.DtoModels;

namespace testapp.Models.Interfaces.Service
{
    public interface IResultService : IService<Results, ResultDto, Results, Results, Guid>
    {
        List<ResultDto> GetbyUserId(string? userid);
    }
}
