using AngularCoreProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularCoreProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    [HttpGet]
    public IActionResult GetClients()
    {
        Result result = new Result();
        try
        {
            using (CursoAngularNetCoreContext dataBase = new CursoAngularNetCoreContext())
            {
                var productsList = dataBase.Productos.ToList();
                result.ResultObject = productsList;
            }
        }
        catch (Exception ex)
        {
            result.Error = "Se produjo un error al obtener los productos. " + ex.Message;
        }

        return Ok(result);
    }
}