using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonConverting.Models
{
    public enum StyleArrayIndex
    {
       

             Enab,
             
             FontColor,
             
             FontSize,
             
             Height,
             
             Margin,
             
             Visibility ,
             
             Width,
             BackGroundColor,
            
              TextAllignment,
             
             TextFontSelected,
             
             ReadOnly,
             
              Orientation,
             
             TabIndex,
             
             FontFormat,
         
             IsLocked ,
             
             BorderColor,
             
             Padding,
             
             TextPadding,
             
             BorderRadius,
             
             BorderThickness,
             
             BorderStyle,
             
             LineHeight,
             
             ProgressColor,
             
             BoxShadow,
        CornerRadius,
        HeaderHeight,
        TextVerAllignment,
        Underline,
        Italic,
        Enable,
        ColumnWidth,
        RowHeight,
    }
    class Program2
    {

        
        static void Main(string[] args)
        {
            string S = "1*#Black*#11*#23*#0*#1*#150*#White*#0*#Verdana*#false*#0*#0*#0*#*#0*#0*#0*#0*#13*#1*#*#*#0*#*#*#*#*#*#*#*#*#";

            Program2 program2 = new Program2();
            var ss=program2.ToStyle(S);
            int x;
        }



        public  StyleObj ToStyle(string values)
        {
            StyleObj obj = new StyleObj();

            if (!string.IsNullOrEmpty(values))
            {
                string[] value = values.Split(new string[] { "*#" }, StringSplitOptions.None);
                obj.Enable = value[(int)StyleArrayIndex.Enable] == "1" ? true : false;
                obj.FontColor = value[(int)StyleArrayIndex.FontColor];
                obj.FontSize = Convert.ToInt32(value[(int)StyleArrayIndex.FontSize]);
                obj.Height = Convert.ToDouble(value[(int)StyleArrayIndex.Height]);
                obj.Margin = value[(int)StyleArrayIndex.Margin];

                //obj.Padding = value[(int)StyleArrayIndex.padding];
                obj.Visibility = value[(int)StyleArrayIndex.Visibility] == "1" ? true : false;
                obj.Width = Convert.ToDouble(value[(int)StyleArrayIndex.Width]);

                if ((int)StyleArrayIndex.Padding < value.Length)
                    obj.Padding = value[(int)StyleArrayIndex.Padding];
                if ((int)StyleArrayIndex.TextPadding < value.Length)
                    obj.TextPadding = value[(int)StyleArrayIndex.TextPadding];


                if ((int)StyleArrayIndex.ColumnWidth < value.Length)
                    obj.ColumnWidth = value[(int)StyleArrayIndex.ColumnWidth];

               //if ((int)StyleArrayIndex.ColSpan < value.Length)
                    obj.ColSpan = Convert.ToInt32(value[(int)StyleArrayIndex.ColSpan]);
               // if ((int)StyleArrayIndex.Bold < value.Length)
                //    obj.Bold = value[(int)StyleArrayIndex.Bold] == "1" ? true : false;

                if ((int)StyleArrayIndex.Italic < value.Length)
                    obj.Italic = value[(int)StyleArrayIndex.Italic] == "1" ? true : false;

                if ((int)StyleArrayIndex.Underline < value.Length)
                    obj.Underline = value[(int)StyleArrayIndex.Underline] == "1" ? true : false;

                if ((int)StyleArrayIndex.BackGroundColor < value.Length)
                    obj.BackGroundColor = value[(int)StyleArrayIndex.BackGroundColor];
                else
                    obj.BackGroundColor = "White";

                if ((int)StyleArrayIndex.TextAllignment < value.Length) ;
                // obj.TextAllignment = (TextHorizondalAlignment)(Convert.ToInt32(value[(int)StyleArrayIndex.TextAllignment]));
                else
                //   obj.TextAllignment = TextHorizondalAlignment.Left;

                if ((int)StyleArrayIndex.TextVerAllignment < value.Length) ;
                //  obj.TextVerAllignment = (TextVerticalAlignment)(Convert.ToInt32(value[(int)StyleArrayIndex.TextVerAllignment]));
                else
                // obj.TextVerAllignment = TextVerticalAlignment.Top;

                if ((int)StyleArrayIndex.TextFontSelected < value.Length)
                    obj.TextFontSelected = value[(int)StyleArrayIndex.TextFontSelected];
                if ((int)StyleArrayIndex.ReadOnly < value.Length)
                    obj.ReadOnly = Convert.ToBoolean(value[(int)StyleArrayIndex.ReadOnly]);


                if ((int)StyleArrayIndex.Orientation < value.Length) ;
                //obj.Orientation = (ControlOrientation)(Convert.ToInt32(value[(int)StyleArrayIndex.Orientation]));
                else
                //obj.Orientation = ControlOrientation.Vertical;


                if ((int)StyleArrayIndex.TabIndex < value.Length) 
                    obj.TabIndex = Convert.ToInt32(value[(int)StyleArrayIndex.TabIndex]);
                else
                    obj.TabIndex = 0;

                if ((int)StyleArrayIndex.FontFormat < value.Length) ;
                //   obj.FontFormat = (FontType)(Convert.ToInt32(value[(int)StyleArrayIndex.FontFormat]));
                else
                // obj.FontFormat = FontType.Normal;

                if ((int)StyleArrayIndex.BorderColor < value.Length)
                    obj.BorderColor = Convert.ToString(value[(int)StyleArrayIndex.BorderColor]);

                if ((int)StyleArrayIndex.BoxShadow < value.Length)
                    obj.BoxShadow = Convert.ToString(value[(int)StyleArrayIndex.BoxShadow]);
                if ((int)StyleArrayIndex.Padding < value.Length)
                {
                    if (value[(int)StyleArrayIndex.Padding].ToString().Contains(","))
                        obj.Padding = Convert.ToString(value[(int)StyleArrayIndex.Padding]);
                    else
                    {
                        string padd = string.IsNullOrWhiteSpace(value[(int)StyleArrayIndex.Padding]) ? "0" : value[(int)StyleArrayIndex.Padding];
                        obj.Padding = padd + ",0,0,0";
                    }
                }
                if ((int)StyleArrayIndex.TextPadding < value.Length)
                {
                    if (value[(int)StyleArrayIndex.TextPadding].ToString().Contains(","))
                        obj.TextPadding = Convert.ToString(value[(int)StyleArrayIndex.TextPadding]);
                    else
                    {
                        string padd = string.IsNullOrWhiteSpace(value[(int)StyleArrayIndex.TextPadding]) ? "0" : value[(int)StyleArrayIndex.TextPadding];
                        obj.TextPadding = padd + ",0,0,0";
                    }
                }
                if ((int)StyleArrayIndex.HeaderHeight < value.Length)
                {
                    obj.RowHeight = string.IsNullOrEmpty(value[(int)StyleArrayIndex.RowHeight]) ? 25 : Convert.ToInt32(value[(int)StyleArrayIndex.RowHeight]);
                    obj.HeaderHeight = string.IsNullOrEmpty(value[(int)StyleArrayIndex.HeaderHeight]) ? 25 : Convert.ToInt32(value[(int)StyleArrayIndex.HeaderHeight]);
                }
                else
                {
                    obj.RowHeight = 25;
                    obj.HeaderHeight = 25;
                }

                if ((int)StyleArrayIndex.BorderRadius < value.Length && !string.IsNullOrEmpty(value[(int)StyleArrayIndex.BorderRadius]))
                    obj.BorderRadius = Convert.ToString(value[(int)StyleArrayIndex.BorderRadius]);

                if ((int)StyleArrayIndex.BorderThickness < value.Length && !string.IsNullOrEmpty(value[(int)StyleArrayIndex.BorderThickness]))
                    obj.BorderThickness = Convert.ToString(value[(int)StyleArrayIndex.BorderThickness]);

                if ((int)StyleArrayIndex.BorderStyle < value.Length)
                    obj.BorderStyle = Convert.ToString(value[(int)StyleArrayIndex.BorderStyle]);

                if ((int)StyleArrayIndex.LineHeight < value.Length)
                    obj.LineHeight = Convert.ToString(value[(int)StyleArrayIndex.LineHeight]);

                if ((int)StyleArrayIndex.ProgressColor < value.Length)
                    obj.ProgressColor = Convert.ToString(value[(int)StyleArrayIndex.ProgressColor]);

                if ((int)StyleArrayIndex.CornerRadius < value.Length)
                    obj.CornerRadius = Convert.ToString(value[(int)StyleArrayIndex.CornerRadius]);
            }

            return obj;
        }
    }

    public class StyleObj
    {
        public string CornerRadius { get; internal set; }
        public string ProgressColor { get; internal set; }
        public string LineHeight { get; internal set; }
        public string BorderStyle { get; internal set; }
        public string BorderThickness { get; internal set; }
        public string BorderRadius { get; internal set; }
        public int RowHeight { get; internal set; }
        public int HeaderHeight { get; internal set; }
        public string TextPadding { get; internal set; }
        public string Padding { get; internal set; }
        public string BoxShadow { get; internal set; }
        public string BorderColor { get; internal set; }
        public object FontFormat { get; internal set; }
        public int TabIndex { get; internal set; }
        public object Orientation { get; internal set; }
        public bool ReadOnly { get; internal set; }
        public string TextFontSelected { get; internal set; }
        public object TextVerAllignment { get; internal set; }
        public object TextAllignment { get; internal set; }
        public string BackGroundColor { get; internal set; }
        public bool Underline { get; internal set; }
        public bool Italic { get; internal set; }
        public bool Bold { get; internal set; }
        public int ColSpan { get; internal set; }
        public string ColumnWidth { get; internal set; }
        public double Width { get; internal set; }
        public bool Enable { get; internal set; }
        public string FontColor { get; internal set; }
        public bool Visibility { get; internal set; }
        public string Margin { get; internal set; }
        public double Height { get; internal set; }
        public int FontSize { get; internal set; }
    }
}
