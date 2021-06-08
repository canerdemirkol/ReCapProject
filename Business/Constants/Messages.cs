using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string StringLengthMustBeGreaterThanThree => "StringLengthMustBeGreaterThanThree";
        public static string CouldNotBeVerifyCid => "CouldNotBeVerifyCid";
        public static string VerifyCid => "VerifyCid";
        public static string OperationClaimExists => "OperationClaimExists";
        public static string AuthorizationsDenied => "AuthorizationsDenied";
        public static string Added => "Added";
        public static string Deleted => "Deleted";
        public static string Updated => "Updated";
        public static string UserNotFound => "UserNotFound";
        public static string PasswordError => "PasswordError";
        public static string SuccessfulLogin => "SuccessfulLogin";
        public static string SendMobileCode => "SendMobileCode";
        public static string NameAlreadyExist => "NameAlreadyExist";
        public static string WrongCitizenId => "WrongCID";
        public static string WrongEmail => "WrongEmail";
        public static string WrongGsm => "WrongGsm";
        public static string CitizenNumber => "CID";
        public static string PasswordEmpty => "PasswordEmpty";
        public static string PasswordLength => "PasswordLength";
        public static string PasswordUppercaseLetter => "PasswordUppercaseLetter";
        public static string PasswordLowercaseLetter => "PasswordLowercaseLetter";
        public static string PasswordDigit => "PasswordDigit";
        public static string PasswordSpecialCharacter => "PasswordSpecialCharacter";
        public static string SendPassword => "SendPassword";
        public static string InvalidCode => "InvalidCode";
        public static string SmsServiceNotFound => "SmsServiceNotFound";
        public static string TrueButCellPhone => "TrueButCellPhone";
        public static string TokenProviderException => "TokenProviderException";
        public static string Unknown => "Unknown";
        public static string NewPassword => "NewPassword : ";

        public static string UserAlreadyExists = "Bu kullanıcı zaten mevcut";
        public static string UserNotAllowedToUseAPI = "API erişim izni olmayan kullanıcı.";

        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string VatandasRegistered = "Vatandaş başarıyla kaydedildi";

        public static string AccessTokenCreated = "Access token başarıyla oluşturuldu";

        public static string AuthorizationDenied = "Api method erişim yetkiniz yok";
        public static string DefaultSmsPackageNotFound = "Sms Gönderimi için Default Kurum Bulunamadı";
    }
}
