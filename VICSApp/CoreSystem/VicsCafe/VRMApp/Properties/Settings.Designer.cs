﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VRMApp.Properties {
    
    
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
        [global::System.Configuration.DefaultSettingValueAttribute("White")]
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
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int VRMApp_VRMGateway_RoundFee {
            get {
                return ((int)(this["VRMApp_VRMGateway_RoundFee"]));
            }
            set {
                this["VRMApp_VRMGateway_RoundFee"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.4")]
        public decimal VRMApp_VRMGateway_CUSTODYFEE {
            get {
                return ((decimal)(this["VRMApp_VRMGateway_CUSTODYFEE"]));
            }
            set {
                this["VRMApp_VRMGateway_CUSTODYFEE"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.WebServiceUrl)]
        [global::System.Configuration.DefaultSettingValueAttribute("http://localhost:3492/VRMService.asmx")]
        public string VRMApp_VRMGateway_VRMService {
            get {
                return ((string)(this["VRMApp_VRMGateway_VRMService"]));
            }
            set {
                this["VRMApp_VRMGateway_VRMService"] = value;
            }
        }
    }
}
