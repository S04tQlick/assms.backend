namespace assms.entities.DTOs.BaseResponseDtos;

public class BaseResponse<T>
{
    public bool Success { get; set; } = true;
    public string? Message { get; set; }
    public T? Data { get; set; }
}