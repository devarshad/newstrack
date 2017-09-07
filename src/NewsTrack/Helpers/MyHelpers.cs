using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NT.Models;
namespace NewsTrack.Helpers
{
    public static class MyHelpers
    {
        public static MvcHtmlString BootButton(this HtmlHelper htmlHelper, string type, string id, string classVal, string val)
        {
            var btnBuilder = new TagBuilder("input");
            var attrLst = new Dictionary<string, string>();
            attrLst.Add("type", type);
            attrLst.Add("name", id);
            attrLst.Add("id", id);
            attrLst.Add("value", val);
            attrLst.Add("class", classVal);
            btnBuilder.MergeAttributes(attrLst);
            return MvcHtmlString.Create(btnBuilder.ToString(TagRenderMode.SelfClosing));
        }

        //public static MvcHtmlString BootTextBox(this HtmlHelper htmlHelper, string type, string id, string placeholder, bool icon = false, Enums.IconPosition iconposition = Enums.IconPosition.RIGHT)
        //{
        //    //declare the html helper 
        //    var builder = new TagBuilder("div");
        //    //hook the properties and add any required logic0
        //    builder.MergeAttribute("class", "form-group");
        //    var inputGrpDiv = new TagBuilder("div");
        //    inputGrpDiv.MergeAttribute("class", "input-group");
        //    var inputTextBox = new TagBuilder("input");
        //    var attrLst = new Dictionary<string, string>();
        //    attrLst.Add("type", type);
        //    attrLst.Add("class", "form-control input-sm");
        //    attrLst.Add("name", id);
        //    attrLst.Add("id", id);
        //    attrLst.Add("placeholder", placeholder);
        //    attrLst.Add("required", "");
        //    if (type == "number")
        //    {
        //        attrLst.Add("min", "1");
        //        attrLst.Add("max", "5");
        //    }
        //    inputTextBox.MergeAttributes(attrLst);

        //    var spanAddon = new TagBuilder("span");
        //    spanAddon.MergeAttribute("class", "input-group-addon");

        //    var spanasterisk = new TagBuilder("span");
        //    spanasterisk.MergeAttribute("class", "glyphicon glyphicon-asterisk");
        //    spanAddon.InnerHtml = spanasterisk.ToString();

        //    inputGrpDiv.InnerHtml = inputTextBox.ToString(TagRenderMode.SelfClosing) + spanAddon.ToString();

        //    builder.InnerHtml = inputGrpDiv.ToString();
        //    return MvcHtmlString.Create(builder.ToString());
        //    //return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        //}
    }
}