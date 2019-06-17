using System;

namespace ConsoleVideoPoker
{

    public class KeypressDistributor
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
