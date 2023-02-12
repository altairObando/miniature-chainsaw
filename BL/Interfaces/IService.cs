using BL.DTO;

namespace BL.Interfaces
{
    /// <summary>
    ///     Define el comportamiento de un servicio
    /// </summary>
    public interface IService
    {
        /// <summary>
        ///     Server request
        /// </summary>
        IServiceRequest Request { get; }
        /// <summary>
        ///     Server Response
        /// </summary>
        ServiceResponse Response { get; }
        /// <summary>
        ///     Execute request
        /// </summary>
        Task Execute();
        /// <summary>
        ///     Performs search queries
        /// </summary>
        Task Get();
        /// <summary>
        ///     Execute add entity
        /// </summary>
        Task Add();
        /// <summary>
        ///     Execute update entity
        /// </summary>
        Task Update();
        /// <summary>
        ///     Execute delete entity
        /// </summary>
        Task Delete();
        /// <summary>
        ///     Add rows to result
        /// </summary>
        //void AddResult(dynamic data);
    }
    public interface IServiceRequest
    {
        /// <summary>
        ///     Nombre del comando a ejecutar: ContactService, UserService, MailService...
        /// </summary>
        string? Command { get; }
        /// <summary>
        ///     Accion a ejecutar GET, ADD, DELETE, UPDATE, DELETE
        /// </summary>
        string? Operation { get;}
        /// <summary>
        ///     Datos de entrada para el comando.
        /// </summary>
        string? Entity { get;}
        /// <summary>
        ///     Campos de Seleccion
        /// </summary>
        string? Fields { get; } 
        /// <summary>
        ///     Filtro para las operaciones de consulta
        /// </summary>
        string? Filter { get;}
    }
    public interface IServiceResponse
    {
        IServiceRequest Input { get; }
        OutputResponse Output { get; }
    }
    public interface IOutputResponse
    {
        string Status { get; }
        string StatusDescription { get; }
        IList<object> Results { get; }
    }
}
