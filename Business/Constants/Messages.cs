using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages 
    {
        public static string BrandAdded = "Marka eklendi.";
        public static string BrandUpdated = "Marka güncellendi";
        public static string BrandDeleted = "Marka silindi";
        public static string BrandNameInvalid = "Marka ismi geçersiz";


        public static string MaintenanceTime = "Sistem bakımda.";

        public static string CarAdded = "Araba eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string CarUpdated = "Araba güncellendi";
        public static string CarDeleted = "Araba silindi";

        public static string ColorAdded = "Renk eklendi";
        public static string ColorNameInvalid = "Renk ismi geçersiz";
        public static string ColorUpdated = "Renk güncellendi";
        public static string ColorDeleted = "Renk silindi";

        public static string CarImageAdded  = "Araba fotoğrafı eklendi";
        public static string CarImageUpdated = "Araba fotoğrafı güncellendi";
        public static string CarImageDeleted = "Araba fotoğrafı silindi.";

        public static string CustomerAdded =  "Müşteri eklendi.";
        public static string CustomerUpdated = "Müşteri güncellendi.";
        public static string CustomerDeleted = "Müşteri silindi.";

        public static string ModelAdded = "Model eklendi";
        public static string ModelUpdated = "Model güncellendi";
        public static string ModelDeleted = "Model silindi";

        public static string RentalAdded =  "Kiralama eklendi.";
        public static string RentalUpdated = "Kiralama güncellendi";
        public static string RentalDeleted = "Kiralama silindi.";
        public static string RentalIsInvalid = "Kiralama geçersiz.";

        public static string UserAdded = "Kullanıcı eklendi";
        public static string BrandLimitExceeded = "Marka limiti aşıldı.";
        public static string BrandNameExists = "Bu marka adı bulunmaktadır.";
        public static string CarImageNotExist = "Araba fotoğrafı mevcut değil.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string AccessTokenCreated = "Token oluşturuldu.";
        public static string UserAlreadyExists = "Kullanıcı mevcut";
        public static string LoginSucceeded = "Giriş başarılı.";
        public static string PasswordInvalid = "Şifre hatası";
        public static string AuthorizationDenied = "Yetki geçersiz.";
        public static string UserOperationClaimAdded = "Kullanıcı operasyon yapısı eklendi.";
        public static string UserOperationClaimDeleted = "Kullanıcı operasyon yapısı silindi.";
        public static string UserOperationClaimUpdated = "Kullanıcı operasyon yapısı güncellendi.";
        public static string OperationClaimAdded = "Operasyon yapısı eklendi.";
        public static string OperationClaimDeleted = "Operasyon yapısı silindi.";
        public static string OperationClaimUpdated = "Operasyon yapısı güncellendi.";
    }
}
