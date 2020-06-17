using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EAAutoFramework.Config
{
   public class ConfigReader
    {
        public static string InitializeTest()
        {
            return ConfigurationManager.AppSetting["URL"].ToString();

             
        }
    }
}
