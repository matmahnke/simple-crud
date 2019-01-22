using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace WebApplication1.WEB.HtmlHelper123
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString GenerateMenu<T>(this HtmlHelper helper)
        {
            //<div class="navbar-collapse collapse">
            //    <ul class="nav navbar-nav">
            //        <li>@Html.ActionLink("Home", "Index", "Home")</li>
            //        <li>@Html.ActionLink("About", "About", "Home")</li>
            //        <li>@Html.ActionLink("Contact", "Contact", "Home")</li>
            //    </ul>
            //</div>
            TagBuilder tagBuilderDiv = new TagBuilder("div");
            tagBuilderDiv.AddCssClass("navbar-collapse collapse");
            TagBuilder tagBuilderUL = new TagBuilder("ul");
            tagBuilderUL.AddCssClass("nav navbar-nav");

            foreach(var item in typeof(T).GetProperties())
            {
                TagBuilder tagBuilderli = new TagBuilder("li");
                tagBuilderli.SetInnerText(item.Name);
                tagBuilderUL.InnerHtml += tagBuilderli.ToString();
            }
            tagBuilderDiv.InnerHtml = tagBuilderUL.ToString();
            return MvcHtmlString.Create(tagBuilderDiv.ToString());
        }
    }
}