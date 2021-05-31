using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using ClaySys.AppForms.Model;
using ClaySys.AppForms.Model.ADB;
using Newtonsoft.Json;
using ClaySys.AppForms.Model.Models.DG;
using System.Web;
using ClaySys.AppForms.Model.Models;

namespace ClaySys.AppBuilder.Models
{
    [Serializable, DataContract]
    [KnownType(typeof(List<Item>))]
    [KnownType(typeof(List<List<Item>>))]
    [KnownType(typeof(SearchViewModel))]
    [KnownType(typeof(List<Attachment>))]
    //[KnownType(typeof(ControlClass[]))]
    [KnownType(typeof(List<ControlClass>))]
    [KnownType(typeof(KeyValuePair<string, string>))]
    [KnownType(typeof(List<List<SearchCustomView>>))]
    [KnownType(typeof(Attachment))]
    [KnownType(typeof(StringBuilder))]
    public class ControlClass : EntityBase, ICloneable
    {

        #region  Property

        private bool _triggerOnPaging;
        [DataMember]
        public bool TriggerOnPaging
        {
            get
            {
                return _triggerOnPaging;
            }
            set
            {
                _triggerOnPaging = value;
            }
        }
        private int _secureMode;
        [DataMember]
        public int SecureMode
        {
            get
            {
                return _secureMode;
            }
            set
            {
                _secureMode = value;
            }
        }
        private string _searchAction;
        public string SearchAction
        {
            get
            {
                return _searchAction;
            }
            set
            {
                _searchAction = value;
            }
        }



        private string _shortcutKey;
        [DataMember]
        public string ShortcutKey
        {
            get
            {
                return _shortcutKey;
            }
            set
            {
                _shortcutKey = value;
            }
        }

        private bool _spellCheckRequired;

        /// <summary>
        /// This is used for textbox,listbox multy selection 
        /// </summary>
        /// 
        [DataMember]
        public bool SpellCheckRequired
        {
            get
            {
                return _spellCheckRequired;
            }
            set
            {
                _spellCheckRequired = value;

            }
        }

        private string _allowClear;
        [DataMember]
        public string AllowClear
        {
            get
            {
                return _allowClear;
            }
            set
            {
                _allowClear = value;
            }
        }
        private string _enableSearch;
        [DataMember]
        public string EnableSearch
        {
            get
            {
                return _enableSearch;
            }
            set
            {
                _enableSearch = value;
            }
        }

        private string _text = "NON";
        [DataMember]
        public string Text
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
            }
        }

        string _controlGroup;
        [DataMember]
        public string ControlGroup
        {
            get { return _controlGroup; }
            set
            {
                _controlGroup = value;
            }
        }

        private string _group;
        [DataMember]
        public string Group
        {
            get
            {
                return _group;
            }
            set
            {
                _group = value;
            }
        }

        public void SetControlGroup(string value)
        {
            _controlGroup = value;
        }

        public List<string> splitUser(string userName, char p)
        {
            List<string> userCollection = new List<string>();
            string newUser = string.Empty;
            int strLength = userName.Length;
            if (strLength == 0) return userCollection;
            char[] ary = userName.ToCharArray();

            for (int i = 0; i <= strLength; i++)
            {
                if (ary[i] == p || strLength == i + 1)
                {
                    isUserNameEnd(ref newUser, strLength, ary, ref i, p);
                    newUser = newUser.Trim();
                    if (!string.IsNullOrEmpty(newUser))
                        userCollection.Add(newUser);
                    newUser = string.Empty;
                }
                else
                    newUser = newUser + ary[i];
            }
            return userCollection;
        }

        public void isUserNameEnd(ref string newUser, int strLength, char[] ary, ref int i, char p)
        {
            for (int jSemi = i + 1; jSemi <= strLength; jSemi++)
            {
                if (strLength == jSemi && ary[i] != p)
                {
                    newUser = newUser + ary[i];
                    i = jSemi;
                }
                else if (strLength != jSemi)
                {
                    if (ary[jSemi] == p || ary[jSemi] == ' ')
                        newUser = newUser + ary[jSemi];
                    else
                    {
                        i = jSemi - 1;
                        break;
                    }
                }
                else
                    i = jSemi;
            }
        }

        string _parentID;
        [DataMember]
        public string ParentID
        {
            get { return _parentID; }
            set { _parentID = value; }
        }

        string _tabName;

        [DataMember]
        public string TabName
        {
            //For Listbox Select mode also
            get
            {
                return _tabName;
            }
            set
            {
                _tabName = value;
            }
        }

        private int _NoOfTabs;
        [DataMember]
        public int NoOfTabs
        {
            get
            {
                return _NoOfTabs;
            }
            set
            {
                _NoOfTabs = value;
            }
        }

        bool _isRootControl;
        [DataMember]
        public bool IsRootControl
        {
            get { return _isRootControl; }
            set { _isRootControl = value; }
        }

        bool _isPopupOpen;
        [DataMember]
        //based on this property keeping byte array
        public bool IsPopupOpen
        {
            get
            {
                //if (ControlType == ControlTypes.RadioButtonGroup)
                //{
                //    return !_isPopupOpen;
                //}
                //else
                //{
                return _isPopupOpen;
                // }

            }
            set
            {
                //if (ControlType == ControlTypes.RadioButtonGroup)
                //{
                //    _isPopupOpen = !value;
                //}
                //else
                //{
                _isPopupOpen = value;
                // }

            }
        }
        [DataMember]
        public List<SpreadsheetData> SpreadsheetData { get; set; }


        private List<Item> _items;
        [DataMember]
        public List<Item> Items
        {
            get
            {
                return _items;
            }
            set
            {
                _items = value;
            }
        }
        [DataMember]
        public List<Row> Rows;

        private StyleObj _style;
        [DataMember]
        public StyleObj Style
        {
            get { return _style; }
            set
            {
                _style = value; //NotifyPropertyChange("Style"); 
            }

        }

        [DataMember]
        public BorderStyleObj BorderStyle { get; set; }

        [DataMember]
        public AttachedLabelBorderStyleObj AttachedLabelBorder { get; set; }


        private List<Item> _tempItems;
        [DataMember]
        public List<Item> TempItems
        {
            get
            {
                return _tempItems;
            }
            set
            {
                _tempItems = value;
            }
        }

        private bool _invokeKeyChange;
        [DataMember]
        public bool InvokeKeyChange
        {
            get
            {
                return _invokeKeyChange;
            }
            set
            {
                _invokeKeyChange = value;

            }

        }

        string _itemCollectionString = string.Empty;
        [DataMember]
        public string ItemCollectionString
        {
            get
            {
                return _itemCollectionString;
            }
            set
            {
                _itemCollectionString = value;
                if (Text == "DataSource")
                {
                    if (Items != null)
                        Items.Clear();

                }
                else if (Text == "Static")
                {
                    List<Item> temp;
                    if (Items == null)
                        temp = new List<Item>();
                    else
                        temp = Items;

                    if (!string.IsNullOrEmpty(_itemCollectionString))
                    {
                        // _itemCollectionString = _itemCollectionString + "\r";
                        temp.Clear();//To Be Removed.

                        int i = 0;
                        foreach (string item in _itemCollectionString.Split(new string[] { "\r" }, StringSplitOptions.None))
                        {
                            //Add logic to keep existing items.
                            temp.Add(new Item(item, item, false, this));
                            i++;
                        }
                    }
                    _items = temp;
                }
            }
        }

        MappedColumnObj _mappedColumn;
        [DataMember]
        public MappedColumnObj MappedColumn
        {
            get { return _mappedColumn; }
            set { _mappedColumn = value; }
        }

        DataSourceObj _dataSource;
        [DataMember]
        public DataSourceObj DataSource
        {
            get { return _dataSource; }
            set
            {
                _dataSource = value;
            }
        }

        ValidationObj _validation;
        [DataMember]
        public ValidationObj Validation
        {
            get
            {
                return _validation;
            }
            set
            {
                _validation = value;
            }
        }

        private CustomControlConfig _controlConfig;
        [DataMember]
        public CustomControlConfig ControlConfig
        {
            get
            {
                return _controlConfig;
            }
            set
            {
                _controlConfig = value;
            }
        }

        private ClickActions _clickAction;
        [DataMember]
        public ClickActions ClickAction
        {
            get
            {
                return _clickAction;
            }
            set
            {
                _clickAction = value;
            }
        }

        //private StyleObj _style;
        //public StyleObj Style
        //{
        //    get { return _style; }
        //    set
        //    {
        //        _style = value;
        //    }
        //    //get { return GetStyle(); }
        //    //set { _style = value; SetStyle(value);  }
        //}

        /// <summary>
        /// The Format of Date
        /// NB: the Selected Data is in Text property of this class
        /// </summary>
        private List<string> _dateFormat;
        [DataMember]
        public List<string> DateFormat
        {
            get
            {
                if (this._dateFormat == null)
                {
                    this._dateFormat = new List<string>();

                }
                return FillDateType();
            }
            set
            {
                // _dateFormat = value;

            }
        }

        DataTypeObj _dataTypeObj;
        [DataMember]
        public DataTypeObj DataType
        {
            get { return _dataTypeObj; }
            set { _dataTypeObj = value; }
        }

        Label _label;
        [DataMember]
        public Label Label
        {
            get { return _label; }
            set { _label = value; }
        }

        private string _xmlValue;
        [DataMember]
        public string XMLValue
        {
            get
            {
                return _xmlValue;
            }
            set
            {
                _xmlValue = value;
                if (!string.IsNullOrEmpty(_xmlValue))
                {
                    switch (this.ControlType)
                    {
                        case ControlTypes.Grid:
                        case ControlTypes.GridView:
                            this.Value = _xmlValue;
                            break;
                        case ControlTypes.RadioButtonGroup:
                        case ControlTypes.CheckBoxGroup:
                        case ControlTypes.ListBox:
                        case ControlTypes.ComboBox:
                            /// this.Items = null;//_xmlValue; tbd
                            break;
                        case ControlTypes.TreeView:
                            break;
                        case ControlTypes.Search:
                            if (this.Value != null && this.Value.GetType().ToString() != "System.String")
                            {
                                //The XMLValue is set only in the case of rendering engine.
                                this.Value.SetProperty("XMLData", _xmlValue);
                            }
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    if (this.ControlType == ControlTypes.PeoplePicker)
                    {
                        _xmlValue = "false";
                    }
                }

            }
        }

        private string _xmlData;
        [DataMember]
        public string XMLData
        {
            get
            {
                // _xmlData = ConvertClass.CreateGridXML(this);
                if (!string.IsNullOrEmpty(_xmlData))
                {
                    return _xmlData;
                }
                else
                {
                    return string.Empty;
                }
            }
            set
            {
                //_xmlData = value;
                //NotifyPropertyChange("XMLData");
                //ConvertClass.CreateGridDataFromXML(_xmlValue, this);
            }
        }
        private ObservableCollection<ValidationControlsError> errors;
        [DataMember]
        public ObservableCollection<ValidationControlsError> Errors
        {
            get
            {
                return errors;
            }
            set
            {
                if (value == null)
                    value = new ObservableCollection<ValidationControlsError>();
                errors = value;

            }
        }
        private object _value = string.Empty;


        //public object Value
        //{
        //    get
        //    {
        //        return _value;
        //    }
        //    set
        //    {
        //        if (value.GetType().ToString() == "System.String[]")
        //        {
        //            System.String[] strVal = (System.String[])value;
        //            _value = strVal[0];
        //        }
        //        else
        //            _value = value;
        //    }
        //}
        [DataMember]
        [JsonProperty(Order = 2)]
        public object Value
        {
            #region get
            get
            {
                switch (_controlType)
                {
                    case ControlTypes.CheckBoxGroup:
                        string strItems = string.Empty;
                        foreach (Item item in this.Items.Where(obj => obj.IsSelected))
                        {
                            strItems += item.Key + this.Separator;
                        }
                        if (!string.IsNullOrEmpty(strItems))
                            strItems = strItems.Remove(strItems.Length - this.Separator.Length, this.Separator.Length);

                        return strItems;
                    case ControlTypes.RadioButtonGroup:
                        string strItem = string.Empty;
                        foreach (Item item in this.Items.Where(obj => obj.IsSelected))
                        {
                            strItem = item.Key;
                        }
                        return strItem;
                    case ControlTypes.ListBox:
                        strItems = string.Empty;
                        foreach (Item item in this.Items.Where(obj => obj.IsSelected))
                        {
                            strItems += item.Key + this.Separator;
                        }
                        if (!string.IsNullOrEmpty(strItems))
                            strItems = strItems.Remove(strItems.Length - this.Separator.Length, this.Separator.Length);

                        return strItems;
                    case ControlTypes.Calendar:
                        if (string.IsNullOrEmpty(_text))
                        {
                            if (_value != null && !string.IsNullOrEmpty(_value.ToString()))
                            {
                                return String.Format("{0:MM-dd-yyyy}", _value);
                            }
                        }
                        if (_value == null)
                        {
                            return string.Empty;
                        }
                        DateFormatConverter dtConvert = new DateFormatConverter();
                        DateTime dt = DateTime.Now;
                        if (DateTime.TryParse(_value.ToString(), out dt))
                            return dtConvert.GetDateTimeFormat(_text, dt);
                        else
                            return _value;
                    case ControlTypes.AutoCompleteTextBox:
                        if (!string.IsNullOrEmpty(Convert.ToString(_value)))//if value was not set,means value is empty no need to return any value
                        {
                            if (this.Items.Where(o => o.Key == _value.ToString() && !string.IsNullOrEmpty(o.Key)).Count() == 0)
                            {
                                //if (!Convert.ToBoolean(this.EnableSearch))
                                {
                                    return _controlGroup;
                                }
                            }
                        }
                        else
                        {
                            if (!Convert.ToBoolean(this.EnableSearch))
                            {
                                return _controlGroup;
                            }
                        }
                        return _value;
                    case ControlTypes.MultiListBox:
                        StringBuilder sbValue = new StringBuilder();
                        if (this.TempItems != null)
                        {
                            foreach (Item mlItem in this.TempItems)
                            {
                                sbValue.Append(mlItem.Key);
                                sbValue.Append(this.Separator);
                            }
                            if (!string.IsNullOrEmpty(sbValue.ToString()))
                                sbValue = sbValue.Remove(sbValue.Length - this.Separator.Length, this.Separator.Length);
                        }
                        return sbValue.ToString();
                    default:
                        return _value;

                }

            }
            #endregion

            set
            {
                //if (value != null && value.GetType() == typeof(string))
                //{
                //    value = ManageScriptInput(Convert.ToString(value));
                //}
                object oldVal = _value;
                switch (_controlType)
                {
                    case ControlTypes.Label:
                        Label.Text = Convert.ToString(value);
                        break;
                    case ControlTypes.PeoplePicker:
                        if (value != null)
                        {
                            string strValue = Convert.ToString(value);
                            strValue = strValue.Replace("True]", string.Empty);
                            strValue = strValue.Replace("±", string.Empty);

                            if (strValue.Contains("²"))//&& strValue.Contains("]¶")) // // in execute cmd select rule, user value will get changed in "SetAttribute" fn and have to replace the ² to ±
                            {
                                value = strValue;
                            }
                            else
                            {
                                var temp = string.Empty;
                                List<string> arrUsers = strValue.Trim().Contains("¶") ? splitUser(strValue.Trim(), '¶') : splitUser(strValue.Trim(), ';');

                                foreach (var singleUser in arrUsers)
                                    temp += singleUser.Contains("↕") ? singleUser.Trim().Split('↕')[0] + "; " : singleUser.Trim() + "; "; // user contains user displayname and account name

                                value = temp;
                                this.Remarks = strValue.Replace("²", "±"); ; // keep the user with account name for DAL operations (ex: sivasankar↕CLAYSYS\\sivasankar;  eldho.poulose↕claysys\\eldhobasil"
                            }
                        }
                        break;
                    case ControlTypes.ListBox:
                        TextBoxMaxLength = -1;
                        PreValue = value;
                        string[] strArray = Convert.ToString(value).Split(new string[] { this.Separator }, StringSplitOptions.RemoveEmptyEntries);
                        if (!string.IsNullOrEmpty(Convert.ToString(PreValue)))
                        {
                            foreach (var item in this.Items)
                            {
                                item.IsSelected = false;
                            }
                        }
                        else
                        {
                            strArray = new string[] { string.Empty }; // While Unselecting a single value null is coming
                            foreach (var item in this.Items)
                            {
                                item.IsSelected = false;
                            }
                        }

                        foreach (string str in strArray)
                        {
                            var selItems = this.Items.Where(o => o.Key == HttpUtility.HtmlDecode(str));  // the values pair is encoded at execute select
                            if (selItems.Count() > 0)
                            {
                                selItems.ElementAt(0).IsSelected = true;
                            }
                        }
                        break;
                    case ControlTypes.CheckBoxGroup:
                        PreValue = value;
                        strArray = Convert.ToString(value).Split(new string[] { this.Separator }, StringSplitOptions.None);
                        foreach (string str in strArray)
                        {
                            var selItems = this.Items.Where(o => o.Key == str);
                            if (selItems.Count() > 0)
                            {
                                selItems.ElementAt(0).IsSelected = true;
                            }
                        }
                        break;
                    case ControlTypes.RadioButtonGroup:
                        PreValue = value;
                        if (this.ControlType == ControlTypes.CheckBoxGroup)
                        {
                            strArray = Convert.ToString(value).Split(new string[] { "#;" }, StringSplitOptions.None);
                        }
                        else
                        {
                            strArray = new string[] { Convert.ToString(value) };
                        }
                        if (this.ControlType == ControlTypes.RadioButtonGroup)
                        {
                            foreach (var item in this.Items)
                                item.IsSelected = false;
                        }
                        foreach (string str in strArray)
                        {
                            var selItems = this.Items.Where(o => o.Key == str);
                            if (selItems.Count() > 0)
                            {
                                selItems.ElementAt(0).IsSelected = true;
                            }
                        }
                        break;
                    case ControlTypes.ComboBox:
                        //After setting default value of combobox it is assigned to prevalue.
                        //if we assign prevalue to value the prevalue become null insted of default value so removed 
                        //removed by suneer
                        //PreValue = value;
                        if (this.Items != null)
                        {
                            foreach (var item in this.Items)
                            {
                                item.IsSelected = false;
                                if (item.Key == Convert.ToString(value))
                                {
                                    item.IsSelected = true;
                                }
                            }

                            int IValueCount = this.Items.Where(o => o.Value == Convert.ToString(value)).Count();
                            if ((this.Items.Where(o => o.Key == Convert.ToString(value)).Count()) + IValueCount <= 0 && (this.SearchAction != "Clear")/* && this.Text != "Static"*/)
                            {
                                value = string.Empty;
                                this._value = value;
                                return;
                            }
                            this.SearchAction = string.Empty;
                        }

                        break;
                    case ControlTypes.ExternalForm:
                        this._value = value;
                        break;
                    case ControlTypes.MultiListBox:
                        PreValue = value;
                        if (TempItems == null)
                        {
                            TempItems = new List<Item>();
                        }

                        List<Item> lItem = new List<Item>();
                        foreach (Item tmpItem in TempItems)
                        {
                            lItem.Add(tmpItem);
                        }

                        foreach (Item tmpItem in lItem)
                        {
                            TempItems.Remove(tmpItem);
                            Items.Add(tmpItem);
                        }

                        //List<Item> sortedList = Items.OrderBy(o => o.Value).ToList();
                        //Items = sortedList;

                        StringBuilder displayItem = new StringBuilder();
                        strArray = Convert.ToString(value).Split(new string[] { this.Separator }, StringSplitOptions.RemoveEmptyEntries);
                        foreach (string str in strArray)
                        {
                            List<Item> it = new List<Item>();
                            var tempItmsCollection = Items.Where(o => o.Key.Equals(HttpUtility.HtmlDecode(str))); // the values pair is encoded at execute select
                            if (tempItmsCollection.Count() > 0)
                            {
                                foreach (Item temp in tempItmsCollection)
                                {
                                    it.Add(temp);
                                }
                                foreach (Item temp in it)
                                {
                                    if (temp != null)
                                    {
                                        this.Items.Remove(temp);
                                        this.TempItems.Add(temp);
                                        displayItem.Append(temp.Value + this.Separator);              // Gets SelectedItem of MultiListBox By Hari Prakash
                                    }
                                }
                            }
                            //else
                            //    this.TempItems.Add(new Item(str, str, false));//value must be from collection of the control
                        }
                        this.SelectedItem = displayItem;
                        if (this.CheckDirty) //From clear Rule
                        {
                            if (!string.IsNullOrEmpty(TS)) //TS contains Serialized items of MultilistBox
                            {
                                List<Item> s = Serializer.JsonDeserialize<List<Item>>(TS);
                                this.Items = s;
                                // this.CheckDirty = false;
                            }
                        }
                        break;
                    case ControlTypes.AutoCompleteTextBox:
                        if (value != null)
                        {
                            var itms = this.Items.Where(o => o.Key == Convert.ToString(value));
                            if (itms.Count() > 0)
                            {
                                _selectedItem = itms.ElementAt(0);
                                ControlGroup = itms.ElementAt(0).Value;
                                value = itms.ElementAt(0).Key;
                            }
                            else
                            {
                                _controlGroup = Convert.ToString(value);
                                if (this.EnableSearch.ToLower() == "true") value = string.Empty;
                            }
                        }
                        break;
                    case ControlTypes.RichTextBox:
                        if (!SelectAll)
                        {
                            SelectedItem = value;
                        }
                        // Remove HTML Tags from the value if any and assign to Text property 
                        string styleTagRemoveValue = Regex.Replace(Convert.ToString(value), @"<(.|\n)*?>", string.Empty); // The Text property should have value without any html tags
                        styleTagRemoveValue = styleTagRemoveValue.Replace("&nbsp;", " ");
                        this.Text = styleTagRemoveValue;
                        break;
                    case ControlTypes.DateTimePicker:
                        if (SelectAll)
                        {
                            if ((_selectedItem == null || string.IsNullOrEmpty(_selectedItem.ToString())) && (value == null || value.ToString().Trim().Length == 0))
                            {
                                _selectedItem = string.Empty;
                            }
                            else
                            {
                                if (_selectedItem == null || string.IsNullOrEmpty(_selectedItem.ToString()))
                                {
                                    _selectedItem = DateTime.Now;
                                }
                                if (value == null || value.ToString().Trim().Length == 0)
                                {
                                    //value = DateTime.Now.ToString();
                                    value = string.Empty;
                                }
                                _value = value;
                            }
                        }
                        break;
                    case ControlTypes.PasswordBox:
                        if (!string.IsNullOrEmpty(Convert.ToString(value)))
                        {
                            try
                            {
                                var keybytes = Encoding.UTF8.GetBytes("8080808080808080");
                                var iv = Encoding.UTF8.GetBytes("8080808080808080");
                                var encrypted = Convert.FromBase64String(Convert.ToString(value));
                                var decriptedValue = Utility.DecryptStringFromBytes(encrypted, keybytes, iv);
                                value = decriptedValue;
                            }
                            catch (Exception ex)
                            {
                                _value = value;
                            }
                        }
                        _value = value;
                        break;
                    case ControlTypes.TextBox:
                        if (this.TextCase == TextCases.Password && !string.IsNullOrEmpty(Convert.ToString(value)))
                        {
                            try
                            {
                                var keybytes = Encoding.UTF8.GetBytes("8080808080808080");
                                var iv = Encoding.UTF8.GetBytes("8080808080808080");
                                var newValue = Uri.UnescapeDataString(HttpUtility.UrlEncode(Convert.ToString(value), Encoding.Default));
                                var encrypted = Convert.FromBase64String(Convert.ToString(newValue));
                                var decriptedValue = Utility.DecryptStringFromBytes(encrypted, keybytes, iv);
                                value = decriptedValue;
                            }
                            catch (Exception ex)
                            {
                                _value = value;
                            }
                        }
                        else if ((this.TextCase == TextCases.Currency || this.TextCase == TextCases.Accounting) && !string.IsNullOrEmpty(Convert.ToString(value)))
                        {
                            try
                            {
                                double tempval;
                                string setValue = Convert.ToString(value).Replace(@",", string.Empty);
                                if (double.TryParse(setValue, out tempval))
                                {

                                    if (setValue.Contains('.'))
                                    {
                                         if (this.CurrencyFractionalUnits == 0)
                                        {
                                            setValue = setValue.Substring(0, setValue.IndexOf("."));
                                        }
                                        else if (setValue.Length> setValue.IndexOf(".") + (this.CurrencyFractionalUnits + 1))
                                        {
                                             
                                            setValue = setValue.Substring(0, setValue.IndexOf(".") + Convert.ToInt32(this.CurrencyFractionalUnits + 1));
                                        }

                                    }
                                    if (!string.IsNullOrEmpty(setValue) && setValue.Length > this.TextBoxMaxLength)
                                    {
                                        setValue = setValue.Substring(0, this.TextBoxMaxLength);
                                    }
                                    
                                    value = setValue.TrimEnd('.');
                            }
                                else
                                {
                                    value = string.Empty;
                                }
                            }
                            catch (Exception ex)
                            {
                        _value = value;
                            }
                        }
                        _value = value;
                        break;
                    default:
                        break;
                }
                _value = value;
                if (!(oldVal == null && _value == null))
                {
                    if (oldVal == null)
                    {
                    }
                    else if (!oldVal.Equals(SetValue))
                    {
                        SetValue = SetValue;
                    }
                }
            }
        }
        public object SetValue { get; set; }

        bool _ValidateSave;
        /// <summary>
        /// if true and validation control have some errors then it will avoid saving data
        /// </summary>

        [DataMember]
        public bool ValidateSave
        {
            get
            {
                return _ValidateSave;
            }
            set
            {
                _ValidateSave = value;
            }
        }

        object _selectedItem;
        [DataMember]
        [JsonProperty(Order = 1)]
        public object SelectedItem
        {
            get
            {
                if (ControlType != ControlTypes.LookUp && ControlType != ControlTypes.PeoplePicker && ControlType != ControlTypes.RichTextBox)
                {
                    if (this.ControlType == ControlTypes.ListBox)
                    {
                        //string ret = "";
                        //if (_value.ToString() != "")
                        //    foreach (var cmbitem in (IList)this._value)
                        //    {
                        //        ret += cmbitem.GetProperty("Value").ToString() + "#;";
                        //    }
                        //return ret;
                        return _selectedItem;
                    }
                    else if (this.ControlType == ControlTypes.TreeView)
                    {
                        return _selectedItem;
                    }
                    else if (this.ControlType == ControlTypes.AutoCompleteTextBox)
                    {
                        if (this.EnableSearch.ToLower() == "false" || !string.IsNullOrEmpty(Convert.ToString(Value)))
                            return _controlGroup;
                        else
                            return string.Empty;

                    }
                    else if (this.Items.Where(o => o.Key == Convert.ToString(Value)).Count() > 0)
                    {
                        return this.Items.Where(o => o.Key == Convert.ToString(Value)).ElementAt(0).Value;
                    }
                    else if (this.ControlType == ControlTypes.ExternalForm)
                    {
                        return _selectedItem;
                    }
                    else if (this.ControlType == ControlTypes.CheckBoxGroup)
                    {
                        string strItems = string.Empty;
                        foreach (Item item in this.Items.Where(obj => obj.IsSelected))
                        {
                            strItems += item.Value + "#;";
                        }
                        return _selectedItem = strItems;
                    }
                    else if (this.ControlType == ControlTypes.DateTimePicker && this.SelectAll)// For DatetimePicker when time picker is enabled.
                    {
                        if ((_selectedItem == null || string.IsNullOrEmpty(_selectedItem.ToString())) && (_value == null || _value.ToString().Trim().Length == 0))
                        {
                            return string.Empty;
                        }
                        else
                        {
                            if (_selectedItem == null || string.IsNullOrEmpty(_selectedItem.ToString()))
                            {
                                _selectedItem = DateTime.Now;
                            }
                            if (_value == null || _value.ToString().Trim().Length == 0)
                            {
                                //_value = DateTime.Now.ToString();
                                _value = string.Empty;
                            }
                        }
                        //  DateTime selectedTime = Convert.ToDateTime(_selectedItem);
                        //  DateTime selectedDate = Convert.ToDateTime(_value);
                        //  _selectedItem = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, selectedTime.Hour, selectedTime.Minute, selectedTime.Second);

                        //return Text + " " + selectedTime.ToShortTimeString();
                        return _selectedItem;
                    }
                    else if (this.ControlType == ControlTypes.DynamicGrid || this.ControlType == ControlTypes.MetaDataControl ||
                             this.ControlType == ControlTypes.Menu || this.ControlType == ControlTypes.MultiListBox)
                    {
                        return _selectedItem;
                    }
                    return null;
                }
                //else
                //{
                return _selectedItem;

                //}
            }
            set
            {
                switch (_controlType)
                {
                    case ControlTypes.AutoCompleteTextBox:
                        var selItms = this.Items.Where(o => o.Value == Convert.ToString(value));
                        if (selItms.Count() > 0)
                        {
                            Value = selItms.ElementAt(0).Key;
                            _controlGroup = selItms.ElementAt(0).Value;
                        }
                        break;
                    case ControlTypes.DateTimePicker:
                        if (SelectAll)
                        {
                            _selectedItem = value;

                            if ((_selectedItem != null || string.IsNullOrEmpty(_selectedItem.ToString())) && (_value == null || _value.ToString().Trim().Length == 0))
                            {
                                _selectedItem = string.Empty;
                            }
                            else
                            {
                                if (_selectedItem == null || string.IsNullOrEmpty(_selectedItem.ToString()))
                                {
                                    _selectedItem = DateTime.Now;
                                }
                                if (_value == null || _value.ToString().Trim().Length == 0)
                                {
                                    _value = DateTime.Now.ToString();
                                }
                                DateTime selectedTime = Convert.ToDateTime(Utility.ConvertToValidDateTime(Convert.ToString(_selectedItem)));
                                DateTime selectedDate = Convert.ToDateTime(Utility.ConvertToValidDateTime(Convert.ToString(_value)));
                                _selectedItem = new DateTime(selectedDate.Year, selectedDate.Month, selectedDate.Day, selectedTime.Hour, selectedTime.Minute, selectedTime.Second);
                            }
                        }
                        break;
                    default:
                        if (value != null && value.GetType() == typeof(Newtonsoft.Json.Linq.JArray))
                        {
                            if (this.ControlType == ControlTypes.DynamicGrid)
                            {
                                List<ControlClass> cClass = new List<ControlClass>();
                                foreach (var item in value as Newtonsoft.Json.Linq.JArray)
                                {
                                    cClass.Add(item.ToObject<ControlClass>());
                                }
                                _selectedItem = cClass;
                            }
                            else if (this.ControlType == ControlTypes.LookUp)
                            {
                                List<List<Item>> rows = new List<List<Item>>();
                                foreach (var item in value as Newtonsoft.Json.Linq.JArray)
                                {
                                    rows.Add(item.ToObject<List<Item>>());
                                }
                                _selectedItem = rows;
                            }
                        }
                        else
                        {
                            _selectedItem = value;
                        }
                        break;
                }
            }
        }




        private TextCases _textCase;
        [DataMember]
        public TextCases TextCase
        {
            get
            {

                return _textCase;
            }
            set
            {
                _textCase = value;
            }
        }

        private bool _isFormControl;
        [DataMember]
        public bool IsFormControl
        {
            get
            {
                return _isFormControl;
            }
            set
            {
                _isFormControl = value;
            }
        }

        int _id;
        [DataMember]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }

        int _row;
        [DataMember]
        public int Row
        {
            get { return _row; }
            set { _row = value; }
        }

        int _column;
        [DataMember]
        public int Column
        {
            get { return _column; }
            set { _column = value; }
        }

        private string _listDetails;
        [DataMember]
        public string ListDetails
        {
            get { return _listDetails; }
            set { _listDetails = value; }
        }

        ControlTypes _controlType;
        [DataMember]
        [JsonProperty(Order = 0)]
        public ControlTypes ControlType
        {
            get
            {
                return _controlType;
            }
            set
            {
                _controlType = value;

            }
        }


        private double _RowWidth;
        /// <summary>
        /// User for row width.
        /// Also used to store ComboHeight for compositecontrols(Disposition).
        /// </summary>
        [DataMember]
        public double RowWidth
        {
            get
            {
                if (this.ControlType == ControlTypes.ListBox)
                {
                    return Convert.ToInt32(10);//this.Style.Width - 27);
                }
                return _RowWidth;
            }
            set
            {
                _RowWidth = value;
            }
        }

        private string _toolTip = string.Empty;
        [DataMember]
        public string ToolTip
        {
            get
            {
                return _toolTip.Trim().Replace("\\r\\n", Environment.NewLine);
            }
            set
            {
                _toolTip = value;
            }
        }

        private string _remarks = string.Empty;
        [DataMember]
        public string Remarks
        {
            get
            {
                if (_remarks != null)
                    return _remarks.Trim();
                return _remarks;
            }
            set
            {
                _remarks = value;
            }
        }

        private double _rowHeight;
        /// <summary>
        /// User for row height.
        /// Also used to store LabelHeight for compositecontrols(Disposition).
        /// </summary>
        [DataMember]
        public double RowHeight
        {
            get
            {
                return _rowHeight;
            }
            set
            {
                _rowHeight = value;
            }
        }


        /// <summary>
        /// Also used for  Listbox SelectedIndex and Search result count
        /// </summary>
        private int _textBoxMaxLength;
        [DataMember]
        public int TextBoxMaxLength
        {
            get
            {
                return _textBoxMaxLength;
            }
            set
            {
                if (this.ControlType == ControlTypes.DynamicGrid &&
                    SpellCheckRequired)
                {
                    _textBoxMaxLength = value;
                }
                else if (this.ControlType == ControlTypes.DynamicGrid &&
                    !SpellCheckRequired)
                {
                    _textBoxMaxLength = 100;
                }
                else
                {
                    _textBoxMaxLength = value;
                }
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

        private bool _checkDirty;

        [DataMember]
        public bool CheckDirty
        {
            get
            {
                return _checkDirty;
            }
            set
            {
                _checkDirty = value;
            }
        }

        [DataMember]
        public bool IsGridItem;

        //DataMember was removed for caching.Bcoz controlclass serialzation causes error.
        private object _selectedGridRow;
        [DataMember]
        [JsonProperty(Order = 3)]
        public object SelectedGridRow
        {
            get
            {
                return _selectedGridRow;
            }
            set
            {
                if (this.ControlType == ControlTypes.DynamicGrid && value != null && value.GetType() == typeof(Newtonsoft.Json.Linq.JObject))
                {
                    DGViewModel dgVM = new DGViewModel();
                    dgVM = Newtonsoft.Json.Linq.JObject.Parse(value.ToString()).ToObject<DGViewModel>();
                    _selectedGridRow = dgVM;
                }
                else
                {
                    _selectedGridRow = value;
                }
            }
        }

        private bool _selectAll;
        [DataMember]
        public bool SelectAll
        {
            get
            {
                return _selectAll;
            }
            set
            {
                _selectAll = value;
                if (SelectAll && this.ControlType == ControlTypes.ListBox)
                {
                    this.SpellCheckRequired = true;
                    this.SelectedItem = this.Items;
                    foreach (Item item in this.Items)
                    {
                        item.IsSelected = true;
                    }
                }
                else if (!SelectAll && this.ControlType == ControlTypes.ListBox)
                {
                    if (SelectedItem != null)
                    {
                        SelectedItem = null;
                    }
                    foreach (Item item in this.Items)
                    {
                        item.IsSelected = false;
                    }
                }

            }
        }


        private object _compositeControl;

        [DataMember]
        [JsonProperty(Order = 4)]
        public object CompositeControl
        {
            get { return _compositeControl; }
            set
            {
                if (value != null && value.GetType() == typeof(Newtonsoft.Json.Linq.JObject))
                {
                    if (this.ControlType == ControlTypes.DynamicGrid)
                    {
                        Row cClass = new AppForms.Model.Models.DG.Row();
                        cClass = Newtonsoft.Json.Linq.JObject.Parse(value.ToString()).ToObject<Row>();
                        _compositeControl = cClass;
                    }
                }
                else
                {
                    _compositeControl = value;
                }
            }
        }
        private int _CurrencyFractionalUnits;
        [DataMember]
        public int CurrencyFractionalUnits {
            get
            {
                if (_CurrencyFractionalUnits == null )
                    _CurrencyFractionalUnits = 2;
                return _CurrencyFractionalUnits;
            }
            set {
                _CurrencyFractionalUnits = value;
            }
            
        }
        #endregion

        #region internal Method


        #endregion


        #region Constructor

        public ControlClass()
        {

            //MemoryProfiler.AddReference(this);
            this._items = new List<Item>();
            this.Validation = new ValidationObj();
            this.DataSource = new DataSourceObj();
            this.MappedColumn = new MappedColumnObj();
            this.DataType = new DataTypeObj();
            this.Style = new StyleObj();
            //Style.ParentCtrlClass = this;
            this.IsRootControl = true;
            this.ControlGroup = string.Empty;
            this.ParentID = string.Empty;
            this.TabName = string.Empty;
            this.RowWidth = 0;
            this.IsPopupOpen = false;
            //            this.Label = new Model.Label();
            this.Remarks = string.Empty;
            this.ToolTip = string.Empty;
            this.IsFormControl = false;
            this.TextCase = TextCases.None;
            this.ControlConfig = new CustomControlConfig();
            this.Errors = new ObservableCollection<ValidationControlsError>();
            this.EnableSearch = "true";
            this.AllowClear = "true";
            this.Security = new SecurityManager();
            NoOfTabs = 2;
            RowHeight = 0;

            //Comented after deleting grid implementation
            //OnMouseClick = new DelegateCommand<string>(MouseClick);
            //OnGridEditClick = new DelegateCommand<object>(GridEditClick);
            //OnGridDeleteClick = new DelegateCommand<object>(GridDeleteClick);
            //

            this.TextBoxMaxLength = 255;
            this.ClickAction = ClickActions.None;
            this.DateFormat = new List<string>();
            this.SearchRows = new List<List<SearchCustomView>>();
            this.Style.ColumnWidth = "Auto";
            this.GridWhereCondition = new List<DBCommand>();
            this.EncodeValue = "false";
            //FillDateType();


            //this.MappedColumn = new MappedColumnObj();

            ////this.Style = new StyleObj();
            ////Style.ParentCtrlClass = this;
            //this.IsRootControl = true;
            //this.ControlGroup = "";
            //this.ParentID = "";
            //this.TabName = "";
            //this.RowWidth = 0;
            //this.IsPopupOpen = false;

            //this.Remarks = "";
            //this.ToolTip = "";
            //this.IsFormControl = false;
            //this.TextCase = TextCases.None;


            //this.EnableSearch = "true";
            //this.AllowClear = "true";
            //NoOfTabs = 2;

            //RowHeight = 0;


            //this.TextBoxMaxLength = 255;

            //this.DateFormat = new List<string>();

            //FillDateType();

        }


        private List<string> FillDateType()
        {
            this._dateFormat.Clear();
            this._dateFormat.Add("dd-mm-yyyy");
            this._dateFormat.Add("dd-MMM-yyyy");
            this._dateFormat.Add("dd-MMM-yy");
            this._dateFormat.Add("dd-mm-yy");
            this._dateFormat.Add("mm-dd-yyyy");
            this._dateFormat.Add("MMM-dd-yyyy");
            this._dateFormat.Add("dd/mm/yyyy");
            this._dateFormat.Add("dd/MMM/yyyy");
            this._dateFormat.Add("dd/MMM/yy");
            this._dateFormat.Add("dd/mm/yy");
            this._dateFormat.Add("mm/dd/yyyy");
            this._dateFormat.Add("MMM/dd/yyyy");
            this._dateFormat.Add("yyyy-mm-dd");
            this._dateFormat.Add("yyyy-dd-mm");
            this._dateFormat.Add("yyyy-mmm-dd");
            this._dateFormat.Add("yyyy/mm/dd");
            this._dateFormat.Add("yyyy/dd/mm");
            //this._dateFormat.Add("MMddyyyy");
            this._dateFormat.Add("M/d/yyyy");

            return _dateFormat;

        }

        #endregion
        private bool _isFocus;
        [DataMember]
        public bool IsFocus
        {
            get
            {
                return _isFocus;
            }
            set
            {
                _isFocus = value;
                //NotifyPropertyChange("IsFocus");
            }
        }

        private string _misc;
        [DataMember]
        public string Misc
        {
            get { return _misc; }
            set { _misc = value; }
        }

        private bool _isDirty;
        //private bool _checkDirty;
        [DataMember]
        public object PreValue { get; set; } //This is used for Dynamic Grid also for keeping the control collection 

        [DataMember]
        private SecurityManager _Security;
        public SecurityManager Security
        {
            get
            {
                return _Security;
            }
            set
            {
                _Security = value;
            }
        }
        private bool _isLw;
        [DataMember]
        public bool IsLW
        {
            get { return _isLw; }
            set { _isLw = value; }
        }

        [DataMember]
        public bool IsDirty
        {
            get
            {
                return _isDirty;
            }
            set
            {
                _isDirty = value;
                //    NotifyPropertyChange("IsDirty");
            }
        }
        [DataMember]
        public bool ShowDirty;
        
        [DataMember]
        public bool stopRule { get; set; }

        public void ClearItem()
        {
            stopRule = true;
            this.Value = string.Empty;
            // RemoveErrors("Value");
            // NotifyPropertyChange("Value");
            stopRule = false;
        }

        [DataMember]
        public string CSSName { get; set; }

        public FormRowViewer ControlParentRow { get; set; }

        [DataMember]
        public int ControlIndex { get; set; }

        [DataMember]
        public List<ValidationControlsError> ErrorsList { get; set; }
        public void RemoveCtrlError(string prop)
        {
            RemoveErrors(prop);
        }
        public void RemoveErrors(string prop)
        {
            if (_errors != null)
            {
                if (_errors.ContainsKey(prop))
                {
                    _errors.Remove(prop);
                }
            }

        }
        public void AddCtrlError(string prop, string error)
        {
            AddError(prop, error);
        }
        public void AddError(string prop, string error)
        {
            if (_errors != null)
            {
                //   error = SetTenantALert(error);
                if (_errors.ContainsKey(prop))
                {
                    _errors[prop].Add(error);
                }
                else
                {
                    _errors.Add(prop, new List<string> { error });
                }
            }
        }
        //public override string ToString()
        //{
        //    string strRetVal = "";
        //    strRetVal = Serializer.JsonSerialize<ControlClass>(this);
        //    this.TS = strRetVal;
        //    return strRetVal;
        //}

        [DataMember]
        public string TS { get; set; }

        private List<Item> _dynamicGridRowTemplate;
        [DataMember]
        public List<Item> DynamicGridRowTemplate
        {
            get
            {
                return _dynamicGridRowTemplate;
            }
            set
            {
                _dynamicGridRowTemplate = value;
            }
        }

        [DataMember]
        public bool? IsNewRow { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        // For Timer Control

        [DataMember]
        public bool IsActive { get; set; }

        [DataMember]
        public int Interval { get; set; }

        private string _displayText;
        /// <summary>
        /// Display Text Propert is alse used for Button - on Load Form - Execute form load.
        /// </summary>
        [DataMember]
        public string DisplayText
        {
            get
            {
                if (this.ControlType == ControlTypes.ListBox)
                {
                    _displayText = string.Empty;
                    if (!string.IsNullOrEmpty(Convert.ToString(Value)))
                    {
                        var its = Value.ToString().Split(new string[] { this.Separator }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var it in its)
                        {
                            if (_displayText != string.Empty)
                            {
                                _displayText += this.Separator;
                            }
                            var cllValues = this.Items.Where(o => o.Key == it);
                            if (cllValues.Any())
                            {
                                _displayText += cllValues.ElementAt(0).Value;
                            }

                        }

                    }

                }
                else if (this.ControlType == ControlTypes.ComboBox)
                {
                    _displayText = string.Empty;
                    string tempval = Convert.ToString(Value);
                    if (this.Items.Where(o => o.Key == tempval).Count() > 0)
                    {
                        _displayText = this.Items.Where(o => o.Key == tempval).ElementAt(0).Value;
                    }

                }
                return _displayText;
            }
            set
            {

                _displayText = value;
            }
        }
        [DataMember]
        public string PropertyValue { get; set; }
        //// Search - Keeping rows
        public List<List<SearchCustomView>> SearchRows
        {
            get;
            set;
        }
        /// <summary>
        /// To contain first row of search data when "First row as header" is enabled
        /// </summary>
        public List<SearchCustomView> FirstSearchRowData { get; set; }

        /// <summary>
        /// ADB encrypt data
        /// </summary>
        [DataMember]
        public string EncryptData { get; set; }

        /// <summary>
        /// ADB Prevent duplicate values.
        /// </summary>
        [DataMember]
        public string Unique { get; set; }
        /// <summary>
        /// PlaceHolder
        /// </summary>
        [DataMember]
        public string PlaceHolder { get; set; }

        /// <summary>
        /// Check control is mapped with ADB 
        /// </summary>
        [DataMember]
        public bool IsADB { get; set; }

        /// <summary>
        /// ADB Accept large data for RTB.
        /// </summary>
        [DataMember]
        public string AcceptLarge { get; set; }

        /// <summary>
        /// For controls that require auto height feature
        /// </summary>
        [DataMember]
        public bool AutoHeight { get; set; }

        #region "fileUpload control Property"

        private string _filePath;

        public string FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        private string _fileSize;

        public string FileSize
        {
            get { return _fileSize; }
            set { _fileSize = value; }
        }
        /// <summary>
        /// This property is only used for DynamicGrid Delete. 
        /// </summary>
        private List<DBCommand> _gridWhereCondition;
        [DataMember]
        public List<DBCommand> GridWhereCondition
        {
            get { return _gridWhereCondition; }
            set { _gridWhereCondition = value; }
        }

        private List<ADBDataMaster> _ADBCriteria;

        public List<ADBDataMaster> ADBCriteria
        {
            get { return _ADBCriteria; }
            set { _ADBCriteria = value; }
        }

        private double _ADBDataOrder;

        public double ADBDataOrder
        {
            get { return _ADBDataOrder; }
            set { _ADBDataOrder = value; }
        }

        private CaptchaTextType _captchaTextType;
        public CaptchaTextType CaptchaTextType
        {
            get
            {
                return _captchaTextType;
            }
            set
            {
                _captchaTextType = value;
            }
        }

        /// <summary>
        /// Used for handling the Attachedlabel vertical alignment
        /// </summary>
        [DataMember]
        public string HdnBackward1 { get; set; }

        /// <summary>
        /// Used for handling the FileUpload,multilistbox spacing
        /// Used for handling padding in textbox,Maskeditor,autocomplete,datetimepicker,passwordbox,lookup,people picker,combobox
        /// Used for handling width in Subform when ShowBorder is true
        /// </summary>
        [DataMember]
        public string HdnBackward2 { get; set; }
        // <summary>
        /// Used for encoding values in textbox.
        /// </summary>
        private string _encodeValue;
        [DataMember]
        public string EncodeValue
        {
            get { return _encodeValue; }
            set { _encodeValue = value; }

        }

        /// <summary>
        /// used for handling the separator for CHeckboxgroup,listboxgroup and multilistbox.
        /// </summary>
        private string _separator;
        [DataMember]
        public string Separator
        {
            get
            {
                if (string.IsNullOrEmpty(_separator))
                {
                    if (ControlType == ControlTypes.ListBox)
                    {
                        if (!string.IsNullOrEmpty(Misc))
                        {
                            _separator = Misc;
                            Misc = "";
                        }
                        else
                        {
                            _separator = ",";
                        }
                    }
                    else if (ControlType == ControlTypes.CheckBoxGroup || ControlType == ControlTypes.MultiListBox)
                    {
                        _separator = "#;";
                    }
                }
                return _separator;
            }
            set { _separator = value; }

        }
        #endregion


        //~ControlClass()
        //{
        //    Dispose();
        //}

        //public void Dispose()
        //{
        //    Style = null;
        //    DataSource = null;
        //}
        private string _maxHeight;
        [DataMember]
        public string MaxHeight
        {
            get { return _maxHeight; }
            set { _maxHeight = value; }
        }

        [DataMember]
        public string StaticData;

        public GenericDataTable Data;
        public string ConnectedDataTable { get; set; }
        private AccountingFormat _accFormat;
        [DataMember]
        public AccountingFormat AccountingFormat
        {
            get { return _accFormat; }
            set { _accFormat = value; }
        }


        private bool _textWrap;
        [DataMember]
        public bool TextWrap
        {
            get { return _textWrap; }
            set { _textWrap = value; }
        }

        public string DownloadMode { get; set; }

        [DataMember]
        public string BorderType { get; set; }

        [DataMember]
        public string TabControlTemplate { get; set; }

        [DataMember]
        public bool JsonDate { get; set; }
        [DataMember]
        public string ExcludeExtension { get; set; }
    }
}
