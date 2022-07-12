using System;
using System.Collections.Generic;
using System.Text;

namespace NeSever.User.Infra
{
    public class ErrorCodes
    {
        public const string User_IdRequired = "User_IdRequired";
        public const string User_ErrorWhileGettingData = "User_ErrorWhileGettingData";
        public const string User_PleaseFillAllRequiredFields = "User_PleaseFillAllRequiredFields";
        public const string User_UserIdRequired = "User_UserIdRequired";
        public const string User_RoleIdRequired = "User_RoleIdRequired";
        public const string User_ErrorOccuredWhileUpdatingRecord = "User_ErrorOccuredWhileUpdatingRecord";
        public const string User_ErrorOccuredWhileLoginEmailAndPassword = "User_ErrorOccuredWhileLoginEmailAndPassword";
        public const string User_ErrorOccuredWhileAddingRecord = "User_ErrorOccuredWhileAddingRecord";
        public const string User_TheRecordYouWantToDeleteWasNotFound = "User_TheRecordYouWantToDeleteWasNotFound";
        public const string User_ErrorOccuredWhileProcessingYourRequest = "User_ErrorOccuredWhileProcessingYourRequest";
        public const string User_ErrorOccuredWhileDeletingRefreshToken = "User_ErrorOccuredWhileDeletingRefreshToken";
        public const string User_ErrorWhileGettingUser = "User_ErrorWhileGettingUser";
        public const string User_Login_EmailCanNotBeEmpty = "Identity_Login_EmailCanNotBeEmpty";
        public const string User_Login_PasswordCanNotBeEmpty = "Identity_Login_PasswordCanNotBeEmpty";
        public const string User_Login_UserCouldNotFoundWithEmail = "Identity_Login_UserCouldNotFoundWithEmail";
        public const string User_Login_ThereAreaMoreThanOneUserWithEmail = "Identity_Login_ThereAreaMoreThanOneUserWithEmail";
        public const string User_Login_InvalidPasswordHashAlgorithm = "Identity_Login_InvalidPasswordHashAlgorithm";
        public const string User_Login_WrongPassword = "Identity_Login_WrongPassword";
        public const string User_UserAlreadyHasRole = "Identity_UserAlreadyHasRole";
        public const string User_UserNotFound = "Kullanıcı adı veya şifre yanlış";
        public const string User_UserNotFoundToUpdateRefreshToken = "User_UserNotFoundToUpdateRefreshToken";
        public const string User_EmailIsUsedByAnotherUser = " Bu e-posta adresi ile üye kaydı bulunmaktadır ";
        public const string User_Register_UserHasAlreadyRegisteredWithThisEmail = "Identity_Register_UserHasAlreadyRegisteredWithThisEmail";
        public const string User_LoginInformationIsRequired = "User_LoginInformationIsRequired";
        public const string User_UserTokenIsRequired = "User_TokenIsRequired";
        public const string User_UserTokenIsExpired = "User_UserTokenIsExpired";
        public const string User_ErrorOccuredWhileRefreshingToken= "User_ErrorOccuredWhileRefreshingToken";
        public const string Common_PleaseFillAllRequiredFields = "Gerekli Bütün Alanları Doldurunuz.";

        //TODO buraya dbden kayıt hatası dönerse global bir mesaj dönülecek.
        public const string User_DeleteErrorSaveDb = "Kullanıcı hesabı kapatılırken bir hata alındı. Lütfen daha sonra tekrar deneyin.";
        public const string User_DeleteNullUser = "Kullanıcı hesabı bulunamadı.";
    }

    public class ErrorMessages
    {
        public static Dictionary<string, string> Messages { get; set; }

        static ErrorMessages()
        {
            Messages = new Dictionary<string, string>();
            Messages.Add(ErrorCodes.User_EmailIsUsedByAnotherUser, "Email Adresi ile zaten bir kişi kayıtlıdır.");
        }
        public static bool ContainsKey(string key)
        {
            if (Messages == null || Messages.Count == 0)
                return false;

            return Messages.ContainsKey(key);
        }

        public static string Get(string key)
        {
            if (ContainsKey(key))
                return Messages[key];

            return string.Empty;
        }
    }

}
