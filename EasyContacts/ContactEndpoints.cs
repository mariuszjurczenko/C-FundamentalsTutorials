using EasyContacts.Data;
using EasyContacts.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace EasyContacts;

public static class ContactEndpoints
{
    public static void MapContactEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Contact").WithTags(nameof(Contact));

        group.MapGet("/", async (EasyContactsContext db) =>
        {
            return await db.Contact.ToListAsync();
        })
        .WithName("GetAllContacts")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Contact>, NotFound>> (Guid id, EasyContactsContext db) =>
        {
            return await db.Contact.AsNoTracking()
                .FirstOrDefaultAsync(model => model.Id == id)
                is Contact model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetContactById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (Guid id, Contact contact, EasyContactsContext db) =>
        {
            var affected = await db.Contact
                .Where(model => model.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.Id, contact.Id)
                    .SetProperty(m => m.FirstName, contact.FirstName)
                    .SetProperty(m => m.LastName, contact.LastName)
                    .SetProperty(m => m.Email, contact.Email)
                    .SetProperty(m => m.PhoneNumber, contact.PhoneNumber)
                    .SetProperty(m => m.Address, contact.Address)
                    .SetProperty(m => m.CreatedAt, contact.CreatedAt)
                    .SetProperty(m => m.IsActive, contact.IsActive)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateContact")
        .WithOpenApi();

        group.MapPost("/", async (Contact contact, EasyContactsContext db) =>
        {
            db.Contact.Add(contact);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Contact/{contact.Id}",contact);
        })
        .WithName("CreateContact")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (Guid id, EasyContactsContext db) =>
        {
            var affected = await db.Contact
                .Where(model => model.Id == id)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteContact")
        .WithOpenApi();
    }
}
