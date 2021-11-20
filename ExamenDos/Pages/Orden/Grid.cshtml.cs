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
    public class GridModel : PageModel
    {
        private readonly IOrdenService ordenService;

        public GridModel(IOrdenService ordenService)
        {
            this.ordenService = ordenService;
        }

        public IEnumerable<OrdenEntity> GridList { get; set; } = new List<OrdenEntity>();

        public async Task<IActionResult> OnGet()
        {
            try
            {
                //Populates the list with the results returned from the service get method.
                GridList = await ordenService.Get();
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
                var result = await ordenService.Delete(new() { IdOrden = id });
                return new JsonResult(result);
            }
            catch (Exception ex)
            {
                return new JsonResult(new DBEntity { CodeError =ex.HResult, MsgError = ex.Message });
            }
        }

    }
}
