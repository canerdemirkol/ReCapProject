using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Extensions
{
   public static  class FluentValidationExtensions
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder, int minimumLength = 6)
        {
            var options = ruleBuilder
                .NotEmpty().WithMessage("PasswordEmpty")
                .MinimumLength(minimumLength).WithMessage("PasswordLength")
                .Matches("[A-Z]").WithMessage("PasswordUppercaseLetter")
                .Matches("[a-z]").WithMessage("PasswordLowercaseLetter")
                .Matches("[0-9]").WithMessage("PasswordDigi")
                .Matches("[^a-zA-Z0-9]").WithMessage("PasswordSpecialCharacter");
            return options;
        }
    }
}
