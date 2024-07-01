# Blog Management RESTful API

This project is a simple blogging platform API using ASP.NET Core Web API and Entity Framework Core. It manages blog posts and their associated comments.

## Technologies Used
- ASP.NET Core
- Entity Framework Core

## Features
- Creating, retrieving blog posts.
- Adding comments to a specific blog post.

## API Endpoints
- GET /api/posts: Returns a list of all blog posts, including their titles and the number of comments associated with each post.
- POST /api/posts: Creates a new blog post.
- GET /api/posts/{id}: Retrieves a specific blog post by its ID, including its title, content, and a list of associated comments.
- POST /api/posts/{id}/comments: Adds a new comment to a specific blog post.

## Getting Started
1. Clone the repository to your local machine.
2. Navigate to the project directory.
3. Run `dotnet restore` to install necessary packages.
4. To start the API, run `dotnet run`.
5. The API will start running at `http://localhost:5079/swagger/index.html`.

## Author
Geraldo Marques

## License
This project is licensed under the MIT License.
