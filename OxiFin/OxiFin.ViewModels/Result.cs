using System;

namespace OxiFin.ViewModels
{
    [Serializable]
    public abstract class BaseResult
    {
        public string Message { get; set; }
        public bool HasError { get; set; }

        public BaseResult()
        {
            HasError = false;
        }

        public BaseResult(string message, bool hasError)
        {
            Message = message;
            HasError = hasError;
        }

        public BaseResult(string message)
        {
            Message = message ?? "The system could not process this request";
            HasError = true;
        }
    }

    public class ResultApp : BaseResult
    {
        public object Object { get; set; }

        public ResultApp(object result) : base()
        {
            Object = result;
        }

        public ResultApp(string message, bool hasError, object result) : base(message, hasError)
        {
            Object = result;
        }
    }

    public class BouncerResult<T> : BaseResult where T : class
    {
        public T Object { get; set; }

        public BouncerResult(T result) : base()
        {
            Object = result;
        }

        public BouncerResult(string message, bool hasError, T result) : base(message, hasError)
        {
            Object = result;
        }        
    }
}
