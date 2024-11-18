// Copyright (c) 2016-2024 James M. Curran/Novel Theory LLC.  All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.
//
using System;
using System.Threading;


namespace NovelTheory
{
    public class Every :IDisposable
    {

        private readonly int _repeatCount;
        private readonly Action<int> _action;

		// Current & Total need explicit backing fields so they can be used with Interlocked.Increment() 
		private int _current;
        private int _total;

        public int Current
        {
	        get => _current;
	        private set => _current = value;
        }
        public int Total
        {
	        get => _total;
	        private set => _total = value;
        }


		public Every(int repeatCount, Action<int> action)
        {
            _repeatCount = repeatCount;
            _action = action;
            Reset();
        }
        public void Next()
        {
	        if (_repeatCount != Int32.MaxValue)
	        {
		        Interlocked.Increment(ref _current);
		        Interlocked.Increment(ref _total);

		        if (Current == _repeatCount)
		        {
			        _action(Total);
			        Current = 0;
		        }
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

        public void Dispose()
        {
	        CallNow();
        }
		
		public static Every Never => new Every(Int32.MaxValue, i => { });


	}


	public class Percentage
	{
		readonly double _step;
		readonly Action<int, double> _action;

		double _percentage = 0.0;
		Every _every;

		public Percentage(int n, Action<int, double> action)
		{
			_action = action;

			var rep = (n < 100) ? 1 : (int)Math.Ceiling(n / 100.0);
			_step = 100.0 / ((double)n / rep);

			_every = new Every(rep, c =>
			{
				_percentage += _step;
				_action(c, _percentage);
			});
		}

		public  void Next() => this._every++;

		public static Percentage operator ++(Percentage percentage) 
		{
			percentage.Next();
			return percentage;
		}
		public void Finish()
		{
			if (_percentage < 100.00)
			{
				_percentage = 100.0 - _step;
				_every.CallNow();
			}
		}

		public static Percentage Never => new Percentage(Int32.MaxValue, (c, p) => { });

	}
}

