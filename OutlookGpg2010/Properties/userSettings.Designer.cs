﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.261
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OutlookGpg2010.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class userSettings : global::System.Configuration.ApplicationSettingsBase {
        
        private static userSettings defaultInstance = ((userSettings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new userSettings())));
        
        public static userSettings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AlwaysSign {
            get {
                return ((bool)(this["AlwaysSign"]));
            }
            set {
                this["AlwaysSign"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AlwaysEncrypt {
            get {
                return ((bool)(this["AlwaysEncrypt"]));
            }
            set {
                this["AlwaysEncrypt"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool AlwaysDecrypt {
            get {
                return ((bool)(this["AlwaysDecrypt"]));
            }
            set {
                this["AlwaysDecrypt"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool ShowDecryptPopUp {
            get {
                return ((bool)(this["ShowDecryptPopUp"]));
            }
            set {
                this["ShowDecryptPopUp"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Default SMTP-Address")]
        public string UsedEmailAddress {
            get {
                return ((string)(this["UsedEmailAddress"]));
            }
            set {
                this["UsedEmailAddress"] = value;
            }
        }
    }
}
