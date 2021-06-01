using AppFormsJsonParser.Models;
using AppFormsJsonParser.Utills;
using ClaySys.AppBuilder.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                      
                        if (col.CT == 15)
                        {
                            child.@class = "col-12";
                            child.style =GetDecodedStyle(col.S);
                        }
                        else
                        {
                            child.@class = "col-12 col-lg";
                            child.Children = new List<ControllType>()
                          {
                            new ControllType()
                            {
                               type =Enum.GetName(typeof(ControlTypes), col.CT).ToLower(),
                                style =GetDecodedStyle(col.S)

                        }
                          };
                        }
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

        [HttpGet]
        [Route("/DecodeStyle")]
        public StyleObj DecodeStyle()
        {
            try
            {
                StyleObj styleObj = new StyleObj();
                var x = StyleObj.ToStyle("1*#Black*#11*#23*#0*#1*#150*#White*#0*#Verdana*#false*#0*#0*#0*#*#0*#0*#0*#0*#13*#1*#*#*#0*#*#*#*#*#*#*#*#*#");
                return x ;
            }
            catch (Exception ex)
            {

                throw;
            }
            return null;
        }

        private string  GetDecodedStyle(string encodedStyle)
        {
            StringBuilder sb = new StringBuilder(); 
            try
            {
                StyleObj styleObj = new StyleObj();
                var styleObject = StyleObj.ToStyle(encodedStyle);
                
                sb.Append(nameof(styleObj.Width).ToLower());
                sb.Append(":");
                sb.Append(styleObject.Width+"px");
                sb.Append(";");


                sb.Append(nameof(styleObj.Height).ToLower());
                sb.Append(":");
                sb.Append(styleObject.Height+"px");
                sb.Append(";");




                // TO DO






                return sb.ToString();
            }
            catch (Exception ex)
            {

                throw;
            }
            return null;
        }
    }

    
   
}
