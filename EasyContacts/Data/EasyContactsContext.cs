using EasyContacts.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyContacts.Data;

public class EasyContactsContext : DbContext
{
    public EasyContactsContext (DbContextOptions<EasyContactsContext> options)
        : base(options)
    {
    }

    public DbSet<Contact> Contact { get; set; } = default!;
}
