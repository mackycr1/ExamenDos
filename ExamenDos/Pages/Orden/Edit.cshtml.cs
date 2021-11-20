using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WBL;

namespace ExamenDos.Pages.Orden
{
    public class EditModel : PageModel
    {
        private readonly IOrdenService ordenService;
        private readonly IProductoService productoService;

        public EditModel(IOrdenService ordenService, IProductoService productoService)
        {
            this.ordenService = ordenService;
            this.productoService = productoService;
        }

        //Enables us to call the order entity attributes
        [BindProperty]
        [FromBody]
        public OrdenEntity Entity { get; set; } = new OrdenEntity();

        //Stores the list of products available
        public IEnumerable<ProductoEntity> ProductList = new List<ProductoEntity>();


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
                    Entity = await ordenService.GetById(new() { IdOrden = id });
                }

                //Populates the Product List with the values from the Product table
                ProductList = await productoService.GetProductList();

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
                    result = await ordenService.Update(Entity);
                }
                else
                {
                    result = await ordenService.Insert(Entity);
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
