using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace PTC
{
    public static class HtmlExtensionsTextBox
    {
        public static MvcHtmlString BootstrapTextBoxFor<TModel, TValue>(
      this HtmlHelper<TModel> htmlHelper,
      Expression<Func<TModel, TValue>> expression,
      HtmlExtensionsCommon.Html5InputTypes type,
      object htmlAttributes = null
      )
        {
            RouteValueDictionary rvd = new RouteValueDictionary(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            rvd.Add("type", type.ToString());

            return InputExtensions.TextBoxFor(htmlHelper, expression, rvd);

        }

    }
}