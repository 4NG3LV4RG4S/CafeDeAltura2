namespace Ixhuatlan.Caracolillo.Frontend.Interfaces.System.Responses;

public interface IProcessResponse
{
    /// <summary>
    /// Resultado del proceso.
    /// </summary>
    ProcessResult ProcessResult { get; set; }

    /// <summary>
    /// Mensaje de éxito del proceso.
    /// </summary>
    string SuccessMessage { get; set; }

    /// <summary>
    /// Mensaje de error del proceso.
    /// </summary>
    string ErrorMessage { get; set; }
}