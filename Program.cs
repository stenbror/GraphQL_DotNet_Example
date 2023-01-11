var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddGraphQLServer()
    .AddMutationConventions(applyToAllMutations: true)
    .AddDefaultTransactionScopeHandler()
    .AddQueryType<Query>()
    .AddMutationType<MutationType>();

var app = builder.Build();

app.MapGraphQL();

app.Run();


public record Book(string Title, Author Author) { }
public record Author(string Name) { }

public class Query
{
    public Book GetBook() =>
        new Book("C# in Depth", new Author("John Skeet"));
        
    public List<Book> GetBooks() =>
        new List<Book>() 
        {
            new Book("C# in Depth V1", new Author("John Skeet")),
            new Book("C# in Depth V2", new Author("John Skeet")),
            new Book("C# in Depth V3", new Author("John Skeet")),
            new Book("C# in Depth V4", new Author("John Skeet")),
            new Book("C# in Depth V5", new Author("John Skeet"))
        };
}

public class Mutation
{
    public Book? AddBook(Book? book) // async Task<Book>
    {
        return book;
    }
}

public class MutationType : ObjectType<Mutation>
{
    protected override void Configure(
        IObjectTypeDescriptor<Mutation> descriptor)
    {
        descriptor.Field(f => f.AddBook(default));
    }
}