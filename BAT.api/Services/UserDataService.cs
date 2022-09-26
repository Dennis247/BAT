using BAT.api.Models.Response;
using Microsoft.AspNetCore.Http;

namespace BAT.api.Services
{
    public interface IUserDataService
    {
        Response<string> UploadUserData(IFormFile formFile);
    }


    public class UserDataService : IUserDataService
    {
        public Response<string> UploadUserData(IFormFile formFile)
        {
            throw new NotImplementedException();
        }
    }
}
