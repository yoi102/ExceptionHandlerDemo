using ExceptionHandler.Common;
using System.Windows;

namespace ExceptionHandlerDemo.Handlers;

[HandlesException(typeof(InvalidOperationException))]
internal class InvalidOperationExceptionHandler : IExceptionHandler
{
    public void HandleException(Exception exception)
    {
        MessageBox.Show(exception.Message);

    }
}
