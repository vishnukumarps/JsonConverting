using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClaySys.AppBuilder.Models;
using System.Xml.Linq;
using System.Reflection;
using System.Collections.ObjectModel;
using ClaySys.AppForms.Model;

namespace ClaySys.AppBuilder
{
    public class ConvertClass : IDisposable
    {
        public ControlClass CurrentControl;

        public List<LWControl> ToLWControl(IEnumerable<ControlClass> controls)
        {
            return controls.Select<ControlClass, LWControl>(Convert).ToList(); ;
        }

        public List<ControlClass> ToControlClass(IEnumerable<LWControl> controls)
        {
            return controls.Select<LWControl, ControlClass>(CopyToParent).ToList(); ;
        }

        internal LWControl Convert(ControlClass control)
        {
            try
            {
                if (control.ControlType == ControlTypes.BlankControl)
                {
                    LWControl objBlnk = new LWControl()
                    {
                        C = control.Column,
                        CT = (int)control.ControlType,
                        I = control.ID,
                        IR = control.IsRootControl,
                        FC = control.IsFormControl,
                        P = control.ParentID,
                        R = control.Row,
                        S = control.Style.ToString(),
                    };
                    return objBlnk;
                }
                else
                {
                    LWControl obj = new LWControl()
                    {
                        C = control.Column,
                        CT = (int)control.ControlType,
                        D = control.DataSource.ToString(),
                        DT = control.DataType.ToString(),
                        G = control.ControlGroup,
                        I = control.ID,
                        IR = control.IsRootControl,
                        FC = control.IsFormControl,
                        IT = control.ItemCollectionString, /* control.Items TO DO....*/
                        M = control.MappedColumn.ToString(),
                        // N = control.ControlName,
                        P = control.ParentID,
                        R = control.Row,
                        TC = (int)control.TextCase,
                        T = control.TabName,
                        TX = control.Text,
                        V = control.ControlType == ControlTypes.Grid ? string.Empty : control.Value,
                        VD = control.Validation.ToString(),
                        S = control.Style.ToString(),
                        TT = control.ToolTip.ToString(),
                        RM = control.Remarks.ToString(),
                        L = control.Label.ToString(),
                        TL = control.TextBoxMaxLength,
                        XC = control.ControlConfig == null ? string.Empty : control.ControlConfig.ToString(),
                        CA = ((int)control.ClickAction).ToString(),
                        VS = control.ValidateSave,
                        RFS = control.Validation.ValidateOnSave,
                        XV = control.XMLValue,
                        AC = control.AllowClear,
                        ES = control.EnableSearch,
                        SR = control.SpellCheckRequired,
                        TI = control.TabIndex,
                        CD = control.CheckDirty,
                        SA = control.SelectAll,
                        RH = control.RowHeight,
                        RW = control.RowWidth,
                        SK = control.ShortcutKey == null ? string.Empty : control.ShortcutKey,
                        GN = control.Group == null ? string.Empty : control.Group,
                        PV = control.PreValue == null ? string.Empty : control.PreValue,
                        IK = control.InvokeKeyChange == null ? false : control.InvokeKeyChange,
                        MI = control.Misc == null ? string.Empty : control.Misc,
                        DX = control.DisplayText,
                        IPO = control.IsPopupOpen,
                        LD = control.ListDetails,
                        TP = control.TriggerOnPaging == null ? false : control.TriggerOnPaging,
                        HB1 = control.HdnBackward1,
                        HB2 = control.HdnBackward2,
                        PrV = control.PropertyValue,
                        IL = control.Interval,
                        EV = control.EncodeValue,
                        MH = control.MaxHeight,
                        SPR = control.Separator,
                        CFU = control.CurrencyFractionalUnits,
                        AF = (int)control.AccountingFormat,
                        STD = control.StaticData,
                        BT = control.BorderType,
                        TTC = control.TabControlTemplate,
                        JD = control.JsonDate,
                        EE = control.ExcludeExtension == null ? string.Empty : control.ExcludeExtension,
                        PH = control.PlaceHolder
                    };
                    //Case of form
                    if (obj.CT == (int)ControlTypes.Form || obj.CT == (int)ControlTypes.ImageButton || obj.CT == (int)ControlTypes.Image)
                        obj.V = null;
                    else if (obj.CT == (int)ControlTypes.CompositeControl)
                        obj.V = GetXapValue(control, "Value");

                    if ((obj.CT == (int)ControlTypes.Menu || obj.CT == (int)ControlTypes.DynamicGrid || obj.CT == (int)ControlTypes.TabControl || obj.CT == (int)ControlTypes.Grid || obj.CT == (int)ControlTypes.GridView || obj.CT == (int)ControlTypes.CompositeControl || obj.CT == (int)ControlTypes.CompositeColumn) && control.Items != null)
                    {
                        obj.IT = Serializer.JsonSerialize<List<Item>>(control.Items); ;
                    }
                    if (obj.CT == (int)ControlTypes.Search && obj.V.GetType().ToString() != "System.String")
                    {
                        obj.V = Serializer.JsonSerialize(control.Value);
                    }
                    if (obj.CT == (int)ControlTypes.DataTable && obj.V.GetType().ToString() != "System.String")
                    {
                        obj.V = Serializer.JsonSerialize(control.Value);
                    }
                    if (obj.CT == (int)ControlTypes.Spreadsheet)
                    {
                        obj.SD = control.SpreadsheetData == null ? null : Serializer.JsonSerialize<List<SpreadsheetData>>(control.SpreadsheetData);
                    }
                    return obj;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //throw new UnyFormsException(ex);
            }
        }

        /// <RecentChanges>
        /// <ChangedBy>Irfan.K.A</ChangedBy>
        /// <Date>26/11/2020</Date>
        /// <ReasonForChange>Deserializing Border Styles</ReasonForChange>
        /// <BugID>3656</BugID>
        /// </RecentChanges>
        public ControlClass CopyToParent(LWControl control)
        {
            if ((ControlTypes)control.CT == ControlTypes.BlankControl)
            {
                ControlClass blnkCtrl = new ControlClass()
                {
                    Column = control.C,
                    ControlType = (ControlTypes)control.CT,
                    ID = control.I,
                    IsRootControl = control.IR,
                    IsFormControl = control.FC,
                    ParentID = control.P,
                    Row = control.R,
                    Style = StyleObj.ToStyle(control.S),
                };
                return blnkCtrl;
            }
            else
            {
                ControlClass ctrl = new ControlClass()
                {
                    Column = control.C,

                    DataSource = DataSourceObj.ToDataSource(control.D),
                    DataType = DataTypeObj.ToDataType(control.DT),
                    ControlGroup = control.G,
                    ID = control.I,
                    IsRootControl = control.IR,
                    Items = new List<Item>(),
                    ItemCollectionString = control.IT,//TO DO.....
                    MappedColumn = MappedColumnObj.ToMappedColumn(control.M),
                    // ControlName = control.N,
                    ParentID = control.P,
                    IsFormControl = control.FC,
                    Row = control.R,
                    TabName = control.T,
                    SpellCheckRequired = control.SR,
                    Text = control.TX,
                    Value = control.V,
                    Validation = ValidationObj.ToValidation(control.VD),
                    Style = StyleObj.ToStyle(control.S),
                    BorderStyle = string.IsNullOrEmpty(control.BS) ? null : Serializer.JsonDeserialize<BorderStyleObj>(control.BS),
                    AttachedLabelBorder = string.IsNullOrEmpty(control.ALBS) ? null : Serializer.JsonDeserialize<AttachedLabelBorderStyleObj>(control.ALBS),
                    ToolTip = control.TT == null ? string.Empty : control.TT,
                    Remarks = control.RM == null ? string.Empty : control.RM,
                    Label = Label.ToLabel(control.L),
                    TextBoxMaxLength = control.TL,
                    ControlConfig = string.IsNullOrEmpty(control.XC) ? null : Serializer.JsonDeserialize<CustomControlConfig>(control.XC),
                    ClickAction = (ClickActions)(System.Convert.ToInt32(control.CA)),
                    ValidateSave = control.VS,
                    ControlType = (ControlTypes)control.CT,
                    AllowClear = control.AC == null ? "true" : control.AC,
                    EnableSearch = control.ES == null ? "true" : control.ES,
                    // TabIndex = control.TI == null ? 0 : control.TI,
                    TabIndex = control.TI,
                    CheckDirty = control.CD == null ? false : control.CD,
                    ShowDirty = control.SDC == null ? false : control.SDC,
                    SelectAll = control.SA,
                    RowHeight = control.RH,
                    RowWidth = control.RW,
                    ShortcutKey = control.SK == null ? string.Empty : control.SK,
                    Group = control.GN == null ? string.Empty : control.GN,
                    PreValue = control.PV == null ? string.Empty : control.PV,
                    InvokeKeyChange = control.IK == null ? false : control.IK,
                    DisplayText = control.DX == null ? string.Empty : control.DX,
                    Misc = control.MI == null ? string.Empty : control.MI,
                    IsPopupOpen = control.IPO,
                    ListDetails = control.LD == null ? string.Empty : control.LD,
                    TriggerOnPaging = control.TP == null ? false : control.TP,
                    IsADB = control.ADB,
                    EncryptData = control.ED,
                    Unique = control.UN,
                    AcceptLarge = control.AL,
                    AutoHeight = control.AH,
                    HdnBackward1 = control.HB1,
                    HdnBackward2 = control.HB2,
                    PropertyValue = control.PrV,
                    Interval = control.IL,
                    EncodeValue = control.EV == null ? "false" : control.EV,
                    MaxHeight = control.MH,
                    Separator = control.SPR,
                    IsLW = control.ILW,
                    CurrencyFractionalUnits = control.CFU,
                    StaticData = control.STD,
                    BorderType = control.BT,
                    TabControlTemplate = control.TTC,
                    JsonDate=control.JD,
                    ExcludeExtension = control.EE,
                    PlaceHolder = control.PH,
                    CSSName=control.CSN

                    //SelectedItem=control.SI
                };
                ctrl.TextCase = (TextCases)control.TC;
                ctrl.AccountingFormat = (AccountingFormat)control.AF;
                ctrl.TextWrap = control.TW;
                if (ctrl.ControlType == ControlTypes.Search)
                {
                    if (ctrl.Style.Padding == "0,0,0,0" && !control.S.Split(new char[] { '*', '#' })[(int)StyleObj.StyleArrayIndex.Padding].Contains(','))
                        ctrl.Style.Padding = "1,0,0,0";
                }
                if ((ctrl.ControlType == ControlTypes.Menu || ctrl.ControlType == ControlTypes.DynamicGrid || ctrl.ControlType == ControlTypes.TabControl || ctrl.ControlType == ControlTypes.Grid || ctrl.ControlType == ControlTypes.GridView || ctrl.ControlType == ControlTypes.CompositeControl || ctrl.ControlType == ControlTypes.CompositeColumn) && control.IT != string.Empty)
                {
                    ctrl.Items = Serializer.JsonDeserialize<List<Item>>(control.IT);

                    if (ctrl.ControlType == ControlTypes.DynamicGrid && !string.IsNullOrEmpty(control.V.ToString()))
                    {
                        ctrl.SelectedGridRow = Serializer.JsonDeserialize<DGViewModel>(control.V.ToString());
                    }
                }
                if (ctrl.ControlType == ControlTypes.Spreadsheet)
                {
                    ctrl.SpreadsheetData = control.SD == null ? null : Serializer.JsonDeserialize<List<SpreadsheetData>>(control.SD);
                }
                ctrl.XMLValue = control.XV;
                //if (ctrl.ControlType == ControlTypes.CompositeControl)
                //    SetXapValue(ctrl);
                if (string.IsNullOrEmpty(ctrl.Style.Padding))
                {

                    switch (ctrl.ControlType)
                    {
                        case ControlTypes.ComboBox:
                        case ControlTypes.MaskEditor:
                        case ControlTypes.AutoCompleteTextBox:
                        case ControlTypes.PasswordBox:
                        case ControlTypes.LookUp:
                        case ControlTypes.DateTimePicker:
                            ctrl.Style.Padding = "3";
                            break;
                        default:
                            ctrl.Style.Padding = "0";
                            break;
                    }
                }
                return ctrl;
            }
        }

        //public delegate void CompositeControlCreated();
        //public event CompositeControlCreated CompositeControlCreatedMethod;

        //public void CreateCompositeControl(string viewMode, ControlClass control)
        //{
        //    CurrentControl = control;
        //    CurrentControl.asm = null;
        //    CurrentControl.CompositeControl = null;

        //    CurrentControl.ControlConfig.ViewMode = viewMode;
        //    WebClient c = new WebClient();
        //    c.OpenReadCompleted += c_OpenReadCompleted;
        //    c.OpenReadAsync(new Uri(CurrentControl.ControlConfig.XapName + ".xap", UriKind.Relative));
        //}

        //void c_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
        //{
        //    string appManifest = new StreamReader(Application.GetResourceStream(new StreamResourceInfo(e.Result, null), new Uri("AppManifest.xaml", UriKind.Relative)).Stream).ReadToEnd();

        //    XElement deploy = XDocument.Parse(appManifest).Root;
        //    List<XElement> parts = (from assemblyParts in deploy.Elements().Elements()
        //                            select assemblyParts).ToList();

        //    foreach (XElement xe in parts.Where(o => o.Name.LocalName != "ExtensionPart"))
        //    {
        //        string source = xe.Attribute("Source").Value;

        //        AssemblyPart asmPart = new AssemblyPart();

        //        StreamResourceInfo streamInfo = Application.GetResourceStream(new StreamResourceInfo(e.Result, "application/binary"), new Uri(source, UriKind.Relative));

        //        if (source == CurrentControl.ControlConfig.XapName + ".dll")
        //        {
        //            CurrentControl.asm = asmPart.Load(streamInfo.Stream);
        //        }
        //        else
        //        {
        //            asmPart.Load(streamInfo.Stream);
        //        }
        //    }

        //    if (CurrentControl.ControlConfig.ViewMode == "R")
        //    {
        //        CurrentControl.CompositeControl = CurrentControl.asm.CreateInstance(CurrentControl.ControlConfig.XapName + "." + CurrentControl.ControlConfig.RenderPage) as UIElement;
        //        // ConvertClass.SetXapValue(CurrentControl);
        //    }
        //    else
        //    {
        //        CurrentControl.CompositeControl = CurrentControl.asm.CreateInstance(CurrentControl.ControlConfig.XapName + "." + CurrentControl.ControlConfig.Page) as UIElement;
        //        //ConvertClass.SetXapValue(CurrentControl);
        //    }
        //    //if (CurrentControl.ControlConfig.ViewMode.Equals("R"))
        //    //{
        //    //    CompositeControlCreatedMethod();
        //    //}
        //    //CurrentControl.CompositeControl.SetProperty("DataSource", CurrentControl.DataSource);
        //}

        public object GetXapValue(ControlClass cntrl, string propertyName)
        {
            //Type service;
            //if (cntrl.ControlConfig.ViewMode == "R")
            //    service = cntrl.asm.GetType(cntrl.ControlConfig.XapName + "." + cntrl.ControlConfig.RenderPage);
            //else
            //    service = cntrl.asm.GetType(cntrl.ControlConfig.XapName + "." + cntrl.ControlConfig.Page);

            //PropertyInfo oParam = service.GetProperty(propertyName);
            //if (oParam != null)
            //{
            //    return cntrl.CompositeControl.GetProperty(propertyName);
            //}
            //else if (cntrl.ControlType == ControlTypes.CompositeControl)
            //{
            //    object viewModel = cntrl.CompositeControl.GetProperty("ViewModel");
            //    if (viewModel != null)
            //    {
            //        return viewModel.GetProperty(propertyName);
            //    }
            //}
            //return null;

            return GetRefPropValue(cntrl.CompositeControl, propertyName);
        }

        public static bool SetXapValue(ControlClass cntrl, string propertyName, object value)
        {
            //Type service;
            //if (cntrl.ControlConfig.ViewMode == "R")
            //    service = cntrl.asm.GetType(cntrl.ControlConfig.XapName + "." + cntrl.ControlConfig.RenderPage);
            //else
            //    service = cntrl.asm.GetType(cntrl.ControlConfig.XapName + "." + cntrl.ControlConfig.Page);

            //PropertyInfo oParam = service.GetProperty(propertyName);
            //if (oParam != null)
            //{
            //    cntrl.CompositeControl.SetProperty(propertyName, value);
            //}
            //else if (cntrl.ControlType == ControlTypes.CompositeControl)
            //{
            //    object viewModel = cntrl.CompositeControl.GetProperty("ViewModel");
            //    if (viewModel != null)
            //    {
            //        viewModel.SetProperty(propertyName, value);
            //    }
            //}
            //return true;

            SetRefPropValue(cntrl.CompositeControl, propertyName, value);
            return true;
        }


        public object GetRefPropValue(object refAsembly, string propertyName)
        {
            string[] strProps = propertyName.Split('.');

            foreach (string strProp in strProps)
            {
                if (refAsembly != null)
                {
                    Type propType = refAsembly.GetType();
                    PropertyInfo oProp = propType.GetProperty(strProp);

                    if (oProp != null)
                    {
                        refAsembly = refAsembly.GetProperty(strProp);
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            return refAsembly;
        }

        public static void SetRefPropValue(object refAsembly, string propertyName, object value)
        {
            string[] strProps = propertyName.Split('.');

            for (int i = 0; i < strProps.Length; i++)
            {
                if (refAsembly != null)
                {
                    Type propType = refAsembly.GetType();
                    PropertyInfo oProp = propType.GetProperty(strProps[i]);

                    if (oProp != null)
                    {
                        if (i == (strProps.Length - 1))
                        {
                            refAsembly.SetProperty(strProps[i], value);
                        }
                        else
                        {
                            refAsembly = refAsembly.GetProperty(strProps[i]);
                        }
                    }
                    else
                    {
                        refAsembly = null;
                        break;
                    }
                }
            }
        }


        public static List<string> GetFontList()
        {
            List<string> fonts = new List<string>();
            //var typefaces = System.Windows.Media.Fonts.SystemTypefaces;

            //foreach (System.Windows.Media.Typeface face in typefaces)
            //{
            //    System.Windows.Media.GlyphTypeface g;
            //    face.TryGetGlyphTypeface(out g);

            //    var fontname = g.FontFileName;
            //    fontname = fontname.Substring(0, fontname.IndexOf('.'));
            //    fonts.Add(fontname);
            //}

            fonts.Add("Arial");
            fonts.Add("Arial Black");
            fonts.Add("Comic Sans MS");
            fonts.Add("Courier New");
            fonts.Add("Georgia");
            fonts.Add("Lucida Sans Unicode");
            fonts.Add("Portable User Interface");
            fonts.Add("Times New Roman");
            fonts.Add("Trebuchet MS");
            fonts.Add("Verdana");
            fonts.Add("Webdings");

            return fonts;
        }

        /// <summary>
        /// Create grid data from the xml.
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static List<DataSoureResult> CreateGridDataFromXML(string xml, ControlClass ctrl)
        {
            try
            {
                string orgXml = string.Empty;

                if (xml.StartsWith("\"") && xml.EndsWith("\""))
                {
                    orgXml = xml.Substring(1, xml.Length - 2);
                }
                else
                {
                    orgXml = xml;
                }

                XDocument xmlDoc = XDocument.Parse(orgXml);

                //AssemblyName assemblyName = new AssemblyName();
                //assemblyName.Name = "tmpAssembly";
                //AssemblyBuilder assemblyBuilder = Thread.GetDomain().DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);
                //ModuleBuilder module = assemblyBuilder.DefineDynamicModule("tmpModule");

                //TypeBuilder typeBuilder = module.DefineType("BindableRowCellCollection", TypeAttributes.Public | TypeAttributes.Class);

                //ctrl.Items.Clear();
                //foreach (XElement fElement in xmlDoc.Root.Elements())
                //{
                //    foreach (XElement xelement in fElement.Nodes())
                //    {
                //        string propertyName = xelement.Name.LocalName;


                //        // Generate a private field
                //        FieldBuilder field = typeBuilder.DefineField("_" + propertyName, typeof(string), FieldAttributes.Private);
                //        // Generate a public property
                //        PropertyBuilder property =
                //            typeBuilder.DefineProperty(propertyName,
                //                             PropertyAttributes.None,
                //                             typeof(string),
                //                             new Type[] { typeof(string) });

                //        MethodAttributes GetSetAttr =
                //            MethodAttributes.Public |
                //            MethodAttributes.HideBySig;

                //        MethodBuilder currGetPropMthdBldr =
                //            typeBuilder.DefineMethod("get_value",
                //                                       GetSetAttr,
                //                                       typeof(string),
                //                                       Type.EmptyTypes);

                //        ILGenerator currGetIL = currGetPropMthdBldr.GetILGenerator();
                //        currGetIL.Emit(OpCodes.Ldarg_0);
                //        currGetIL.Emit(OpCodes.Ldfld, field);
                //        currGetIL.Emit(OpCodes.Ret);

                //        MethodBuilder currSetPropMthdBldr =
                //            typeBuilder.DefineMethod("set_value",
                //                                       GetSetAttr,
                //                                       null,
                //                                       new Type[] { typeof(string) });


                //        ILGenerator currSetIL = currSetPropMthdBldr.GetILGenerator();
                //        currSetIL.Emit(OpCodes.Ldarg_0);
                //        currSetIL.Emit(OpCodes.Ldarg_1);
                //        currSetIL.Emit(OpCodes.Stfld, field);
                //        currSetIL.Emit(OpCodes.Ret);

                //        property.SetGetMethod(currGetPropMthdBldr);
                //        property.SetSetMethod(currSetPropMthdBldr);

                //        //if (!GlobalVariable.DesignMode)
                //        //{

                //        //BuildItems(ctrl, property.Name, property.PropertyType);
                //        //}
                //    }
                //    break;
                //}

                //List<object> generatedRows = new List<object>();
                List<DataSoureResult> generatedRows = new List<DataSoureResult>();
                foreach (XElement xelement in xmlDoc.Root.Elements())
                {
                    DataSoureResult generetedObject = new DataSoureResult();

                    foreach (XElement xelem in xelement.Nodes())
                    {
                        var curItems = ctrl.Items.Where(o => o.XMLKey == GetNamespace(xelem, string.Empty));
                        if (curItems.Count() > 0)
                        {
                            string value = xelem.Value;
                            generetedObject.Results.Add(new CommandData()
                            {
                                Value = value,
                                Column = curItems.ElementAt(0).Key,
                                DataType = DataTypes.SingleLineText,
                            });
                        }
                    }

                    generetedObject.Results.Add(new CommandData()
                    {
                        Value = Guid.NewGuid(),
                        Column = "DefaultGridID",
                        DataType = DataTypes.SingleLineText,
                    });
                    generetedObject.Results.Add(new CommandData()
                    {
                        Value = 0,
                        Column = "Mod_Status_Flag",
                        DataType = DataTypes.SingleLineText,
                    });

                    generatedRows.Add(generetedObject);
                }
                return generatedRows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public static string GetNamespace(XElement element, string retVal)
        {
            string temp = string.Empty;
            if (element == null)
                return retVal;
            else
            {
                temp = element.Name.LocalName;
                return GetNamespace(element.Parent, retVal) + "/" + temp;
            }
        }

        /// <summary>
        /// Create xml from the grid data.
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static string CreateGridXML(ControlClass ctrl)
        {
            try
            {
                List<DataSoureResult> lstRows = ctrl.Value as List<DataSoureResult>;
                if (lstRows == null)
                {
                    return string.Empty;
                }
                string orgXml = string.Empty;

                if (ctrl.XMLValue.StartsWith("\"") && ctrl.XMLValue.EndsWith("\""))
                {
                    orgXml = ctrl.XMLValue.Substring(1, ctrl.XMLValue.Length - 2);
                }
                else
                {
                    orgXml = ctrl.XMLValue;
                }

                XDocument testDoc = XDocument.Parse(orgXml);

                string attributes = string.Empty;
                attributes = GetAttributes(testDoc.Root.FirstAttribute, " ");
                string start = testDoc.Root.Name.LocalName;
                string end = ((System.Xml.Linq.XElement)(((System.Xml.Linq.XContainer)(testDoc.Root)).FirstNode)).Name.LocalName;

                StringBuilder strBuildXML = new StringBuilder();
                strBuildXML.AppendLine("<" + start + attributes + ">");
                foreach (DataSoureResult row in lstRows)
                {
                    if (row.Results.Where(o => o.Column == "Mod_Status_Flag" && o.Value.ToString() == "3").Count() > 0)
                    {
                        continue;
                    }
                    strBuildXML.AppendLine("<" + end + ">");
                    foreach (Item item in ctrl.Items)
                    {
                        strBuildXML.Append("<" + item.Key + ">");
                        strBuildXML.Append(row.Results.Where(o => o.Column == item.Key).ElementAt(0).Value.ToString());
                        strBuildXML.AppendLine("</" + item.Key + ">");
                    }
                    strBuildXML.AppendLine("</" + end + ">");
                }
                strBuildXML.AppendLine("</" + start + ">");

                return strBuildXML.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private static string GetAttributes(XAttribute atr, string strAttr)
        {
            if (atr != null)
            {
                strAttr += atr.ToString() + " ";
                GetAttributes(atr.NextAttribute, strAttr);
            }
            return strAttr;
        }

        /// <summary>
        /// Create list items from xml.
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        public static ObservableCollection<Item> CreateListDataFromXML(string xml, ControlClass ctrl)
        {
            try
            {
                if (xml.StartsWith("\"") && xml.EndsWith("\""))
                {
                    xml = xml.Substring(1, xml.Length - 2);
                }

                ObservableCollection<Item> items = new ObservableCollection<Item>();
                XDocument xmlDoc = XDocument.Parse(xml);

                foreach (XElement xelement in xmlDoc.Root.Elements())
                {
                    string key = string.Empty;
                    string value = string.Empty;

                    var keys = xelement.DescendantNodes().Where(o => o.NodeType == System.Xml.XmlNodeType.Element && ((XElement)o).Name.LocalName == ctrl.DataSource.DisplayMember.Name);
                    var values = xelement.DescendantNodes().Where(o => o.NodeType == System.Xml.XmlNodeType.Element && ((XElement)o).Name.LocalName == ctrl.DataSource.ValueMember.Name);
                    if (keys.Count() > 0 && values.Count() > 0)
                    {
                        key = ((XElement)keys.ElementAt(0)).Value.ToString();
                        value = ((XElement)values.ElementAt(0)).Value.ToString();
                    }
                    else
                    {
                        var keysAttr = xelement.Attributes().Where(o => ((XAttribute)o).Name.LocalName == ctrl.DataSource.DisplayMember.Name);
                        var valuesAttr = xelement.Attributes().Where(o => ((XAttribute)o).Name.LocalName == ctrl.DataSource.ValueMember.Name);
                        if (keysAttr.Count() > 0 && valuesAttr.Count() > 0)
                        {
                            key = ((XAttribute)keysAttr.ElementAt(0)).Value.ToString();
                            value = ((XAttribute)valuesAttr.ElementAt(0)).Value.ToString();
                        }
                        else
                        {
                            continue;
                        }
                    }

                    items.Add(new Item() { Key = key, Value = value, IsSelected = false });
                }
                return items;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Create xml from list items.
        /// </summary>
        /// <param name="ctrl"></param>
        /// <returns></returns>
        private static string CreateListXML(ControlClass ctrl)
        {
            try
            {
                XDocument testDoc = XDocument.Parse(ctrl.XMLValue);
                string start = testDoc.Root.Name.LocalName;
                StringBuilder strBuildXML = new StringBuilder();

                strBuildXML.AppendLine("<" + start + ">");

                foreach (Item item in ctrl.Items)
                {
                    strBuildXML.AppendLine("<" + item.Key + ">");
                    strBuildXML.AppendLine(item.IsSelected.ToString());
                    strBuildXML.AppendLine("</" + item.Key + ">");
                }

                strBuildXML.AppendLine("</" + start + ">");

                return strBuildXML.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Builds the columns for building grid from xml.
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="propertyName"></param>
        /// <param name="propertyType"></param>
        /// <param name="controlID"></param>
        public static void BuildItems(ControlClass ctrl, string propertyName, Type propertyType)
        {
            try
            {
                Item colItem = new Item();
                colItem.IsSelected = true;
                colItem.Key = propertyName;
                colItem.TabID = "0";
                colItem.TabItem = new ControlClass();
                colItem.Value = propertyName;
                colItem.TabItem.ID = 0;
                colItem.TabItem.ParentID = ctrl.ID.ToString();
                colItem.TabItem.IsGridItem = true;
                switch (colItem.Type)
                {
                    case DataGridColumnType.CheckBox:
                        colItem.TabItem.ControlType = ControlTypes.CheckBox;
                        colItem.TabItem.DataType.DataType = DataTypes.Boolean;
                        break;
                    case DataGridColumnType.ComboBox:
                        colItem.TabItem.ControlType = ControlTypes.ComboBox;
                        colItem.TabItem.DataType.DataType = DataTypes.SingleLineText;
                        break;
                    case DataGridColumnType.DatePicker:
                        colItem.TabItem.ControlType = ControlTypes.DateTimePicker;
                        colItem.TabItem.DataType.DataType = DataTypes.DateTime;
                        break;
                    case DataGridColumnType.TextBox:
                        colItem.TabItem.ControlType = ControlTypes.TextBox;
                        colItem.TabItem.DataType.DataType = DataTypes.SingleLineText;
                        break;
                    case DataGridColumnType.RadioButtonGroup:
                        colItem.TabItem.ControlType = ControlTypes.RadioButtonGroup;
                        colItem.TabItem.DataType.DataType = DataTypes.Boolean;
                        break;
                    default:
                        break;
                }
                colItem.TabItem.MappedColumn.InternalName = colItem.Key;
                colItem.TabItem.Value = propertyName;
                colItem.TabItem.MappedColumn.DisplayName = ctrl.MappedColumn.DisplayName + "Column" + colItem.TabItem.ID.ToString();

                ctrl.Items.Add(colItem);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void GetXMLNodeValue(XElement elem, string nodeName)
        {

        }
        #region IDisposable Members

        ~ConvertClass()
        {
            Dispose(true);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.CurrentControl = null;
            }
        }

        #endregion

        internal static object CreateSearchDataFromXml(string _xmlValue, ControlClass controlClass)
        {
            return null;
        }
    }
}
