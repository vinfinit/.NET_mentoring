using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection2
{
    class Program
    {
        static void Main(string[] args)
        {
            var eventPublisher = new EventPublisher();
            var program = new Program();
            var method = typeof(Program).GetMethod("HandleEvent", BindingFlags.NonPublic | BindingFlags.Instance);

            EventInfo eventInfo = typeof(EventPublisher).GetEvent("TestEvent");
            Type eventHandlerType = eventInfo.EventHandlerType;

            var handler = Delegate.CreateDelegate(eventHandlerType, program, method);

            eventInfo.AddEventHandler(eventPublisher, handler);
            eventPublisher.RaiseEvent();
        }

        void HandleEvent(object sender, EventArgs e)
        {
            Console.WriteLine("HandleEvent called");
        }
    }

    class EventPublisher
    {
        public event EventHandler TestEvent;

        public void RaiseEvent()
        {
            TestEvent(this, EventArgs.Empty);
        }
    }
}
