using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 内存回收
{
    class TestClassHasEvent
    {
        public delegate void TestEventHandler(object sender, EventArgs e);
        public event TestEventHandler YourEvent;
        protected void _Event(EventArgs e)
        {
            YourEvent?.Invoke(this, e);
        }
    }
    class TestListener
    {

        private TestClassHasEvent test;

        public TestListener(TestClassHasEvent _test)
        {
            test = _test;           
            test.YourEvent += new TestClassHasEvent.TestEventHandler(_Event);
        }

        void _Event(object sender, EventArgs e)
        {

        }
        public TestListener()
        {
            SystemEvents.DisplaySettingsChanged += new EventHandler(SystemEvents_DisplaySettingsChanged);//静态
        }

        void SystemEvents_DisplaySettingsChanged(object sender, EventArgs e)
        {

        }
    }
}
