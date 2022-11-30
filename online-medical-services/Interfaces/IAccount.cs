using Microsoft.AspNetCore.Mvc;
using online_medical_services.Models;

namespace online_medical_services.Interfaces
{
    public interface IAccount
    {
        Task<ResponseMessage> ActivateAccount(string activationtoken);
        Task<ResponseMessage> Register(UserRegistrationModel register);
    }
}
