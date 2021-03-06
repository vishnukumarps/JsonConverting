using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFormsJsonParser.Utills
{
    public enum ControlTypes
    {
        FormViewer=0,
        FormRowViewer=1,
        Form=2,
        TabControl=3,
        TabChild=4,
        Grid=5,
        Label=6,
        Text=7,
        LookUp=8,
        DateTimePicker=9,
        RadioButtonGroup=10,
        CheckBoxGroup=11,
        ComboBox=12,
        Button=13,
        CustomXap=14,
        BlankControl=15,
        MainForm,
        CompositeControl,
        Search,
        ListBox,
        Calendar,
        ImageButton,
        CheckBox,
        HyperlinkButton,
        FileUpload,
        Image,
        TreeView,
        RichTextBox,
        FormDataSource,
        AutoID,
        GUID,
        ValidationControl,
        VersionControl,
        RadioButton,
        GridView,
        ExternalForm,
        DynamicGrid,
        CompositeColumn,
        AutoCompleteTextBox,
        MultiListBox,
        Chart,
        PeoplePicker,
        PasswordBox,
        Border,
        SpinEditor,
        MaskEditor,
        Timer,
        Menu,
        LastControl,
        MetaDataControl,
        Captcha,
        DataViewControl,
        HiddenControl,
        Spreadsheet,
        SpreadsheetCell,
        ContentEditor = 55,
        DataTable = 56
    }
}
