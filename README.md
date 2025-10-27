# UPGAMING TECH CHALLANGE | Book Catalog

A simple .NET 6 Web API project built as part of the Upgaming technical challenge.
This application demonstrates core backend development skills including controllers, DTOs, models, and sql scripts in schema.sql.


## Overview

The **Book Catalog API** allows you to:
- Retrieve all books with optional filters (by year and sort order)
- Retrieve books by a specific author
- Add new books to the catalog  
- Simulate a mini relational database using C# classes and lists.

## Folder Structure

```
Upgaming-Tech-Challange/
│
├── Controllers/
│   ├── AuthorsController.cs     # Handles book queries by author
│   └── BooksController.cs       # Handles CRUD operations for books
│
├── Dtos/
│   └── BookDto.cs               # Data Transfer Object for book creation
│
├── Models/
│   ├── Author.cs                # Author model with ID and Name
│   └── Book.cs                  # Book model with ID, Title, AuthorID, Year
│
├── BookCatalog.cs               # In-memory data catalog for authors & books and its methods for CRUD
│
├── schema.sql                   # SQL scripts
│
├── Program.cs                   # Entry point & API configuration
│
└── appsettings.json    
    
```



##  Features

### GET `/api/books`
Returns all books with optional filters:
- `publicationYear` — filter by year  
- `sortBy` — sort by title or year  

---

### POST `/api/books`
Adds a new book to the catalog.  

**Example body:**
```json
{
  "id": 4,
  "title": "Refactoring",
  "authorId": 1,
  "publicationYear": 2018
}
```


### GET `/api/authors/{id}/books`
Retrieves all books written by the specified author.
Returns `404` if author not found or has no books.


## Data model

### Author
| Field | Type   |
|:------|:-------|
| Id    | int    |
| Name  | string |

### Book
| Field | Type   |
|:------|:-------|
| Id    | int    |
| Title  | string |
|  AuthorId | int |
| PublicationYear  | int |


## Technologies Used

- .NET 6 / ASP.NET Core Web API
- C#
- Swagger / OpenAPI
- In-memory collections (List<T>)
- SQL (reference only)


## How to Run

1. Clone the repository
```bash
git clone https://github.com/Abula28/Upgaming-Tech-Challenge.git
cd Upgaming-Tech-Challenge
```

2. Run the application
```bash
dotnet run
```

3. Open Swagger UI and Navigate to:

```bash
https://localhost:7128/swagger/index.html
```
