using DAL.Interfaces;

namespace DAL.Catalogs
{
    public class Region : ICatalog
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<State> States { get; set; } 
    }
    
}
