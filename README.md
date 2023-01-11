
## Build and run

dotnet build
dotnet run


## URL For playground

http://localhost:5246/GraphQL/


## GraphQL query example

query example1
{
  books {
    title
    author {
      name
    }
  }
}

## GraphQL mutation example

mutation example2
{
  addBook(input: { book: { title: "Cool Book 2023", author: { name: "Richard Magnor Stenbro"}} }) {
    book {
      title
      author {
        name
      }
    }
  }
}
