using DAL.Interfaces;

namespace DAL.Catalogs
{
    public class State : ICatalog
    {
        public int Id { get; set; }
        public int RegionId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
    
}
