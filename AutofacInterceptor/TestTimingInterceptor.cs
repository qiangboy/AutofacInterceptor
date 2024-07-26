using Castle.DynamicProxy;

namespace AutofacInterceptor;

public class TestTimingInterceptor(TestAsyncTimingInterceptor testAsyncTimingInterceptor) : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        testAsyncTimingInterceptor.ToInterceptor().Intercept(invocation);
    }
}