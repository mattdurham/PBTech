﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.296
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PBTech.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "10.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CREATE TABLE READING (r_id INTEGER PRIMARY KEY, r_date TEXT, r_name TEXT, r_descr" +
            "iption TEXT);")]
        public string CREATE_READING {
            get {
                return ((string)(this["CREATE_READING"]));
            }
            set {
                this["CREATE_READING"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CREATE TABLE CHANNEL (c_id INTEGER PRIMARY KEY, c_rid INTEGER,c_ccid integer, c_d" +
            "etails TEXT, c_channelnumber INTEGER);")]
        public string CREATE_CHANNEL {
            get {
                return ((string)(this["CREATE_CHANNEL"]));
            }
            set {
                this["CREATE_CHANNEL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CREATE TABLE READING_DETAIL (rd_id INTEGER PRIMARY KEY, rd_rid INTEGER, rd_cid IN" +
            "TEGER, rd_time INTEGER, rd_point INTEGER );")]
        public string CREATE_READING_DETAIL {
            get {
                return ((string)(this["CREATE_READING_DETAIL"]));
            }
            set {
                this["CREATE_READING_DETAIL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("INSERT INTO READING (r_date,r_name,r_description) VALUES (@date, @name, @descript" +
            "ion);\r\nselect last_insert_rowid()")]
        public string INSERT_READING {
            get {
                return ((string)(this["INSERT_READING"]));
            }
            set {
                this["INSERT_READING"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("INSERT INTO CHANNEL (c_rid,c_details,c_channelnumber,c_ccid) VALUES (@rid, @detai" +
            "ls,@number,@channelconfig);\r\nselect last_insert_rowid()")]
        public string INSERT_CHANNEL {
            get {
                return ((string)(this["INSERT_CHANNEL"]));
            }
            set {
                this["INSERT_CHANNEL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("INSERT INTO READING_DETAIL (rd_rid,rd_cid,rd_time,rd_point) VALUES (@rid, @cid, @" +
            "time,@point);\r\nselect last_insert_rowid()")]
        public string INSERT_READING_DETAIL {
            get {
                return ((string)(this["INSERT_READING_DETAIL"]));
            }
            set {
                this["INSERT_READING_DETAIL"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("CREATE TABLE CHANNEL_CONFIG (cc_id integer primary key,cc_name text, cc_psi, cc_o" +
            "utputvolts, cc_offset real,cc_defaultchannel);")]
        public string CREATE_CHANNEL_CONFIG {
            get {
                return ((string)(this["CREATE_CHANNEL_CONFIG"]));
            }
            set {
                this["CREATE_CHANNEL_CONFIG"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("INSERT INTO CHANNEL_CONFIG (cc_name,cc_psi,cc_outputvolts,cc_offset,cc_defaultcha" +
            "nnel) VALUES (@name,@psi,@outputvolts,@offset,@defaultchannel);\r\nselect last_ins" +
            "ert_rowid();")]
        public string INSERT_CHANNEL_CONFIG {
            get {
                return ((string)(this["INSERT_CHANNEL_CONFIG"]));
            }
            set {
                this["INSERT_CHANNEL_CONFIG"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("C:\\Users\\mattdurham\\Dropbox\\pbtech.db3")]
        public string DEFAULT_DB_PATH {
            get {
                return ((string)(this["DEFAULT_DB_PATH"]));
            }
            set {
                this["DEFAULT_DB_PATH"] = value;
            }
        }
    }
}
