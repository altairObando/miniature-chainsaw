namespace DAL.Contacts
{
    /// <summary>
    ///     Contact reference
    /// </summary>
    public class Contact
    {
        public int Id { get; set; }
        public string NIF { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Surname1 { get; set; }
        public string Surname2 { get; set; }
        public DateTime Birth { get; set; }
        public char Gender { get; set; }
        public char MaritalStatus { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
