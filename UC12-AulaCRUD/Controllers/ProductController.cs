using Microsoft.AspNetCore.Mvc;
using UC12_AulaCRUD.Database;
using UC12_AulaCRUD.Models;

namespace UC12_AulaCRUD.Controllers
{
    public class ProductController : Controller
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
        public JsonResult Update([FromBody] Product product)
        {
            try
            {
                dbProduct dbp = new dbProduct();
                bool response = dbp.Update(product);

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

        [HttpPost]
        public JsonResult Add([FromBody] Product product)
        {
            try
            {
                dbProduct dbp = new dbProduct();
                bool response = dbp.Add(product);

                if (response)
                {
                    return new JsonResult(new { success = true, message = "Gravado com sucesso" });
                }
                else
                {
                    return new JsonResult(new { success = false, message = "Erro" });
                }
            }
            catch(Exception ex) 
            {
                return new JsonResult(new { success = false, message = ex.Message});
            }
        }

        [HttpGet] 
        public JsonResult GetAll() {
            List<Product> result = new List<Product>();
            try
            {
                dbProduct dbProduct = new dbProduct();
                result = dbProduct.GetAll();
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = ex.Message });

            }
            return new JsonResult(new {data = result});
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            try
            {
                dbProduct dbProduct = new dbProduct();
                Product product = dbProduct.Get(id);
                if (product != null)
                {
                    return View("ViewAdd",product);
                }
                else
                    return RedirectToAction("ViewList");
            }
            catch (Exception ex)
            {
                return RedirectToAction("ViewList");
            }
        }

        [HttpPost]

        public JsonResult Delete([FromBody]int id)
        {
            bool result = false;
            try
            {
                dbProduct dbProduct = new dbProduct();
                result = dbProduct.Delete(id);

                if(result)
                    return new JsonResult(new { success = true, message = "Excluído com sucesso" });
                else
                    return new JsonResult(new { success = false, message = "Erro ao excluir" });
            }
            catch (Exception ex)
            {

                return new JsonResult(new { success = false, message = ex.Message });
            }
        }
        
    }
}
