# I. Routing Methods
## Default route
```cs
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);
```
## Constraints
```cs
app.MapControllerRoute(
    name: "product",
    pattern: "{url}/{id:range(0,2)}",
    defaults: new{
        id = new RangeRouteConstraint(0,2)
    }
);
```
# II. Attributes
## AcceptVerbs
```cs
[AcceptVerbs("Post")]
public IActionResult PostForm() {
    return Page();
}
```
## Route
**Warning**
> Using `[Route]` attribute will override the pattern of `MapControllerRoute()` method

* Create a route for action
```cs 
// localhost:5130/my-collection ~ @Url.RouteUrl("collection1")
[Route("my-collection", Order = 1, Name="collection1")]      

// localhost:5130/my-collection/Car/Collection ~ @Url.RouteUrl("collection2")
[Route("my-collection/[controller]/[action]", Order = 2, Name="collection2")]  

// localhost:5130/Car-Collection.html ~ @Url.RouteUrl("collection3")
[Route("[controller]-[action].html", Order = 3, Name="collection3")]  

// Can access by 3 routes. Order: 1 > 2 > 3
public IActionResult Collection(string? brand)    
{
    return View("Collection", brand);
}
```
* Create a route for controller
```cs 
[Route("super-car/[action]")]           // localhost:5130/super-car/{action}
public class CarController : Controller
{ 
    [Route("my-collection")]            // localhost:5130/super-car/my-collection 
    [Route("/my-collection")]           // localhost:5130/my-collection  -->  Warning / 
    public IActionResult Collection()
    {
        return View();
    }

    // localhost:5130/super-car/Product
    public IActionResult Product()      
    {       
        return View();
    }
}
```
## Http methods
* [HttpGet("/my-collection")]
* [HttpPost("/my-collection")]
* [HttpPut("/my-collection")]
* [HttpDelete("/my-collection")]
# III. Area
## Config
```cs
// Area/Controller/Action/Id
app.MapAreaControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}",
    areaName: "CarArea");
```
## Usage
```cs
[Area("CarArea")]
public class CarController : Controller
{
    //
}
```
**Note** New path:

📁 ~~Views/Car/Index.cshtml ~~

📁 Areas/CarArea/Views/Car/Index.cshtml

# IV. UrlHelper
## Url.Action
```cs
@Url.ActionLink()                       // localhost:5130/

@Url.Action()                           // /

@Url.Action("Privacy", new {id = 1})    // /Home/Privacy?id=1

// Action --> Controller 
@Url.Action("Collection", "Car", new {brand = "Lamborghini"})    // Car/Collection?brand=Lamborghini

@Url.ActionLink("Collection", "Car", new {area = "CarArea", brand = "Ferrari"})   // Car/Collection?brand=Lamborghini

```
## Url.Link
* MapAreaControllerRoute or MapControllerRoute
```cs
app.MapAreaControllerRoute(
    name: "area",
    pattern: "{controller}/{action=Index}/{id?}",
    areaName: "CarArea");
```
```cs
@Url.Link("area", new {action = "Collection", controller = "Car", brand = "Audi"})
// ~ CarArea/Car/Collection?brand=Audi
```
* Route attribute
```cs
[Route("/my-collection", Order = 1, Name = "collection1")]                          
[Route("my-collection/[controller]/[action]", Order = 2, Name = "collection2")]  
[Route("[controller]-[action].html", Order = 3, Name = "collection3")]             
public IActionResult Collection(string? brand)
```
```cs
@Url.Link("collection1", new {action = "Collection", controller = "Car", brand = "BMW"})
// ~ my-collection?brand=BMW
```
# V. Anchor tagHelper
* asp-area
* asp-controller
* asp-action
* asp-route
* asp-route...
```cs
<a class="nav-link text-dark" asp-area="CarArea" asp-controller="Car" asp-action="Collection" asp-route-brand="Audi">Audi Collection</a>
// ~ CarArea/Car/Collection?brand=Audi
```
## Multi parameters
* Way 1
```cs
<a class="nav-link text-dark" asp-area="CarArea" asp-controller="Car" asp-action="Collection" asp-route-brand="Audi" asp-route-color="Black">Audi Collection</a>
// ~ CarArea/Car/Collection?brand=Audi&color=Black
```
* Way 2
```cs
@{
    var data = new Dictionary<string, string>()
    {
        {"brand", "Audi"},
        {"color", "Black"}
    };
}
<a class="nav-link text-dark" asp-area="CarArea" asp-controller="Car" asp-action="Collection" asp-all-route-data="@data">Audi Collection</a>
// ~ CarArea/Car/Collection?brand=Audi&color=Black
```