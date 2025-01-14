namespace CLINICAL.UseCase.Commons.Bases;

public class BaseResponse<T>
{
    public bool IsSucces { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public IEnumerable<BaseError>? Errors { get; set; }
}