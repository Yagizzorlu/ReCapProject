using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilites.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)       //attribute a bana validator type ver diyor.Böylece carManager'a typeof(CarValidator) giriyoruz.
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);    //reflection. new'leme işini çalışma anında yapmayı sağlar
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];      //productValidator çalışma tipini bul(AbstractValidator).GenericArgumentlerinden ilkini bul
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);   //parametrelerini bul.Invocation method demek.Methodun parametrelerine bak.Validatorun tipine eşit olan parametreleri bul.
            foreach (var entity in entities)    //Hepsini tek tek gez.
            {
                ValidationTool.Validate(validator, entity);    //Validate et.
            }
        }
    }
}
