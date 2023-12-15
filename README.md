# Seed the database an ASP.NET Core MVC application

>This tutorial teaches how to seed the database, create a new class named `DbInitializer` in the Models folder. If there are any products in the database, the seed initializer returns and no products are added. This guide is compiled based on [Get started with ASP.NET Core MVC](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc?view=aspnetcore-8.0&tabs=visual-studio-code) by `Microsoft`.

In this section:

- Seed the database Create a new class named DbInitializer in the Models folder.

Before coming to this guide, please refer to [Add a new field and add validation to an ASP.NET Core MVC app](https://github.com/NguyenPhuDuc307/add-field-and-validation).

## Seed the database

Create a new class named `DbInitializer` in the `Data` folder. Replace the generated code with the following:

```c#
namespace CourseManagement.Data
{
    public static class DbInitializer
    {
        public static void Seed(IServiceProvider serviceProvider)
        {
            using (var context = new CourseDbContext(serviceProvider.GetRequiredService<DbContextOptions<CourseDbContext>>()))
            {
                // Look for any products.
                if (context.Courses.Any())
                {
                    return;   // DB has been seeded
                }
                context.Courses.AddRange(
                    new Course
                    {
                        Title = "ASP.NET Core MVC",
                        Topic = ".NET Programming",
                        ReleaseDate = DateTime.Today,
                        Author = "vnLab"
                    },
                    new Course
                    {
                        Title = "ASP.NET Core API",
                        Topic = ".NET Programming",
                        ReleaseDate = DateTime.Today,
                        Author = "vnLab"
                    },
                    new Course
                    {
                        Title = "Java Spring Boot",
                        Topic = "Java Programming",
                        ReleaseDate = DateTime.Today,
                        Author = "vnLab"
                    },
                    new Course
                    {
                        Title = "Laravel - The PHP Framework",
                        Topic = "PHP Programming",
                        ReleaseDate = DateTime.Today,
                        Author = "vnLab"
                    },
                    new Course
                    {
                        Title = "Angular Tutorial For Beginner",
                        Topic = "Angular Programming",
                        ReleaseDate = DateTime.Today,
                        Author = "vnLab"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
``````

## Add the seed initializer

Add a seed initializer, let's add the following initialization code in `Program.cs`:

```c#
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    DbInitializer.Seed(services);
}
```

Delete all the records in the database.

Test the app. Stop it and restart it so the `DbInitializer.Seed` method runs and seeds the database.

The app shows the seeded data.

![Seed Data](resources/seed-data.png)

Above are all instructions on seed the database an ASP.NET Core MVC app, refer to the [Work with a database in an ASP.NET Core MVC app](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/working-with-sql?view=aspnetcore-8.0&tabs=visual-studio-code).

Next let's [Use AutoMapper in MVVM Pattern ASP.NET Core](https://github.com/NguyenPhuDuc307/mvvm-design-pattern).
