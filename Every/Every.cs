using System;

namespace NovelTheory
{
    public class Every
    {
        public int Total { get; private set; }

        private readonly int _repeatcount;
        private readonly Action<int> _action;

        public int Current { get; private set; }


        public Every(int repeatcount, Action<int> action)
        {
            _repeatcount = repeatcount;
            _action = action;
            Reset();
        }
        public void Next()
        {
            ++Current;
            ++Total;

            if (Current == _repeatcount)
            {
                _action(Total);
                Current = 0;
            }
        }

        public static Every operator ++(Every e)
        {
            e.Next();
            return e;
        }

        public void Reset()
        {
            Current = 0;
            Total = 0;
        }

        public void CallNow()
        {
            _action(Total);
        }


    }
}
