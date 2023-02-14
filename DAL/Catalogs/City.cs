using DAL.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Catalogs
{
    public class City : ICatalog
    {
        public int Id { get; set; }
        [ForeignKey("State")]
        public int StateId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual State State { get; set; }
    }
}
