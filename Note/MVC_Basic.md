# ⚙️ Controllers

* Inherit from **Controller** class
```csharp
public class HomeController : Controller
```

## Route
* Pattern
```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

## Action
* Is a non-static method, return anything (void, string, IActionResult,...)
* IActionResult
| Return type                 | Method                |
| :---------------------------|:----------------------|
| `ViewResult`                | `View()`              |
| `ContentResult`             | `Content()`           |
| `EmptyResult`               | `new EmptyResult()`   |
| `FileResult`                | `File()`              |
| `ForbidResult`              | `Forbid()`            |
| `JsonResult`                | `Json()`              |
| `LocalRedirectResult`       | `LocalRedirect()`     |
| `RedirectResult`            | `Redirect()`          |
| `RedirectToActionResult`    | `RedirectToAction()`  |
| `RedirectToPageResult`      | `RedirectToRoute()`   |
| `RedirectToRouteResult`     | `RedirectToPage()`    |
| `PartialViewResult`         | `PartialView()`       |
| `ViewComponentResult`       | `ViewComponent()`     |
| `StatusCodeResult`          | `StatusCode()`        |

# 👁️ Views
## Overloads
```cs
// Absolute path
return View("MyViews/Car/Index.cshtml");

// Relative Path --> Views/{controller}/Product.cshtml
return View("Product");  //Just name, not include .cshtml

// Not path --> Views/{controller}/{action}.cshtml
return View();

// Pass model
return View((object)brand);
```
## Query 
```cs
public IActionResult Product(string? brand)
{
    return View((object)brand);
}
```
## Add view folder
```cs
builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.ViewLocationFormats.Add("MyViews/{1}/{0}" + RazorViewEngine.ViewExtension);
});  
// {1} ~ controller
// {2} ~ action
```
## Pass data between views
```cs
TempData["message"] = "My message";
```
# 📦 Models
## Pass model to view
* Via `View()`
```cs
CarModel car = new()
return View(car);
```
* Via `ViewData`
```cs
ViewData["car"] = car;
```
* Via `ViewBag`
```cs
// Set property for ViewBag in Action
CarModel car = new()
ViewBag.Car = car;
```
```cs
// Usage in View
var listCars = ViewBag.ListCars as List<CarModel>;
```
