using DAL.Interfaces;

namespace DAL.Catalogs
{
    public class City : ICatalog
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual Region Region { get; set; }
    }
}
