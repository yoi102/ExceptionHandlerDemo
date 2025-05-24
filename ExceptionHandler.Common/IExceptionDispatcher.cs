namespace ExceptionHandler.Common;
public interface IExceptionDispatcher
{
    bool Dispatch(Exception exception);
}