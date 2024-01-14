namespace MineSweeper.Helper.FunctionsHelper
{
    public class FunctionResult<T>
    {
        public bool IsSuccess { get; set; }
        public IList<FunctionError> Errors { get; set; }
        public T Result { get; set; }

        public static FunctionResult<T> Fail(FunctionError error)
        {
            return Fail(new List<FunctionError> { error });
        }

        public static FunctionResult<T> Fail(List<FunctionError> errors)
        {
            return new FunctionResult<T> { IsSuccess = false, Errors = errors };
        }

        public static FunctionResult<T> Success(T value)
        {
            return new FunctionResult<T> { IsSuccess = true, Result = value };
        }
    }
}
