using ExceptionHandler.Common;
using Microsoft.Extensions.Logging;
using System.Windows;

namespace ExceptionHandlerDemo.Handlers;


[HandlesException(typeof(SampleException))]
internal class SampleExceptionHandler : IExceptionHandler
{
    private readonly ILogger<SampleExceptionHandler> logger;

    public SampleExceptionHandler(ILogger<SampleExceptionHandler>  logger)
    {
        //使用了依赖注入，你可以在 构造器 中获取你需要的服务
        this.logger = logger;
    }

    public void HandleException(Exception exception)
    {
        logger.LogError(exception, "SampleExceptionHandler 捕获到异常：{Message}", exception.Message);

        // 这里可以处理 SampleException 异常
        MessageBox.Show("SampleException  异常被捕获了，这里应该处理你要处理的事情");


    }
}
