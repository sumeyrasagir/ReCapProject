﻿using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
   public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductPrice = "Ürünün fiyatı 0'dan büyük olmalıdır";
        public static string ProductDeleted = "Ürün silindi";
        public static string ProductUpdated = "Ürün güncellendi";
        public static string TimeError = "Araç henüz teslim edilmemiş";
        public static string CarRented = "Araç kiralandı";
        public static string CarImageAdded = "Araç resmi eklendi";
        public static string CarImageLimitExceded = "Bu aracın resim kapasitesi dolu";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string AccessTokenCreated = "Access token oluşturuldu";
        public static string UserAlreadyExists ="Kullanıcı mevcut";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string PasswordError = "Hatalı şifre";
        public static string UserNotFound= "Kullanıcı bulunamadı";
        internal static string UserRegistered = "Kullanıcı kayıt edildi";
    }
}
