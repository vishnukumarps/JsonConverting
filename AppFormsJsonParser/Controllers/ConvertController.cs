using AppFormsJsonParser.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppFormsJsonParser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertController : ControllerBase
    {

        [HttpGet]
        [Route("/GetFormJsonFromUrl")]
        public List<LWControl> GetFormJsonFromUrl()
        {
            try
            {
                var client = new RestClient("https://dev.cunextgen.com/ApprenderNew/api/values/default/B48A1D14-D4FE-4E41-8E8E-877BC595A01D");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                var parentJson = JsonConvert.DeserializeObject<ParentJson>(response.Content.ToString());

                var formJson = JsonConvert.DeserializeObject<List<LWControl>>(parentJson.FormJson);
                // Console.WriteLine(unescapedJsonString);
                return formJson;
            }
            catch (Exception ex)
            {


            }
            return null;
        }

        private List<LWControl> GetFormJsonFromUrl(string url)
        {
            try
            {
                var client = new RestClient("https://dev.cunextgen.com/ApprenderNew/api/values/default/B48A1D14-D4FE-4E41-8E8E-877BC595A01D");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                var parentJson = JsonConvert.DeserializeObject<ParentJson>(response.Content.ToString());

                var formJson = JsonConvert.DeserializeObject<List<LWControl>>(parentJson.FormJson);
                // Console.WriteLine(unescapedJsonString);
                return formJson;
            }
            catch (Exception ex)
            {


            }
            return null;
        }


        [HttpGet]
        [Route("/GetJson")]
        public List<Row> GetJson()
        {
            try
            {
                var lWControls = GetFormJsonFromUrl("");
                var lWControlsSortedByRow = lWControls.OrderBy(x => x.R).ToList();
                var numOfRows = lWControlsSortedByRow[lWControlsSortedByRow.Count - 1].R;
                var list = new List<Row>();

                for (int row = 0; row <= numOfRows; row++)
                {
                    var slectedRows = lWControlsSortedByRow.FindAll(x => x.R == row);

                    Row r1 = new Row();
                    r1.type = "div";
                    r1.@class = "row mb-3";

                    var columns = new List<Column>();
                    foreach (var col in slectedRows.OrderBy(y => y.C).ToList())
                    {
                        Column child = new Column();
                        child.type = "div";
                        child.@class = "col-12 col-lg";


                        child.Children = new List<ControllType>()
                        {
                            new ControllType()
                            {
                                type=col.CT+"",
                                style=col.S,

                            }
                        };


                        columns.Add(child);
                    }
                    r1.Children = columns;
                    list.Add(r1);
                }
                var x = list;
                var json = JsonConvert.SerializeObject(list);
                return list;
            }
            catch (Exception ex)
            {

            }
            return null;
        }



        //public static StyleObj ToStyle(string values)
        //{
        //    StyleObj obj = new StyleObj();

        //    if (!string.IsNullOrEmpty(values))
        //    {
        //        string[] value = values.Split(new string[] { "*#" }, StringSplitOptions.None);
        //        obj.Enable = value[(int)StyleArrayIndex.Enable] == "1" ? true : false;
        //        obj.FontColor = value[(int)StyleArrayIndex.FontColor];
        //        obj.FontSize = Convert.ToInt32(value[(int)StyleArrayIndex.FontSize]);
        //        obj.Height = Convert.ToDouble(value[(int)StyleArrayIndex.Height]);
        //        obj.Margin = value[(int)StyleArrayIndex.Margin];

        //        //obj.Padding = value[(int)StyleArrayIndex.padding];
        //        obj.Visibility = value[(int)StyleArrayIndex.Visibility] == "1" ? true : false;
        //        obj.Width = Convert.ToDouble(value[(int)StyleArrayIndex.Width]);

        //        if ((int)StyleArrayIndex.Padding < value.Length)
        //            obj.Padding = value[(int)StyleArrayIndex.Padding];
        //        if ((int)StyleArrayIndex.TextPadding < value.Length)
        //            obj.TextPadding = value[(int)StyleArrayIndex.TextPadding];


        //        if ((int)StyleArrayIndex.ColumnWidth < value.Length)
        //            obj.ColumnWidth = value[(int)StyleArrayIndex.ColumnWidth];

        //        if ((int)StyleArrayIndex.ColSpan < value.Length)
        //            obj.ColSpan = Convert.ToInt32(value[(int)StyleArrayIndex.ColSpan]);
        //        if ((int)StyleArrayIndex.Bold < value.Length)
        //            obj.Bold = value[(int)StyleArrayIndex.Bold] == "1" ? true : false;

        //        if ((int)StyleArrayIndex.Italic < value.Length)
        //            obj.Italic = value[(int)StyleArrayIndex.Italic] == "1" ? true : false;

        //        if ((int)StyleArrayIndex.Underline < value.Length)
        //            obj.Underline = value[(int)StyleArrayIndex.Underline] == "1" ? true : false;

        //        if ((int)StyleArrayIndex.BackGroundColor < value.Length)
        //            obj.BackGroundColor = value[(int)StyleArrayIndex.BackGroundColor];
        //        else
        //            obj.BackGroundColor = "White";

        //        if ((int)StyleArrayIndex.TextAllignment < value.Length)
        //            obj.TextAllignment = (TextHorizondalAlignment)(Convert.ToInt32(value[(int)StyleArrayIndex.TextAllignment]));
        //        else
        //            obj.TextAllignment = TextHorizondalAlignment.Left;

        //        if ((int)StyleArrayIndex.TextVerAllignment < value.Length)
        //            obj.TextVerAllignment = (TextVerticalAlignment)(Convert.ToInt32(value[(int)StyleArrayIndex.TextVerAllignment]));
        //        else
        //            obj.TextVerAllignment = TextVerticalAlignment.Top;

        //        if ((int)StyleArrayIndex.TextFontSelected < value.Length)
        //            obj.TextFontSelected = value[(int)StyleArrayIndex.TextFontSelected];
        //        if ((int)StyleArrayIndex.ReadOnly < value.Length)
        //            obj.ReadOnly = Convert.ToBoolean(value[(int)StyleArrayIndex.ReadOnly]);


        //        if ((int)StyleArrayIndex.Orientation < value.Length)
        //            obj.Orientation = (ControlOrientation)(Convert.ToInt32(value[(int)StyleArrayIndex.Orientation]));
        //        else
        //            obj.Orientation = ControlOrientation.Vertical;


        //        if ((int)StyleArrayIndex.TabIndex < value.Length)
        //            obj.TabIndex = Convert.ToInt32(value[(int)StyleArrayIndex.TabIndex]);
        //        else
        //            obj.TabIndex = 0;

        //        if ((int)StyleArrayIndex.FontFormat < value.Length)
        //            obj.FontFormat = (FontType)(Convert.ToInt32(value[(int)StyleArrayIndex.FontFormat]));
        //        else
        //            obj.FontFormat = FontType.Normal;

        //        if ((int)StyleArrayIndex.BorderColor < value.Length)
        //            obj.BorderColor = Convert.ToString(value[(int)StyleArrayIndex.BorderColor]);

        //        if ((int)StyleArrayIndex.BoxShadow < value.Length)
        //            obj.BoxShadow = Convert.ToString(value[(int)StyleArrayIndex.BoxShadow]);
        //        if ((int)StyleArrayIndex.Padding < value.Length)
        //        {
        //            if (value[(int)StyleArrayIndex.Padding].ToString().Contains(","))
        //                obj.Padding = Convert.ToString(value[(int)StyleArrayIndex.Padding]);
        //            else
        //            {
        //                string padd = string.IsNullOrWhiteSpace(value[(int)StyleArrayIndex.Padding]) ? "0" : value[(int)StyleArrayIndex.Padding];
        //                obj.Padding = padd + ",0,0,0";
        //            }
        //        }
        //        if ((int)StyleArrayIndex.TextPadding < value.Length)
        //        {
        //            if (value[(int)StyleArrayIndex.TextPadding].ToString().Contains(","))
        //                obj.TextPadding = Convert.ToString(value[(int)StyleArrayIndex.TextPadding]);
        //            else
        //            {
        //                string padd = string.IsNullOrWhiteSpace(value[(int)StyleArrayIndex.TextPadding]) ? "0" : value[(int)StyleArrayIndex.TextPadding];
        //                obj.TextPadding = padd + ",0,0,0";
        //            }
        //        }
        //        if ((int)StyleArrayIndex.HeaderHeight < value.Length)
        //        {
        //            obj.RowHeight = string.IsNullOrEmpty(value[(int)StyleArrayIndex.RowHeight]) ? 25 : Convert.ToInt32(value[(int)StyleArrayIndex.RowHeight]);
        //            obj.HeaderHeight = string.IsNullOrEmpty(value[(int)StyleArrayIndex.HeaderHeight]) ? 25 : Convert.ToInt32(value[(int)StyleArrayIndex.HeaderHeight]);
        //        }
        //        else
        //        {
        //            obj.RowHeight = 25;
        //            obj.HeaderHeight = 25;
        //        }

        //        if ((int)StyleArrayIndex.BorderRadius < value.Length && !string.IsNullOrEmpty(value[(int)StyleArrayIndex.BorderRadius]))
        //            obj.BorderRadius = Convert.ToString(value[(int)StyleArrayIndex.BorderRadius]);

        //        if ((int)StyleArrayIndex.BorderThickness < value.Length && !string.IsNullOrEmpty(value[(int)StyleArrayIndex.BorderThickness]))
        //            obj.BorderThickness = Convert.ToString(value[(int)StyleArrayIndex.BorderThickness]);

        //        if ((int)StyleArrayIndex.BorderStyle < value.Length)
        //            obj.BorderStyle = Convert.ToString(value[(int)StyleArrayIndex.BorderStyle]);

        //        if ((int)StyleArrayIndex.LineHeight < value.Length)
        //            obj.LineHeight = Convert.ToString(value[(int)StyleArrayIndex.LineHeight]);

        //        if ((int)StyleArrayIndex.ProgressColor < value.Length)
        //            obj.ProgressColor = Convert.ToString(value[(int)StyleArrayIndex.ProgressColor]);

        //        if ((int)StyleArrayIndex.CornerRadius < value.Length)
        //            obj.CornerRadius = Convert.ToString(value[(int)StyleArrayIndex.CornerRadius]);
        //    }

        //    return obj;
        //}
    }
}
