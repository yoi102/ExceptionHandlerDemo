namespace ExceptionHandler.Common;

internal class ExceptionDispatcher : IExceptionDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public ExceptionDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public bool Dispatch(Exception exception)
    {
        var exType = exception.GetType();

        // 支持多态匹配（Optional）
        var handlerType = ExceptionHandlerRegistryExtensions.ExceptionHandlerMap
            .FirstOrDefault(kv => kv.Key.IsAssignableFrom(exType)).Value;

        //则尝试匹配对应的处理器类型
        if (handlerType != null)
        {
            var handler = (IExceptionHandler)_serviceProvider.GetService(handlerType)!;
            handler.HandleException(exception);
            return true;
        }

        //可以不做下面的，没有找到对应的处理器类型就不处理异常

        //如果没有找到对应的处理器类型，则抛出异常
        //else
        //{
        //    throw new InvalidOperationException($"No handler found for exception type: {exType.FullName}");
        //}
        return false;
    }
}