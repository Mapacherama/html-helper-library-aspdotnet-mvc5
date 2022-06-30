using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace PTC
{
    public class HtmlExtensionsCommon
    {
        public enum HtmlButtonTypes
        {
            submit,
            button,
            reset
        }

        public static void AddName(TagBuilder tb, string name, string id)
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                // Ensure we have valid name
                name = TagBuilder.CreateSanitizedId(name);


                if (string.IsNullOrWhiteSpace(id))
                {
                    // Generate valid 'id' attribute 
                    // from the 'name' attribute
                    tb.GenerateId(name);
                }
                else
                {
                    tb.MergeAttribute("id", TagBuilder.CreateSanitizedId(id));
                }                
            }
            tb.MergeAttribute("name", name);
        }
    }
}