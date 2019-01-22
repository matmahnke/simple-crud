using DTO;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.WEB
{
    public class ProfissionalCustomModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            ProfissionalViewModel profissionalViewModel = new ProfissionalViewModel();

            NameValueCollection formValues = controllerContext.HttpContext.Request.Form;
            PropertyInfo[] propriedades =
                typeof(ProfissionalViewModel).GetProperties();
            foreach (PropertyInfo item in propriedades)
            {
                try
                {
                    item.SetValue(profissionalViewModel, formValues[item.Name]);
                }
                catch
                {
                }
            }
            string[] valores = formValues["Etnia"].Split(',');
            int soma = 0;
            for (int i = 0; i < valores.Length; i++)
            {
                soma += int.Parse(valores[i]);
            }
            profissionalViewModel.Etnia = (Etnia)soma;
            return profissionalViewModel;
        }
    }
}