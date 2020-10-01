namespace Core.CrossCuttingConcerns.Logging
{
    public interface ILogger
    {
        void Info(InfoLogDetail logDetail);

        void Error(ErrorLogDetail logDetail);
    }
}