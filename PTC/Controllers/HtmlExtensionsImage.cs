using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace PTC
{
    public static class HtmlExtensionsImage
    {
        public static MvcHtmlString Image(
            this HtmlHelper htmlHelper,
            string src,
            string altText,
            
            object htmlAttrributes = null)
        {
            return HtmlExtensionsImage.Image(htmlHelper, src, altText, string.Empty, string.Empty, htmlAttrributes);
        }

        public static MvcHtmlString Image(
            this HtmlHelper htmlHelper,
            string src,
            string altText,
            string cssClass,
            object htmlAttrributes = null)
        {
            return HtmlExtensionsImage.Image(htmlHelper, src, altText, cssClass, string.Empty, htmlAttrributes);
        }

        public static MvcHtmlString Image(
            this HtmlHelper htmlHelper,
            string src,
            string altText,
            string cssClass,
            string name, 
            object htmlAttrributes = null)
        {

           TagBuilder tb = new TagBuilder("img");

            if (!string.IsNullOrWhiteSpace(name))
            {
                name = TagBuilder.CreateSanitizedId(name);
                tb.GenerateId(name);
                tb.MergeAttribute("name", name);
            }


            tb.MergeAttribute("src", src);
            tb.MergeAttribute("alt", altText);

            if (!string.IsNullOrWhiteSpace(cssClass))
            {

            tb.AddCssClass(cssClass);

            }

            tb.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttrributes));

            // HTML Encode the String
            return MvcHtmlString.Create(tb.ToString(TagRenderMode.SelfClosing));
        }
    }
}