using EAAutoFramework.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace EATestProject.Base
{
  public class HookInitialize: TestInitializeHook
    {
        public HookInitialize(): base(BrowserType.Chrome)
        {
            InitializeSetting();
            NavigateSite();
                
        }
    }
}
