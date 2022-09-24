using AngularCoreProject.Models;
using AngularCoreProject.Models.ViewModels;
using AngularCoreProject.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace AngularCoreProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientsController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ClientsController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        [HttpGet]
        public IActionResult GetClients()
        {
            Result result = new Result();
            try
            {
                using (CursoAngularNetCoreContext dataBase = new CursoAngularNetCoreContext())
                {
                    var list = dataBase.Clientes.ToList();
                    result.ResultObject = list;
                }
            }
            catch (Exception ex)
            {
                result.Error = "Se produjo un error al obtener los clientes " + ex.Message;
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult AddClient(ClientViewModel clientViewModel)
        {
            Result result = new Result();
            try
            {
                byte[] keyByte = new byte[] {1, 2, 3, 4, 5, 6, 7, 8};
                PasswordEncryption passwordEncryption = new PasswordEncryption(keyByte);

                using (CursoAngularNetCoreContext dataBase = new CursoAngularNetCoreContext())
                {
                    Cliente cliente = new Cliente();
                    cliente.Nombre = clientViewModel.ClientName;
                    cliente.Email = clientViewModel.ClientEmail;
                    cliente.Password = Encoding.ASCII.GetBytes(passwordEncryption
                        .EncryptText(clientViewModel.ClientPassword, this._configuration["keyEncryption"]));
                    cliente.FechaAlta = DateTime.Now;
                    dataBase.Clientes.Add(cliente);
                    dataBase.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result.Error = "Se produjo un error al obtener el alta " + ex.Message;
            }

            return Ok(result);
        }

        [HttpPut]
        public IActionResult EditClient(ClientViewModel clientViewModel)
        {
            Result result = new Result();
            try
            {
                byte[] keyByte = new byte[] {1, 2, 3, 4, 5, 6, 7, 8};
                PasswordEncryption passwordEncryption = new PasswordEncryption(keyByte);

                using (CursoAngularNetCoreContext dataBase = new CursoAngularNetCoreContext())
                {
                    Cliente cliente = dataBase.Clientes.Single(client => client.Email == clientViewModel.ClientEmail);
                    cliente.Nombre = clientViewModel.ClientName;
                    cliente.Password = Encoding.ASCII.GetBytes(passwordEncryption
                        .EncryptText(clientViewModel.ClientPassword, this._configuration["keyEncryption"]));
                    dataBase.Entry(cliente).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    dataBase.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result.Error = "Se produjo un error al modificar un cliente" + ex.Message;
            }

            return Ok(result);
        }

        [HttpDelete("{ClientEmail}")]
        public IActionResult ClientDelete(String ClientEmail)
        {
            Result result = new Result();

            try
            {
                using (CursoAngularNetCoreContext dataBase = new CursoAngularNetCoreContext())
                {
                    Cliente cliente = dataBase.Clientes.Single(client => client.Email == ClientEmail);
                    dataBase.Remove(cliente);
                    dataBase.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                result.Error = "Se produjo un error al eliminar el cliente. " + ex.Message;
            }

            return Ok(result);
        }
    }
}