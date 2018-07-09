using MusicWebSite.Areas.Administrator.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MusicWebSite.Infrustructure
{
    public static class HTMLHelpers
    {
        public static IHtmlString GetDropDownSinger(this System.Web.Mvc.HtmlHelper helper, IEnumerable<SelectListItem> obj, string optionLabel, string RequiredErrorMessage, int SelectedSingerId)
        {
            string result = "";
            result = "<select id='SelectSinger' name='SelectSinger' class='form-control valid' data-val='true' data-val-required='" + RequiredErrorMessage + "'>";
            result += "<option value=''>" + optionLabel + "</option>";
            foreach (var item in obj)
            {
                if (Int32.Parse(item.Value) == SelectedSingerId)
                    result += "<option value=" + item.Value + " selected='selected'" + " >" + item.Text + "</option>";
                else
                    result += "<option value=" + item.Value + " >" + item.Text + "</option>";
            }
            result += "</select>";

            return (helper.Raw(result));
        }

        public static IHtmlString GetDropDownSinger(this System.Web.Mvc.HtmlHelper helper, IEnumerable<SelectListItem> obj, string optionLabel, string RequiredErrorMessage)
        {
            string result = "";
            result = "<select id='SelectSinger' name='SelectSinger' class='form-control valid' data-val='true' data-val-required='" + RequiredErrorMessage + "'>";
            result += "<option value=''>" + optionLabel + "</option>";
            foreach (var item in obj)
            {
                result += "<option value=" + item.Value + " >" + item.Text + "</option>";
            }
            result += "</select>";

            return (helper.Raw(result));
        }

        public static IHtmlString GetDropDownMusicCategory(this System.Web.Mvc.HtmlHelper helper, IEnumerable<SelectListItem> obj, string optionLabel, string RequiredErrorMessage)
        {
            string result = "";
            result = "<select id='SelectMusicCategory' name='SelectMusicCategory' class='form-control valid' data-val='true' data-val-required='" + RequiredErrorMessage + "'>";
            result += "<option value=''>" + optionLabel + "</option>";
            foreach (var item in obj)
            {
                result += "<option value=" + item.Value + ">" + item.Text + "</option>";
            }
            result += "</select>";

            return (helper.Raw(result));
        }

        public static IHtmlString GetDropDownMusicCategory(this System.Web.Mvc.HtmlHelper helper, IEnumerable<SelectListItem> obj, string optionLabel, string RequiredErrorMessage, int SelectedMusicCategoryId)
        {
            string result = "";
            result = "<select id='SelectMusicCategory' name='SelectMusicCategory' class='form-control valid' data-val='true' data-val-required='" + RequiredErrorMessage + "'>";
            result += "<option value=''>" + optionLabel + "</option>";
            foreach (var item in obj)
            {
                if (Int32.Parse(item.Value) == SelectedMusicCategoryId)
                    result += "<option value=" + item.Value + " selected='selected'" + ">" + item.Text + "</option>";
                else
                    result += "<option value=" + item.Value + ">" + item.Text + "</option>";
            }
            result += "</select>";

            return (helper.Raw(result));
        }
    }
}