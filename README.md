
# Steps for creating an MVC project using .Net core

Choose the following template in visual studio:

![image](https://github.com/user-attachments/assets/d4d6d631-4434-4371-a130-3649652b6eff)

Then, (optionally) check off HTTPS  and check off "Do not use top-level statements":

![image](https://github.com/user-attachments/assets/3f190b7b-4b4a-4696-a71d-b3695c9f1ee8)


Once the project is created, right click on the project file, and click "Edit Project File":

<img width="400" alt="image" src="https://github.com/LITW11/LayoutPages-SelectDemo/assets/159099703/315311ba-246b-4bf5-9b56-6753384118cf">

In there, remove the following line:

```xml
<Nullable>enable</Nullable>
```

and then click save and close that file.

Then, in the HomeController, remove everything except for the following (leave the using statements and the namespace):

    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
Then, go into your Views folder, and delete the `Privacy.cshtml` file.

Then, go into the Views/Shared folder and open the _Layout.cshtml file. In there, remove this line from the navbar:

      <li class="nav-item">
          <a class="nav-link text-dark" asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
      </li>
If you want to add your own nav link on top, add something like the following:

      <li class="nav-item">
          <a class="nav-link text-dark" asp-controller="PutYourControllerNameHere" asp-action="PutYourActionNameHere">LinkTextToDisplay</a>
      </li>
Then, at the bottom of the layout, remove the footer:

    <footer class="border-top footer text-muted">
        <div class="container">
            &copy; 2024 - WebApplication17 - <a asp-area="" asp-controller="Home" asp-action="Privacy">Privacy</a>
        </div>
    </footer>

## Adding SqlClient into the project from Nuget
`SqlConnection` is no longer in the project by default. We need to get from Nuget. Right click on the project and click "Manage Nuget Packages"

<img width="947" alt="image" src="https://github.com/user-attachments/assets/c5369dc3-7907-4f4e-85f9-a4f27df622be" />

then, search for "System.Data.SqlClient" and install it:

![image](https://github.com/user-attachments/assets/d5a7c0a4-4ec8-4198-896a-28282787a0b3)

## Adding the connection string
In these new projects, there's no longer a settings file. Therefore, for now we're going to hard code our connection strings at the top of our controllers. 

See here: https://github.com/LIT-W12/LayoutPages-SelectDemo/blob/master/WebApplication10/Controllers/NorthwindController.cs#L8
(where it says `Northwnd` replace it with the name of your db)

## Dealing with nulls in the database

I showed the following extension method to deal with nulls:

    public static class Extensions
    {
        public static T GetOrNull<T>(this SqlDataReader reader, string columnName)
        {
            var value = reader[columnName];
            if (value == DBNull.Value)
            {
                return default(T);
            }

            return (T)value;
        }
    }

Code is here:

[https://github.com/LITW11/LayoutPages-SelectDemo/blob/master/WebApplication12/Models/Extensions.cs#L5](https://github.com/LIT-W12/LayoutPages-SelectDemo/blob/master/WebApplication10/Models/Extensions.cs#L5)

We can then use it like so:

[https://github.com/LITW11/LayoutPages-SelectDemo/blob/master/WebApplication12/Models/NorthwindDb.cs#L77-L78](https://github.com/LIT-W12/LayoutPages-SelectDemo/blob/master/WebApplication10/Models/NorthwindDb.cs#L85-L86)
