using System.Data.Entity;

namespace ContactManagementApp.Models
{
    public class ContactContext : DbContext
    {
        public ContactContext() : base("ContactDbConnection")
        {
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}