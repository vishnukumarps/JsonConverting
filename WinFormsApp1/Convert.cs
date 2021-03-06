using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using RestSharp;
using WinFormsApp1.Models;

namespace WinFormsApp1
{
    public partial class Convert : Form
    {
        string  inputText=null;
        public Convert()
        {
            InitializeComponent();
            textBox2.Text = "https://dev.cunextgen.com/ApprenderNew/api/values/default/B48A1D14-D4FE-4E41-8E8E-877BC595A01D";
        }


        void FindChild(List<LWControl> slectedRows)
        {

            // slectedRows.f
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new RestClient("https://dev.cunextgen.com/ApprenderNew/api/values/default/B48A1D14-D4FE-4E41-8E8E-877BC595A01D");
                client.Timeout = -1;
                var request = new RestRequest(Method.GET);
                IRestResponse response = client.Execute(request);
                var parentJson = JsonConvert.DeserializeObject<ParentJson>(response.Content.ToString());

               var formJson = JsonConvert.DeserializeObject<List<LWControl>>(parentJson.FormJson);
                textBox1.Text = formJson.ToString();
               // Console.WriteLine(unescapedJsonString);
            }
            catch (Exception ex)
            {

                textBox1.Text = ex.Message;
            }

            //var dynamicObj = new ExpandoObject();
            //try
            //{
            //    inputText= textBox1.Text;
            //    string jsonString = JsonConvert.DeserializeObject(inputText).ToString().Trim();
            //    var lWControls = JsonConvert.DeserializeObject<List<LWControl>>(inputText);

            //    var lWControlsSortedByRow = lWControls.OrderBy(x => x.R).ToList();
            //    var numOfRows = lWControlsSortedByRow[lWControlsSortedByRow.Count - 1].R;
            //    var list = new List<Row>();

            //    for (int row = 0; row <= numOfRows; row++)
            //    {
            //        var slectedRows = lWControlsSortedByRow.FindAll(x => x.R == row);
                      
            //        Row r1 = new Row();
            //        r1.type = "div";
            //        r1.@class = "row mb-3";

            //        var columns = new List<Column>();
            //        foreach (var col in slectedRows.OrderBy(y => y.C).ToList())
            //        {
            //            Column child = new Column();
            //            child.type = "div";
            //            child.@class = "col-12 col-lg";

            //            child.ControllType = new List<ControllType>()
            //            {
            //                new ControllType()
            //                {
            //                    type=col.CT+"",
            //                    style=col.S,
                                
            //                }
            //            };
                       
            //             columns.Add(child);

                        
            //        }
            //        r1.columns = columns;
            //        list.Add(r1);
            //    }
            //    var x = list;
            //    var json = JsonConvert.SerializeObject(list);
            //}
            //catch (Exception ex)
            //{
            //    textBox1.Text = "";
            //    textBox1.Text = ex.Message;
            //}
        }

        private dynamic recursiveFunction(LWControl col)
        {
            return recursiveFunction(col);

        }

        public class ControllType
        {

            public string type { get; set; }
            public string style { get; set; }
            public string @class { get; set; }
            public string name { get; set; }

        }

        public class Row
        {
            public string type { get; set; }
            public string @class { get; set; }
            public List<Column> columns { get; set; }
        }
        public class Column
        {
   
            public string type { get; set; }
            public string @class { get; set; }
           // public List<Column> columns { get; set; }
            public List<ControllType> ControllType { get; set; }

        }

        public class Child2
        {
            public string type { get; set; }
            public string @class { get; set; }
            public string name { get; set; }
            public string style { get; set; }
        }

        public class LWControl
        {
            public int C { get; set; }
            public int CT { get; set; }
            public int I { get; set; }
            public bool IR { get; set; }
            public bool FC { get; set; }
            public string P { get; set; }
            public int R { get; set; }
            public string S { get; set; }
            public string D { get; set; }
            public string M { get; set; }
            public int? TC { get; set; }
            public string VD { get; set; }
            public bool? RFS { get; set; }
            public string TT { get; set; }
            public string RM { get; set; }
            public string L { get; set; }
            public int? TL { get; set; }
            public string CA { get; set; }
            public string AC { get; set; }
            public string ES { get; set; }
            public int? TI { get; set; }
            public bool? CD { get; set; }
            public int? RH { get; set; }
            public int? RW { get; set; }
            public string SK { get; set; }
            public string PV { get; set; }
            public bool? IK { get; set; }
            public string DX { get; set; }
            public string MI { get; set; }
            public bool? IPO { get; set; }
            public bool? TP { get; set; }
            public string SCA { get; set; }
            public string HB1 { get; set; }
            public string HB2 { get; set; }
            public string ED { get; set; }
            public bool? ITS { get; set; }
            public string MH { get; set; }
            public bool? ILW { get; set; }
            public int? CFU { get; set; }
            public int? AF { get; set; }
            public bool? SDC { get; set; }
            public string BS { get; set; }
            public string EE { get; set; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string json = new WebClient().DownloadString("https://dev.cunextgen.com/ApprenderNew/api/values/default/B48A1D14-D4FE-4E41-8E8E-877BC595A01D");
            //string d = "formJSON";
            int startindex = json.IndexOf("form");
            int endindex = json.Length - startindex;
            string title = json.Substring(startindex, endindex);
            textBox1.Text = title;

        }
    }
}
