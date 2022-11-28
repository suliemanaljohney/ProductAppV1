using ProductAppV1.Server.Data;
using ProductAppV1.Shared.Dto.UserDto;

namespace UserAppV1.Server.Data.AppService.UserAppService
{
    public class UserAppService:IUserAppService
    {
        private readonly DataContext _dataContext;
        public UserAppService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public List<UserInfoDto> GetAllUsers()
        {
            
            List<UserInfoDto> UsersInfo = new List<UserInfoDto>();

            var res = _dataContext.Users.ToList();

            foreach (var item in res)
            {
                UserInfoDto UserInfo = new UserInfoDto();
                UserInfo.Id = item.Id;
                UserInfo.Username = item.Username;
                UserInfo.Password = item.Password;
                UserInfo.Firstname =item.Firstname;
                UserInfo.Surname= item.Surname;
                UserInfo.Address = item.Address;
                UserInfo.Phone= item.Phone;
                UserInfo.Role= item.Role;   
                UsersInfo.Add(UserInfo);
            }
            return UsersInfo;
        }

        public async Task<UserInfoDto> GetUserById(int id)
        {

            var user = _dataContext.Users.Where(x => x.Id == id).FirstOrDefault();
            
            UserInfoDto UserInfo = new UserInfoDto();
            if (user == null)
            {
                throw new Exception("notfound");
            }
            else
            {
                UserInfo.Id = user.Id;
                UserInfo.Username = user.Username;
                UserInfo.Password = user.Password;
                UserInfo.Firstname = user.Firstname;
                UserInfo.Surname = user.Surname;
                UserInfo.Address = user.Address;
                UserInfo.Phone = user.Phone;
                UserInfo.Role = user.Role;
                
            }
            return UserInfo;
        }
        public async Task<ResponseModel> UpdateUser(int Id, UpdateUserDto User)
        {
            ResponseModel response = new ResponseModel();
            var oldUser = _dataContext.Users.Where(x => x.Id == Id).FirstOrDefault();
            if (User == null)
            {
                throw new Exception("UserNotFound");
            }
            else
            {

                
                oldUser.Username = User.Username;
                oldUser.Password = User.Password;
                oldUser.Firstname = User.Firstname;
                oldUser.Surname = User.Surname;
                oldUser.Address = User.Address;
                oldUser.Email = User.Email;
                oldUser.Phone = User.Phone;
                oldUser.Role = User.Role;
                _dataContext.Users.Update(oldUser);
                _dataContext.SaveChanges();

                response.status = true;
                response.message = " User Updated Successfully ";
                return response;
            }

        }

        public async Task<ResponseModel> AddNewUser(CreateUserDto User)
        {
            ResponseModel response = new ResponseModel();
            User newUser = new User();
            newUser.Username = User.Username;
            newUser.Password = User.Password;
            newUser.Firstname = User.Firstname;
            newUser.Surname = User.Surname;
            newUser.Address = User.Address;
            newUser.Phone = User.Phone;
            newUser.Role = User.Role;

            _dataContext.Users.Add(newUser);
            _dataContext.SaveChanges();

            response.status = true;
            response.message = " User Added Successfully ";
            return response;


        }
        public async Task<ResponseModel> DeleteUser(int id)
        {
            ResponseModel response = new ResponseModel();
            var User = _dataContext.Users.Where(x => x.Id == id).FirstOrDefault();
            if (User == null)
            {
                throw new Exception("UserNotFound");

            }
            else
                _dataContext.Users.Remove(User);
            _dataContext.SaveChanges();

            response.status = true;
            response.message = " User deleted Successfully ";
            return response;


        }
    }
}
