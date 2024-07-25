using Castle.DynamicProxy;

namespace AutofacInterceptor;

public class LoggingAsyncInterceptor(ILogger<LoggingAsyncInterceptor> logger) : AsyncInterceptorBase
{
    protected override async Task InterceptAsync(IInvocation invocation, IInvocationProceedInfo proceedInfo, Func<IInvocation, IInvocationProceedInfo, Task> proceed)
    {
        logger.LogInformation("无返回值方法执行前，方法名：{MethodName}", invocation.Method.Name);

        await proceed(invocation, proceedInfo);

        logger.LogInformation("无返回值方法执行后，方法名：{MethodName}", invocation.Method.Name);
    }

    protected override async Task<TResult> InterceptAsync<TResult>(IInvocation invocation, IInvocationProceedInfo proceedInfo, Func<IInvocation, IInvocationProceedInfo, Task<TResult>> proceed)
    {
        logger.LogInformation("有返回值方法执行前，方法名：{MethodName}", invocation.Method.Name);

        var result = await proceed(invocation, proceedInfo);

        logger.LogInformation("有返回值方法执行后，方法名：{MethodName}", invocation.Method.Name);

        return result;
    }
}