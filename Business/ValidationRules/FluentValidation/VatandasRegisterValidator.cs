using Business.Helpers;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    //public class VatandasRegisterValidator : AbstractValidator<VatandasForRegisterDto>
    //{
    //    public VatandasRegisterValidator()
    //    {
    //        RuleFor(p => p.FirstName).NotEmpty().WithMessage("Ad boş geçilemez");
    //        RuleFor(p => p.FirstName).MinimumLength(2).WithMessage("Ad en az 2 karekter olmalı");
    //        RuleFor(p => p.LastName).NotEmpty().WithMessage("Soyad boş geçilemez");
    //        RuleFor(p => p.LastName).MinimumLength(2).WithMessage("Soyad en az 2 karekter olmalı");
    //        RuleFor(p => p.Gsm).Must(ValidationExtensions.IsPhoneValid).WithMessage("Lütfen geçerli bir GSM numarsı giriniz."); ;//büyük olmalı
    //     //   RuleFor(p => p.Password).Password(6);
    //        RuleFor(p => p.CitizenId).Must(ValidationExtensions.IsCidValid).WithMessage("Hatalı Tc girdiniz.");
    //    }

    //}

}
