using BL.Interfaces;

namespace BL.DTO
{
    /// <summary>
    ///     Results from request
    /// </summary>
    public class OutputResponse : IOutputResponse
    {
        public OutputResponse()
        {
            Status = "Ok";
            StatusDescription = "Action Completed";
            Results = new List<object> { };
        }
        /// <summary>
        ///     Operation status result
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        ///     Operation result description
        /// </summary>
        public string StatusDescription { get; set; }
        /// <summary>
        ///     Result values
        /// </summary>
        public IList<object> Results { get; set; }
    }
}
