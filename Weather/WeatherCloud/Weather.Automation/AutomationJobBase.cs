using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Weather.Automation
{
    public abstract class AutomationJobBase
    {
        public abstract void RunAutomation(FileInfo[] FInfo);
    }
}
