using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace ClaySys.AppBuilder.Models
{
    [Serializable, DataContract]
    public class StyleObj
    {
        /// <summary>
        /// Contains Style properties of a control 
        /// </summary>
        public enum StyleArrayIndex
        {
            Enable = 0,
            FontColor = 1,
            FontSize = 2,
            Height = 3,
            Margin = 4,
            Visibility = 5,
            Width = 6,
            BackGroundColor = 7,
            TextAllignment = 8,
            TextFontSelected = 9,
            ReadOnly = 10,
            Orientation = 11,
            TabIndex = 12,
            FontFormat = 13,
            IsLocked = 14,
            TextVerAllignment = 15,
            Bold = 16,
            Italic = 17,
            Underline = 18,
            ColumnWidth = 19,
            ColSpan = 20,
            BorderColor = 21,
            BoxShadow = 22,
            Padding = 23,
            TextPadding=24,
            BorderRadius=25,
            BorderThickness=26,
            BorderStyle=27,
            LineHeight=28,
            ProgressColor=29,
            RowHeight = 30,
            HeaderHeight = 31,
            CornerRadius = 32
        }

        private bool _readOnly;
        [DataMember]
        public bool ReadOnly
        {
            get
            {
                return _readOnly;
            }
            set
            {
                _readOnly = value;
            }
        }
        [DataMember]
     //   public ControlClass ParentCtrlClass { get; set; }

        private List<string> _TextFont;
        [DataMember]
        public List<string> TextFont
        {
            get
            {
                if (this._TextFont != null)
                {
                    _TextFont = new List<string>();
                }
                return _TextFont;
            }
            set
            {
                _TextFont = value;
            }
        }

        private bool _visibility;
        [DataMember]
        public bool Visibility
        {
            get
            {
                return _visibility;
            }
            set
            {
                _visibility = value;
            }
        }

        private bool _enable;
        [DataMember]
        public bool Enable
        {
            get
            {
                return _enable;
            }
            set
            {
                //if (!paused && IsLocked)
                // return;

                //if (this.ParentCtrlClass != null && this.ParentCtrlClass.Security != null)
                //{
                //    if (this.ParentCtrlClass.Security.Update)
                //    {
                //        _enable = value;

                //    }
                //    else
                //    {
                //        _enable = false;
                //    }
                
               
                
                    _enable = value;
                

            }
        }
        private int rowHeight;
        [DataMember]
        public int RowHeight
        {
            get { return rowHeight; }
            set { rowHeight = value; }
        }
        private int headerHeight;
        [DataMember]
        public int HeaderHeight
        {
            get { return headerHeight; }
            set { headerHeight = value; }
        }


        private TextHorizondalAlignment _textAllignment;
        [DataMember]
        public TextHorizondalAlignment TextAllignment
        {
            get
            {
                return _textAllignment;
            }
            set
            {
                _textAllignment = value;
            }
        }

        private bool _bold;
        [DataMember]
        public bool Bold
        {
            get
            {
                return _bold;
            }
            set
            {
                _bold = value;

            }
        }

        private bool _italic;
        [DataMember]
        public bool Italic
        {
            get
            {
                return _italic;
            }
            set
            {
                _italic = value;

            }
        }

        string _padding;
        [DataMember]
        public string Padding
        {
            get
            {
                return _padding;
            }
            set { _padding = value; }
        }
        //For CheckBox and RadioButton, property 'item.Style.TextPadding' is used for setting Padding 
        //And 'item.Style.Padding' is used for setting TextPadding (This is to avoid Backward Compatibility Issues)
        string _textPadding;
        [DataMember]
        public string TextPadding
        {
            get
            {
                return _textPadding;
            }
            set { _textPadding = value; }
        }

        private bool _undeline;
        [DataMember]
        public bool Underline
        {
            get
            {
                return _undeline;
            }
            set
            {
                _undeline = value;

            }
        }

        private TextVerticalAlignment _textVerAllignment;
        [DataMember]
        public TextVerticalAlignment TextVerAllignment
        {
            get
            {
                return _textVerAllignment;
            }
            set
            {
                _textVerAllignment = value;
            }
        }

        private ControlOrientation _orientation;

        [DataMember]
        public ControlOrientation Orientation
        {
            get
            {
                return _orientation;
            }
            set
            {
                _orientation = value;
            }
        }


        private int _tabIndex;

        [DataMember]
        public int TabIndex
        {
            get
            {
                return _tabIndex;
            }
            set
            {
                _tabIndex = value;
            }
        }



        private double _fontsize;
        [DataMember]
        public double FontSize
        {
            get
            {
                return _fontsize;      //(_fontsize / 90 * 100) - 1;
            }
            set
            {
                _fontsize = value;
            }
        }

        private string _fontWeight;
        [DataMember]
        [JsonProperty(Order = 2)]
        public string FontWeight
        {
            get
            {
                return _fontWeight;
            }
            set
            {
                _fontWeight = value;
            }
        }

        private string _fontStyle;
        [DataMember]
        public string FontStyle
        {
            get
            {
                return _fontStyle;
            }
            set
            {
                _fontStyle = value;
            }
        }

        private FontType _fontFormat;
        [DataMember]
        [JsonProperty(Order = 1)]
        public FontType FontFormat
        {
            get
            {
                return _fontFormat;
            }
            set
            {
                _fontFormat = value;
                ManageFontFormat(value);
            }
        }

        private void ManageFontFormat(FontType Type)
        {
            switch (Type)
            {
                case FontType.Normal:
                    FontWeight = "Normal";
                    FontStyle = "Normal";
                    break;
                case FontType.Bold:
                    FontWeight = "Bold";
                    FontStyle = "Normal";
                    break;
                case FontType.Italics:
                    FontWeight = "Normal";
                    FontStyle = "Italic";
                    break;
                case FontType.BoldItalics:
                    FontWeight = "Bold";
                    FontStyle = "Italic";
                    break;
                default:
                    break;
            }

        }



        double _width;
        [DataMember]
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;
            }
        }

        double _height;
        [DataMember]
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
            }
        }

        string _margin;
        [DataMember]
        public string Margin
        {
            get { return _margin; }
            set { _margin = value; }
        }

        private string _fontcolor;
        [DataMember]
        public string FontColor
        {
            get
            {
                return _fontcolor;
            }
            set
            {
                if (value.Contains("#") && value.Length > 7)
                {
                    value = "#" + value.Substring(3);
                }
                _fontcolor = value;
            }
        }

        private string _backGroundColor;
        [DataMember]
        public string BackGroundColor
        {
            get
            {
                return _backGroundColor;
            }
            set
            {
                if (value.Contains("#") && value.Length >= 9 && !value.Contains(";"))
                {
                    value = "#" + value.Substring(3);
                }
                _backGroundColor = value;
            }
        }
        private string _textFontSelected;
        [DataMember]
        public string TextFontSelected
        {
            get
            {
                return _textFontSelected;
            }
            set
            {
                _textFontSelected = value;
            }
        }

        private string _borderColor;
        [DataMember]
        public string BorderColor
        {
            get
            {
                return _borderColor;
            }
            set
            {
                if (value != null && value.Contains("#") && value.Length > 7)
                {
                    value = "#" + value.Substring(3);
                }
                _borderColor = value;
            }
        }


        private string _boxShadow;
        [DataMember]
        public string BoxShadow
        {
            get
            {
                return _boxShadow;
            }
            set
            {
                //if (value != null && value.Contains("#"))
                //{
                //    value = "#" + value.Substring(3);
                //}
                _boxShadow = value;

            }
        }
        private bool _isLocked;
        [DataMember]
        public bool IsLocked
        {
            get
            {
                return _isLocked;
            }
            set
            {
                _isLocked = value;
            }
        }
        private string _columnWidth;

        [DataMember]
        public string ColumnWidth
        {
            get
            {
                return _columnWidth;
            }
            set
            {
                _columnWidth = value;

            }
        }

        private int _colSpan;

        public int ColSpan
        {
            get
            {
                return _colSpan;
            }
            set
            {
                _colSpan = value;

            }
        }

        private string _borderRadius;
        [DataMember]
        public string BorderRadius
        {
            get
            {
                return _borderRadius;
            }
            set
            {
                _borderRadius = value;
            }
        }
        private string _cornerRadius;
        [DataMember]
        public string CornerRadius
        {
            get
            {
                return _cornerRadius;
            }
            set
            {
                _cornerRadius = value;
            }
        }

        private string _borderThickness;
        [DataMember]
        public string BorderThickness
        {
            get
            {
                return _borderThickness;
            }
            set
            {
                _borderThickness = value;
            }
        }


        private string _borderStyle;
        [DataMember]
        public string BorderStyle
        {
            get
            {
                return _borderStyle;
            }
            set
            {
                _borderStyle = value;
            }
        }

        private string _lineHeight;
        [DataMember]
        public string LineHeight
        {
            get
            {
                return _lineHeight;
            }
            set
            {
                _lineHeight = value;
            }
        }

        private string _progressColor;
        [DataMember]
        public string ProgressColor
        {
            get
            {
                return _progressColor;
            }
            set
            {
                _progressColor = value;
            }
        }

        public StyleObj()
        {
            this.Visibility = true;
            this.Enable = true;
            this.FontSize = 10;
            this.FontColor = "Black";
            this.FontFormat = FontType.Normal;
            this.Width = 100;
            this.Height = 23;
            this.Margin = "0,0,0,0";
            this.Padding = "0,0,0,0";
            this.TextPadding = "0,0,0,0";
            this.BackGroundColor = "White";
            this.TextAllignment = TextHorizondalAlignment.Left;
            this.TextVerAllignment = TextVerticalAlignment.Top;
            this.Orientation = ControlOrientation.Vertical;
            TextFont = new List<string>();
            TextFontSelected = string.Empty;
            this.ReadOnly = false;
            this.TabIndex = 0;
            this.Bold = false;
            this.Italic = false;
            this.Underline = false;
            this.ColSpan = 1;
            this.Padding = string.Empty;
            this.TextPadding = string.Empty;
            this.BorderRadius = "0,0,0,0";
            this.BorderThickness = "0,0,0,0";
            this.BorderStyle = string.Empty;
            this.LineHeight = string.Empty;
            this.ProgressColor = string.Empty;
            this.CornerRadius = "3";

        }

        public override string ToString()
        {
            StringBuilder sbValue = new StringBuilder();

            sbValue.Append(Enable == true ? 1 : 0);
            sbValue.Append("*#");
            sbValue.Append(FontColor);
            sbValue.Append("*#");
            sbValue.Append(FontSize);
            sbValue.Append("*#");
            sbValue.Append(Height);
            sbValue.Append("*#");
            sbValue.Append(Margin);
            sbValue.Append("*#");
            sbValue.Append(Visibility == true ? 1 : 0);
            sbValue.Append("*#");
            sbValue.Append(Width);
            sbValue.Append("*#");
            sbValue.Append(BackGroundColor);
            sbValue.Append("*#");
            sbValue.Append(((int)TextAllignment).ToString());
            sbValue.Append("*#");
            sbValue.Append(TextFontSelected);
            sbValue.Append("*#");
            sbValue.Append(ReadOnly);
            sbValue.Append("*#");
            sbValue.Append(((int)Orientation).ToString());
            sbValue.Append("*#");
            sbValue.Append(TabIndex);
            sbValue.Append("*#");
            sbValue.Append((int)FontFormat).ToString();
            sbValue.Append("*#");
            sbValue.Append(IsLocked == true ? 1 : 0);
            sbValue.Append("*#");
            sbValue.Append(BorderColor);
            sbValue.Append("*#");
            sbValue.Append(Padding);
            sbValue.Append("*#");
            sbValue.Append(TextPadding);
            sbValue.Append("*#");
            sbValue.Append(BorderRadius);
            sbValue.Append("*#");
            sbValue.Append(BorderThickness);
            sbValue.Append("*#");
            sbValue.Append(BorderStyle);
            sbValue.Append("*#");
            sbValue.Append(LineHeight);
            sbValue.Append("*#");
            sbValue.Append(ProgressColor);
            sbValue.Append("*#");
            sbValue.Append(BoxShadow);
            return sbValue.ToString();
        }

        public static StyleObj ToStyle(string values)
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

                if ((int)StyleArrayIndex.ColSpan < value.Length)
                    obj.ColSpan = Convert.ToInt32(value[(int)StyleArrayIndex.ColSpan]);
                if ((int)StyleArrayIndex.Bold < value.Length)
                    obj.Bold = value[(int)StyleArrayIndex.Bold] == "1" ? true : false;

                if ((int)StyleArrayIndex.Italic < value.Length)
                    obj.Italic = value[(int)StyleArrayIndex.Italic] == "1" ? true : false;

                if ((int)StyleArrayIndex.Underline < value.Length)
                    obj.Underline = value[(int)StyleArrayIndex.Underline] == "1" ? true : false;

                if ((int)StyleArrayIndex.BackGroundColor < value.Length)
                    obj.BackGroundColor = value[(int)StyleArrayIndex.BackGroundColor];
                else
                    obj.BackGroundColor = "White";

                if ((int)StyleArrayIndex.TextAllignment < value.Length)
                    obj.TextAllignment = (TextHorizondalAlignment)(Convert.ToInt32(value[(int)StyleArrayIndex.TextAllignment]));
                else
                    obj.TextAllignment = TextHorizondalAlignment.Left;

                if ((int)StyleArrayIndex.TextVerAllignment < value.Length)
                    obj.TextVerAllignment = (TextVerticalAlignment)(Convert.ToInt32(value[(int)StyleArrayIndex.TextVerAllignment]));
                else
                    obj.TextVerAllignment = TextVerticalAlignment.Top;

                if ((int)StyleArrayIndex.TextFontSelected < value.Length)
                    obj.TextFontSelected = value[(int)StyleArrayIndex.TextFontSelected];
                if ((int)StyleArrayIndex.ReadOnly < value.Length)
                    obj.ReadOnly = Convert.ToBoolean(value[(int)StyleArrayIndex.ReadOnly]);


                if ((int)StyleArrayIndex.Orientation < value.Length)
                    obj.Orientation = (ControlOrientation)(Convert.ToInt32(value[(int)StyleArrayIndex.Orientation]));
                else
                    obj.Orientation = ControlOrientation.Vertical;


                if ((int)StyleArrayIndex.TabIndex < value.Length)
                    obj.TabIndex = Convert.ToInt32(value[(int)StyleArrayIndex.TabIndex]);
                else
                    obj.TabIndex = 0;

                if ((int)StyleArrayIndex.FontFormat < value.Length)
                    obj.FontFormat = (FontType)(Convert.ToInt32(value[(int)StyleArrayIndex.FontFormat]));
                else
                    obj.FontFormat = FontType.Normal;

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

       public enum TextHorizondalAlignment
        {
            Left
        }
       public enum TextVerticalAlignment
        {
            Top
        }
       public enum ControlOrientation
        {
            Vertical
        }
       public enum FontType
        {
            Normal,
            Bold,
            Italics,
            BoldItalics
        }
    }
}
