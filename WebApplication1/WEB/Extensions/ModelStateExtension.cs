using BusinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.WEB.Extensions
{
    public static class ModelStateExtension
    {
        public static void BindingErrors(this ModelStateDictionary s, PutsException ex)
        {
            List<ErrorField> errors = ex.GetErrors();
            var customErrors = errors.GetEnumerator();
            while (customErrors.MoveNext())
            {
                var error = customErrors.Current;
                s.AddModelError(error.Field, error.Message);
            }
        }
    }
}