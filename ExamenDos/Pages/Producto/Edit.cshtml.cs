using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace ExamenDos.Pages.Producto
{
    public class EditModel : PageModel
    {
        private readonly IProductoService productoService;

        public EditModel(IProductoService productoService)
        {
            this.productoService = productoService;
        }

        //Enables us to call the product entity attributes
        [BindProperty]
        [FromBody]
        public ProductoEntity Entity { get; set; } = new ProductoEntity();

        //Maps the Id to be edited
        [BindProperty(SupportsGet =true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                //Edit
                if (id.HasValue)
                {
                    Entity = await productoService.GetById(new() { IdProducto = id });
                }

                return Page();
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }

        public async Task<IActionResult> OnPost()
        {
            try
            {
                var result = new DBEntity();

                //Edit
                if (Entity.IdProducto.HasValue)
                {
                    result = await productoService.Update(Entity);
                }
                else
                {
                    result = await productoService.Insert(Entity);
                }

                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError = ex.HResult, MsgError = ex.Message });
            }
        }
    }
}
