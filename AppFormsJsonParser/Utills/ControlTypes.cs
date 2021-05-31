﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppFormsJsonParser.Utills
{
    public enum ControlTypes
    {
        FormViewer=1,
        FormRowViewer=2,
        Form=3,
        TabControl=4,
        TabChild=5,
        Grid=6,
        Label=7,
        TextBox=8,
        LookUp=9,
        DateTimePicker=10,
        RadioButtonGroup=11,
        CheckBoxGroup=12,
        ComboBox=13,
        Button=14,
        CustomXap=15,
        BlankControl=16,
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