using ProductAppV1.Shared.Dto.UserDto;

namespace UserAppV1.Server.Data.AppService.UserAppService
{
    public interface IUserAppService
    {
        List<UserInfoDto> GetAllUsers();
        Task<UserInfoDto> GetUserById(int id);
        Task<ResponseModel> AddNewUser(CreateUserDto User);
        Task<ResponseModel> UpdateUser(int Id,UpdateUserDto User);
        Task<ResponseModel> DeleteUser(int id);
    }
}
