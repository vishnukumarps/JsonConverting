
namespace ClaySys.AppBuilder.Models
{

    public class LWControl
    {
        #region  Property

        /// <summary>
        /// ID 
        /// </summary>
        public int I { get; set; }

        /// <summary>
        /// Control Type
        /// </summary>
        public int CT { get; set; }

        /// <summary>
        /// Row
        /// </summary>
        public int R { get; set; }

        /// <summary>
        /// Column
        /// </summary>
        public int C { get; set; }

        /// <summary>
        /// TextCase
        /// </summary>
        public int TC { get; set; }

        /// <summary>
        /// Value
        /// </summary>
        public object V { get; set; }

        public string TX { get; set; }

        /// <summary>
        /// Control Name
        /// </summary>
        public string N { get; set; }

        /// <summary>
        /// Items
        /// </summary>
        public string IT { get; set; }

        /// <summary>
        /// Validation
        /// </summary>
        public string VD { get; set; }

        /// <summary>
        /// DataSource
        /// </summary>
        public string D { get; set; }

        /// <summary>
        /// MappedColumn
        /// </summary>
        public string M { get; set; }

        /// <summary>
        /// DataType
        /// </summary>
        public string DT { get; set; }

        /// <summary>
        /// Style
        /// </summary>
        public string S { get; set; }

        /// <summary>
        /// ControlGroup
        /// </summary>
        public string G { get; set; }

        /// <summary>
        /// Group Name
        /// </summary>
        public string GN { get; set; }

        /// <summary>
        /// ParentID
        /// </summary>
        public string P { get; set; }

        /// <summary>
        /// TabName
        /// </summary>
        public string T { get; set; }

        /// <summary>
        /// IsRootControl
        /// </summary>
        public bool IR { get; set; }

        /// <summary>
        /// IsFormControl
        /// </summary>
        public bool FC { get; set; }

        /// <summary>
        /// ToolTip
        /// </summary>
        public string TT { get; set; }

        /// <summary>
        /// Remarks
        /// </summary>
        public string RM { get; set; }

        /// <summary>
        /// Label
        /// </summary>
        public string L { get; set; }

        /// <summary>
        /// CustomControlConfig
        /// </summary>
        public string XC { get; set; }

        /// <summary>
        /// DisplayText
        /// </summary>
        public string DX { get; set; }
        /// <summary>
        /// Click Action
        /// </summary>
        public string CA { get; set; }
        /// <summary>
        /// Text Max Length of TextBox
        /// </summary>
        public int TL { get; set; }
        /// <summary>
        /// Validation On Save -- For Validation Control
        /// </summary>
        public bool VS { get; set; }

        /// <summary>
        ///  Validate On Save -- Required Field Validatior
        /// </summary>
        public bool RFS { get; set; }

        /// <summary>
        /// XMLValue
        /// </summary>
        public string XV { get; set; }

        /// <summary>
        /// EnableSearch
        /// </summary>
        public string ES { get; set; }
        /// <summary>
        /// SpellCheckRequired
        /// </summary>
        public bool SR { get; set; }

        /// <summary>
        /// ShortcutKey
        /// </summary>
        public string SK { get; set; }

        /// <summary>
        /// AllowClear
        /// </summary>
        public string AC { get; set; }

        /// <summary>
        /// TabIndex
        /// </summary>
        public int TI { get; set; }

        /// <summary>
        /// CheckDirty
        /// </summary>
        public bool CD { get; set; }
        /// <summary>
        /// ShowDirty
        /// </summary>
        public bool SDC { get; set; }

        /// <summary>
        /// SelectAll
        /// </summary>
        public bool SA { get; set; }

        /// <summary>
        /// RowHeight
        /// </summary>
        public double RH { get; set; }

        /// <summary>
        /// RowWidth
        /// </summary>
        public double RW { get; set; }

        /// <summary>
        /// Prevalue, used only in case of combobox
        /// </summary>
        public object PV { get; set; }

        /// <summary>
        /// InvokeKeyChange
        /// </summary>
        public bool IK { get; set; }

        /// <summary>
        /// Misc
        /// </summary>
        public string MI { get; set; }

        /// <summary>
        /// IsPopupOpen
        /// </summary>
        public bool IPO { get; set; }

        ///// <summary>
        ///// SelectedItem
        ///// </summary>
        //public string SI { get; set; }

        ///<summary>
        ///ListDetails
        ///</summary>
        public string LD { get; set; }

        /// <summary>
        /// TriggerOnPaging
        /// </summary>
        public bool TP { get; set; }
        // public string  SCA { get; set; }
        /// <summary>
        /// IsADB
        /// </summary>
        public bool ADB { get; set; }

        /// <summary>
        /// EncryptData
        /// </summary>
        public string ED { get; set; }

        /// <summary>
        /// Unique
        /// </summary>
        public string UN { get; set; }

        /// <summary>
        /// AllowMax
        /// </summary>
        public string AL { get; set; }

        /// <summary>
        /// AutoHeight
        /// </summary>
        public bool AH { get; set; }

        /// <summary>
        /// HdnBackward1
        /// </summary>
        public string HB1 { get; set; }

        /// <summary>
        /// HdnBackward2
        /// </summary>
        public string HB2 { get; set; }

        /// <summary>
        /// PropertyValue
        /// </summary>
        public string PrV { get; set; }
        /// <summary>
        /// LightWeight Search
        /// </summary>
        public bool ILW { get; set; }

        /// <summary>
        /// Interval
        /// </summary>
        public int IL { get; set; }
        public string SD { get; set; }
        public string EV { get; set; }
        /// <summary>
        /// MaxHeight
        /// </summary>
        public string MH { get; set; }
        /// <summary>
        /// Separator
        /// </summary>
        public string SPR { get; set; }

        /// <summary>
        /// CurrencyFractionalUnits
        /// </summary>
        public int CFU { get; set; }
        /// <summary>
        /// Accounting Format
        /// </summary>
        public int AF { get; set; }
        /// <summary>
        /// Accounting Format
        /// </summary>
        public bool TW { get; set; }
        /// <summary>
        /// Static Data
        /// </summary>
        public string STD { get; set; }

        /// <summary>
        /// BorderType
        /// </summary>
        public string BT { get; set; }
        /// <summary>
        /// TabControlTemplate
        /// </summary>
        public string TTC { get; set; }
        /// <summary>
        /// JSON Date
        /// </summary>
        public bool JD { get; set; }
        /// <summary>
        /// Exclude Extention
        /// </summary>
        public string EE { get; set; }

        /// <summary>
        /// PlaceHolder
        /// </summary>
        public string PH { get; set; }

        /// <summary>
        /// Borderstyle
        /// </summary>
        public string BS { get; set; }

        /// <summary>
        /// AttachedLabelBorderstyle
        /// </summary>
        public string ALBS { get; set; }


        /// <summary>
        /// CSSName
        /// </summary>
        public string CSN { get; set; }
        #endregion

        #region Constructor

        public LWControl()
        {
            T = string.Empty;
            P = string.Empty;
            G = string.Empty;
            S = string.Empty;
            M = string.Empty;
            D = string.Empty;
            VD = string.Empty;
            IT = string.Empty;
            N = string.Empty;
            V = string.Empty;
            DT = string.Empty;
            TT = string.Empty;
            RM = string.Empty;
            XV = string.Empty;
            GN = string.Empty;
            LD = string.Empty;
            EV = string.Empty;
            MH = string.Empty;
            SPR = string.Empty;
            CFU = 2;
            BT = string.Empty;
            TTC = string.Empty;
            EE = string.Empty;
        }

        #endregion
    }
}
