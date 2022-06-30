using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace PTC
{
    public static class HtmlExtensionsButton
    {
        public static MvcHtmlString BootstrapButton(this HtmlHelper htmlHelper,
              string innerHtml,
              object htmlAttributes = null)
        {
            return HtmlExtensionsButton.BootstrapButton(htmlHelper, innerHtml, null, null, null, false, false, HtmlExtensionsCommon.HtmlButtonTypes.submit, null, htmlAttributes);
        }
        public static MvcHtmlString BootstrapButton(this HtmlHelper htmlHelper,
          string innerHtml,
          string cssClass,
          object htmlAttributes = null)
        {
            return HtmlExtensionsButton.BootstrapButton(htmlHelper, innerHtml, cssClass, null, null, false, false, HtmlExtensionsCommon.HtmlButtonTypes.submit, null, htmlAttributes);
        }

        public static MvcHtmlString BootstrapButton(this HtmlHelper htmlHelper,
              string innerHtml,
              string cssClass,
              string pdsaAction,
              object htmlAttributes = null)
        {
            return HtmlExtensionsButton.BootstrapButton(htmlHelper, innerHtml, cssClass, string.Empty, null, false, false, HtmlExtensionsCommon.HtmlButtonTypes.submit, pdsaAction, htmlAttributes);
        }



        public static MvcHtmlString BootstrapButton(
        this HtmlHelper htmlHelper,
        string innerHtml,
        string cssClass,
        string name,
        string title,
        bool isFormNoValidate,
        bool isAutoFocus,
        HtmlExtensionsCommon.HtmlButtonTypes buttonType,
        string pdsaAction,
        object htmlAttributes = null)
        {
            TagBuilder tb = new TagBuilder("button");

            // Ensure we have a 'btn-*' class
            if (!string.IsNullOrEmpty(cssClass))
            {
                if (!cssClass.Contains("btn-"))
                {
                    cssClass = "btn-primary " + cssClass;
                }
            }
            else
            {
                cssClass = "btn-primary";
            }

            tb.AddCssClass(cssClass);

            tb.AddCssClass("btn");

            if (!string.IsNullOrWhiteSpace(pdsaAction))
            {
                tb.MergeAttribute("data-pdsa-action", pdsaAction);

            }


            HtmlExtensionsCommon.AddName(tb, name, "");

            // Add HTML 5 attributes
            if (!string.IsNullOrWhiteSpace(title))
            {
                tb.MergeAttribute("title", title);
            }
            if (isFormNoValidate)
            {
                tb.MergeAttribute("formnovalidate",
                  "formnovalidate");
            }
            if (isAutoFocus)
            {
                tb.MergeAttribute("autofocus",
                  "autofocus");
            }

            tb.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            tb.InnerHtml = innerHtml;

            // Add type of button
            switch (buttonType)
            {
                case HtmlExtensionsCommon.HtmlButtonTypes.submit:
                    tb.MergeAttribute("type", "submit");
                    break;
                case HtmlExtensionsCommon.HtmlButtonTypes.button:
                    tb.MergeAttribute("type", "button");
                    break;
                case HtmlExtensionsCommon.HtmlButtonTypes.reset:
                    tb.MergeAttribute("type", "reset");
                    break;
            }

            return MvcHtmlString.Create(tb.ToString()); 
        }
    }
}