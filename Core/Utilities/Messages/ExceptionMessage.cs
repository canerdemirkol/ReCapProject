namespace Core.Utilities.Messages
{
    public static class ExceptionMessage
    {
        public static string InternalServerError => "Something went wrong. Please try again.";
        public static string JwtTokenIsNullOrEmpty => "API methot header JWT token boş geçilemez.";
        public static string JwtTokenCanReadToken => "Girmiş oluğunuz JWT token hatalı. Lütfen kontrol ediniz!";
        public static string DirectoryNotFoundException => "Dosya kayıt işleminde sorun oluştu. Kayıt edilmek istenen dosya yolu bulunamadı.";

    }
}
