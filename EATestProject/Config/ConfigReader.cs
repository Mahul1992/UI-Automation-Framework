using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace EAAutoFramework.Config
{
   public class ConfigReader
    {
     
        public static void SetFrameworkSetting()
        {
            XPathItem aut;
            XPathItem testtype;
            XPathItem islog;
            XPathItem isreport;
            XPathItem buildname;
            XPathItem logPath;

            String strFileName = Environment.CurrentDirectory.ToString() + "\\Config\\GlobalConfig.xml";
            FileStream fileStream = new FileStream(strFileName, FileMode.Open);
            XPathDocument document = new XPathDocument(fileStream);
            XPathNavigator navigator = document.CreateNavigator();
            aut = navigator.SelectSingleNode("EATestProject/RunSetting/AUT");

            //Get XML Details and pass it in XPathItem type variables
            aut = navigator.SelectSingleNode("EATestProject/RunSetting/AUT");
            buildname = navigator.SelectSingleNode("EATestProject/RunSetting/BuildName");
            testtype = navigator.SelectSingleNode("EATestProject/RunSetting/TestType");
            islog = navigator.SelectSingleNode("EATestProject/RunSetting/IsLog");
            isreport = navigator.SelectSingleNode("EATestProject/RunSetting/IsReport");
            logPath = navigator.SelectSingleNode("EATestProject/RunSetting/LogPath");

            //Set XML Details in the property to be used accross framework
            Settings.AUT = aut.Value.ToString();
            Settings.BuildName = buildname.Value.ToString();
            Settings.TestType = testtype.Value.ToString();
            Settings.IsLog = islog.Value.ToString();
            Settings.IsReporting = isreport.Value.ToString();
            Settings.LogPath = logPath.Value.ToString();
        }
    }
}
