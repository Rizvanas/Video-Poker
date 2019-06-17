using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleVideoPoker
{
    public class ConsoleKeyEventArgs : EventArgs
    {
        public ConsoleKey Key { get; set; }
    }

    class KeypressDistributor
    {
        private ConsoleKeyInfo _keyInfo;
        public event EventHandler<ConsoleKeyEventArgs> KeyPressed;

        public void WaitForKeyPress()
        {
            _keyInfo = Console.ReadKey();
            OnKeyPressed(_keyInfo.Key);
        }

        protected virtual void OnKeyPressed(ConsoleKey key)
        {
            KeyPressed?.Invoke(this, new ConsoleKeyEventArgs { Key = key });
        }
    }
}
