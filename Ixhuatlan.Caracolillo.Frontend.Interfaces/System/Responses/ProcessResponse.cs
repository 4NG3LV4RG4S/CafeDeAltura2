namespace Ixhuatlan.Caracolillo.Frontend.Interfaces.System.Responses;

public class ProcessResponse : IProcessResponse
{
    public ProcessResult ProcessResult { get; set; } = ProcessResult.Successful;
    public string SuccessMessage { get; set; }
    public string ErrorMessage { get; set; }
}