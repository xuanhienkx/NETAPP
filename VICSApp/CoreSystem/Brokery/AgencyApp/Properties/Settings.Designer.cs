﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.18408
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Brokery.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Drawing.Color DefaultRowBackColor {
            get {
                return ((global::System.Drawing.Color)(this["DefaultRowBackColor"]));
            }
            set {
                this["DefaultRowBackColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ControlLight")]
        public global::System.Drawing.Color DefaultSelectedRowBackColor {
            get {
                return ((global::System.Drawing.Color)(this["DefaultSelectedRowBackColor"]));
            }
            set {
                this["DefaultSelectedRowBackColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("MintCream")]
        public global::System.Drawing.Color AlternateRowBackColor {
            get {
                return ((global::System.Drawing.Color)(this["AlternateRowBackColor"]));
            }
            set {
                this["AlternateRowBackColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Control")]
        public global::System.Drawing.Color AlternateSelectedRowBackColor {
            get {
                return ((global::System.Drawing.Color)(this["AlternateSelectedRowBackColor"]));
            }
            set {
                this["AlternateSelectedRowBackColor"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Tp. Hà Nội")]
        public string AgencyLocation {
            get {
                return ((string)(this["AgencyLocation"]));
            }
            set {
                this["AgencyLocation"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Người lập biểu")]
        public string Report_Footer1 {
            get {
                return ((string)(this["Report_Footer1"]));
            }
            set {
                this["Report_Footer1"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Kế toán trưởng")]
        public string Report_Footer2 {
            get {
                return ((string)(this["Report_Footer2"]));
            }
            set {
                this["Report_Footer2"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Giám đốc")]
        public string Report_Footer3 {
            get {
                return ((string)(this["Report_Footer3"]));
            }
            set {
                this["Report_Footer3"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Chi nhánh: Tầng 4, Hà Thành Plaza, 102 Thái Thịnh, Đống Đa, Hà Nội Tel:(84-4) 351" +
            "48766 - Fax:(84-4) 35148768")]
        public string AgencyName {
            get {
                return ((string)(this["AgencyName"]));
            }
            set {
                this["AgencyName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("")]
        public string AgencyAddressAndTelephone {
            get {
                return ((string)(this["AgencyAddressAndTelephone"]));
            }
            set {
                this["AgencyAddressAndTelephone"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://gw.vics.com.vn/sbscore.net40/Brokery.asmx")]
        public string AgencyApp_AgencyWebService_GateWay {
            get {
                return ((string)(this["AgencyApp_AgencyWebService_GateWay"]));
            }
            set {
                this["AgencyApp_AgencyWebService_GateWay"] = value;
            }
        }
    }
}