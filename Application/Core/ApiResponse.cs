namespace Application;

public class ApiResponse<TResponse>
{
    public int StatusCode {get; set;}
    public TResponse Response {get; set;}   
    private string _message = null;
    public string Message { get => _message; set  {
        if (StatusCode == 200) {
            _message = "Operation Finished Successfully";
        }
        else if (StatusCode == 404) {
            _message = "Information Not Found";
        }
        else if (StatusCode == 400) {
            _message = "Error Occured";
        }
    }}
    public static ApiResponse<TResponse> Success(TResponse Result) {
        bool isNull = Result is null;
        if (isNull) {
            Error();
        }
        return new ApiResponse<TResponse> {Response = Result, StatusCode = 200};
    }
    public static ApiResponse<TResponse> Error() {
        return new ApiResponse<TResponse> {StatusCode = 400};
    }
    public static ApiResponse<TResponse> NotFound() {
        return new ApiResponse<TResponse> {StatusCode = 404};
    }
}
