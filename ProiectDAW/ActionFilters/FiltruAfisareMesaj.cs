using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProiectDAW.ActionFilters
{
    public class FiltruAfisareMesaj : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Mesaj("OnActionExecuting");
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Mesaj("OnActionExecuted");
        }
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            Mesaj("OnResultExecuting");
        }
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Mesaj("OnResultExecuted");
        }
        // Afisam un mesaj in consola
        private void Mesaj(string mesaj)
        {
            Debug.WriteLine(mesaj, "Filtru Personalizat");
        }
    }
}