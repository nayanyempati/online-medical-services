using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using online_medical_services.Entities;
using online_medical_services.Helpers;
using online_medical_services.Interfaces;
using online_medical_services.Models;

namespace online_medical_services.Services
{
    public class AccountService : IAccount
    {
        private Messages _messages = new Messages();
        private Securedata _securedata = new Securedata();
        private MailHelper _mailer = new MailHelper();
        private SessionManagement _sessionManagement = new SessionManagement();

        public async Task<ResponseMessage> ActivateAccount(string activationtoken)
        {
            using (Dbcon _dbcon = new Dbcon())
            {
                var checkUserExist = await _dbcon.Users.FirstOrDefaultAsync(x => x.VerificationLink == activationtoken);
                if (checkUserExist != null)
                {
                    if (checkUserExist.IsAccountVerified == 1)
                    {
                        return new ResponseMessage { Message = _messages.USER_ALREADY_VERIFIED, Status = _messages.FAILED };
                    }
                    else
                    {
                        checkUserExist.IsAccountVerified = 1;
                        _dbcon.SaveChanges();
                        return new ResponseMessage { Message = _messages.USER_ACTIVATION_SUCCESSFULL, Status = _messages.SUCCESS };
                    }
                }
                return new ResponseMessage { Message = _messages.INVALID_EXPIRED_VERIFICATION_TOKEN, Status = _messages.FAILED };
            }
        }

        public async Task<ResponseMessage> Register(UserRegistrationModel register)
        {
            using (Dbcon _dbcon = new Dbcon())
            {
                var checkUserExist = await _dbcon.Users.FirstOrDefaultAsync(x => x.Email == register.Email);
                if (checkUserExist == null)
                {
                    string VerificationLink = Guid.NewGuid().ToString();
                    await _dbcon.Users.AddAsync(new User
                    {
                        AccountStatus="Disable",
                        CreatedOn=DateTime.Now,
                        Email=register.Email,
                        Password= _securedata.hashPassword(register.Password),
                        FirstName=register.Firstname,
                        IsAccountVerified=0,
                        LastName=register.Lastname,
                        LastUpdatedOn=DateTime.Now,
                        Token=shortid.ShortId.Generate(),
                        PasswordResetLink= Guid.NewGuid().ToString(),
                        PasswordResetLinkExpiry=DateTime.Now.AddHours(4),
                        Phone=register.Phone,
                        Photo= "https://www.pngmart.com/files/21/Account-User-PNG-Photo.png",
                        Role="user",
                        VerificationLink= VerificationLink

                    });
                    _dbcon.SaveChanges();
                 
                    _mailer.SendActivationEmail(register.Firstname, register.Email, VerificationLink);
                    return new ResponseMessage { Message = _messages.ACCOUNT_CREATED_SUCCESSFULLY, Status = _messages.SUCCESS };
                }
                return new ResponseMessage { Message = _messages.USER_EXSIST, Status = _messages.FAILED };
            }
        }
    }
}
