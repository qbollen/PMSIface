using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

using XmlUtils;

namespace Utils
{
    public class Params
    {
        public Params()
        {
           
        }

        public string Db
        {
            get
            {
                return GetText("DBPathSection","dbpath");
            }
        }

        public string Db_Room
        {
            get
            {
                return GetText("DBPathRoomSection","dbPath_room");
            }

            set
            {
                SetText("DBPathRoomSection", "dbpath_room", value);
            }
        }

        public string Ver
        {
            get
            {
                return GetText("VerSection","ver");
            }
        }

        private string GetText(string section, string key)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            CMySection mySection = (CMySection)config.GetSection(section);
            return mySection.KeyValues[key].Value;
        }

        private void SetText(string section, string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            CMySection mySection = (CMySection)config.GetSection(section);
            mySection.KeyValues.Clear();
            mySection.KeyValues.Add(new KeyValueSetting { Key = key, Value = value });
            config.Save(ConfigurationSaveMode.Full);
        }
        
    }
}
