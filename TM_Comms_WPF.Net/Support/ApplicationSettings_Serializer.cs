﻿using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ApplicationSettingsNS
{
    public class ApplicationSettings_Serializer
    {
        public static ApplicationSettings Load(string file)
        {
            StreamReader sr;
            ApplicationSettings app;
            XmlSerializer serializer = new XmlSerializer(typeof(ApplicationSettings));
            try
            {
                sr = new StreamReader(file);
            }
            catch (FileNotFoundException)
            {
                ApplicationSettings_Serializer.Save(file, new ApplicationSettings());
                sr = new StreamReader(file);
            }

            app = (ApplicationSettings)serializer.Deserialize(sr);
            sr.Close();
            return app;
        }
        public static void Save(string file, ApplicationSettings app)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ApplicationSettings));
            using (StreamWriter sw = new StreamWriter(file))
            {
                serializer.Serialize(sw, app);
            }
        }

        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class ApplicationSettings
        {
            public string RobotIP { get; set; } = "192.168.1.1";

            public string[] ModbusComboBoxIndices { get; set; } = {
                "Current Base With Tool X",
                "Current Base With Tool Y",
                "Current Base With Tool Z",
                "Current Base With Tool Rx",
                "Current Base With Tool Ry",
                "Current Base With Tool Rz",
                "TCP Force X",
                "TCP Force Y",
                "TCP Force Z",
                "TCP Force 3D"};

            public string[] ModbusUserComboBoxIndices { get; set; } = {
                "Int16",
                "Int16",
                "Int16",
                "Int16",
                "Int16",
                "Int16",
                "Int16",
                "Int16",
                "Int16",
                "Int16"};

        }
    }
}