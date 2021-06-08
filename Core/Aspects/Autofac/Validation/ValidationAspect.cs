using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation.FluentValidationTool;
using Core.Utilities.Interceptors;
using Core.Utilities.Messages;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception ///Aspect
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)//validation type i aliyor parameter olarak
        {
            //defensive coding
            if (!typeof(IValidator).IsAssignableFrom(validatorType))//kullanilan validation bir fluent validation degilse izin verme (IValidator fluent validation type tir)
            {
                throw new System.Exception(AspectMessages.WrongValidationType);
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //calışma anında gelen type göre instance oluşturuyor ve IValidator cast esiyor

            //gelen vaditation ın instance ini oluştur demek (reflaction olarak gelen degerin instance olustur)   
            //örnegin gelen ProductValidator u new le ve insatance ni olustur
            var validator = (IValidator)Activator.CreateInstance(_validatorType);


            // validation ın çalışma tipini istiyor (Validator un Base type ını bul ve generic argumanlarının ilkini bul getir)
            //ProductValidator un base type i varsa olustur.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];


            //buldugun argümanın parametrelerini bul getir (ilgili method un  parametrelerini bul) , parametrelerine bak entity type ına eşit olan parametreleri bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                //validation tool kullanarak validate et
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
