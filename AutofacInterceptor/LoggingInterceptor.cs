using Castle.DynamicProxy;

namespace AutofacInterceptor;

public class LoggingInterceptor(LoggingAsyncInterceptor loggingAsyncInterceptor) : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        loggingAsyncInterceptor.ToInterceptor().Intercept(invocation);
    }
}