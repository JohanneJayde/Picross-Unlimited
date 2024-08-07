namespace Picross_Unlimited.Api.Helpers;

public class ItemResult
{
    public bool WasSuccessful { get; set; }
    public string? Message { get; set; }
    public ItemResult(bool wasSuccessful, string? message)
    {
        WasSuccessful = wasSuccessful;
        Message = message;
    }
}
