namespace BL.DTO.Contacts
{
    public class AddressDto
    {
        /// <summary>
        ///     PK
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        ///     FK: Contact
        /// </summary>
        public int ContactId { get; set; }
        /// <summary>
        ///     FK: Country 
        /// </summary>
        public int CountryId { get; set; }
        /// <summary>
        ///     FK: Region
        /// </summary>
        public int RegionId { get; set; }
        /// <summary>
        ///     FK: State
        /// </summary>
        public int StateId { get; set; }
        /// <summary>
        ///     FK: City
        /// </summary>
        public int CityId { get; set; }
        /// <summary>
        ///     Street reference
        /// </summary>
        public string? Street { get; set; }
        /// <summary>
        ///     House Reference
        /// </summary>
        public string? House { get; set; }
        /// <summary>
        ///     Map latitude
        /// </summary>
        public string? Latitude { get; set; }
        /// <summary>
        ///     Map Longitude
        /// </summary>
        public string? Longitude { get; set; }
    }
}
