using System.Diagnostics;
using Castle.DynamicProxy;

namespace AutofacInterceptor;

public class TestAsyncTimingInterceptor(ILogger<TestAsyncTimingInterceptor> logger) : AsyncTimingInterceptor
{
    protected override void StartingTiming(IInvocation invocation)
    {
        logger.LogInformation("{invocation.Method.Name}:StartingTiming", invocation);
    }

    protected override void CompletedTiming(IInvocation invocation, Stopwatch stopwatch)
    {
        logger.LogInformation("{invocation.Method.Name}:CompletedTiming:{stopwatch.Elapsed:g}", invocation, stopwatch);
    }
}