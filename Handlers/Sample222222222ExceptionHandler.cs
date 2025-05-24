using ExceptionHandler.Common;

namespace Handlers;
[HandlesException(typeof(Sample222222222Exception))]
public class Sample222222222ExceptionHandler : IExceptionHandler
{
    public void HandleException(Exception exception)
    {
        // 这里可以处理 Sample222222222Exception 异常
        Console.WriteLine("Sample222222222Exception 异常被捕获了，这里应该处理你要处理的事情");
    }
}
