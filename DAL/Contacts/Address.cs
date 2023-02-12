using DAL.Catalogs;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Contacts
{
    /// <summary>
    ///     Address for contacts
    /// </summary>
    public class Address
    {
        /// <summary>
        ///     PK
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        ///     FK: Contact
        /// </summary>
        [ForeignKey("Contact")]
        public int ContactId { get; set; }
        /// <summary>
        ///     FK: Country 
        /// </summary>
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        /// <summary>
        ///     FK: Region
        /// </summary>
        [ForeignKey("Region")]
        public int RegionId { get; set; }
        /// <summary>
        ///     FK: State
        /// </summary>
        [ForeignKey("State")]
        public int StateId  { get; set; }
        /// <summary>
        ///     FK: City
        /// </summary>
        [ForeignKey("City")]
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

        public virtual Contact Contact { get; set; }
        public virtual Country Country { get; set; }
        public virtual Region Region { get; set; }
        public virtual State State { get; set; }
        public virtual City City { get; set; }
    }
}
