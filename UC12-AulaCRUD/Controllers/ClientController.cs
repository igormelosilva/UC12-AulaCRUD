using Microsoft.AspNetCore.Mvc;
using UC12_AulaCRUD.Database;
using UC12_AulaCRUD.Models;

namespace UC12_AulaCRUD.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult ViewList()
        {
            return View();
        }

        public IActionResult ViewAdd()
        {
            return View();
        }
        [HttpPost]
        public JsonResult Add([FromBody] Client client)
        {
            try
            {
                DbClient dbc = new DbClient();
                bool response = dbc.Add(client);

                if (response)
                {
                    return new JsonResult(new { success = true, message = "Gravado com sucesso" });
                }
                else
                {
                    return new JsonResult(new { success = false, message = "Erro" });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            List<Client> result = new List<Client>();
            try
            {
                DbClient dbclient = new DbClient();
                result = dbclient.GetAll();
            }
            catch (Exception ex)
            {


            }
            return new JsonResult(new { data = result });
        }

        [HttpPost]
        public JsonResult Delete([FromBody] int id)
        {
            bool result = false;
            try
            {
                DbClient dbCliente = new DbClient();
                result = dbCliente.Delete(id);

                if (result)
                    return new JsonResult(new { success = true, message = "Excluído com sucesso" });
                else
                    return new JsonResult(new { success = false, message = "Erro ao excluir" });
            }
            catch (Exception ex)
            {

                return new JsonResult(new { success = false, message = ex.Message });
            }
        }

        [HttpPost]
        public JsonResult Update([FromBody] Client client)
        {
            try
            {
                DbClient dbp = new DbClient();
                bool response = dbp.Update(client);

                if (response)
                {
                    return new JsonResult(new { success = true, message = "Atualizado com sucesso" });
                }
                else
                {
                    return new JsonResult(new { success = false, message = "Erro ao atualizar" });
                }
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = ex.Message });
            }

        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                DbClient dbClient = new DbClient();
                Client client = dbClient.Get(id);
                if (client != null)
                {
                    return View("ViewAdd", client);
                }
                else
                    return RedirectToAction("ViewList");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ViewList");
            }
        }
    }
}
