using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        //invocation : business method
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }

        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);//method calismadan once
            try
            {
                invocation.Proceed();//method calisiyor burda
                var result = invocation.ReturnValue as Task;
                if (result != null)
                    result.Wait();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);//hataaninda calissin
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);//method basarili oldugunda
                }
            }
            OnAfter(invocation);//method calisip bittikten sonra
        }

    }
}
