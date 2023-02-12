using DAL.Contacts;
using DAL.Interfaces;

namespace DAL.Catalogs
{
    public class Country : ICatalog
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Region> Regions { get; set; }
    }    
}
