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
    public class GridModel : PageModel
    {
        private readonly IProductoService productoService;

        public GridModel(IProductoService productoService)
        {
            this.productoService = productoService;
        }

        public IEnumerable<ProductoEntity> GridList { get; set; } = new List<ProductoEntity>();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                //Populates the list with the results returned from the service get method.
                GridList = await productoService.Get();
                return Page();
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }

        public async Task<IActionResult> OnDelete(int id)
        {
            try
            {
                
                var result = await productoService.Delete(new() { IdProducto = id });
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError =ex.HResult, MsgError = ex.Message });
            }
        }

    }
}
