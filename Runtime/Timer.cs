using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace QuickTimer
{
	public struct Timer
	{
		public float StartTime { get; private set; }
        public CancellationTokenSource TokenSource { get; private set; }
        private float delay;
		event Action onCompletion;
		public bool Completed => Time.time - StartTime >= delay;

        public Timer(float delay, Action onCompletion = null) : this()
        {
			this.StartTime = Time.time;
			this.delay = delay;
			this.onCompletion = onCompletion;

            if (onCompletion != null)
			    TimerHandler.AddTimer(this);
        }

        /// <summary>
        /// Initialises the timer for async use.
        /// </summary>
        public static Task Start(float delay) {
            Timer timer = new Timer(delay);

            timer.TokenSource = new CancellationTokenSource();
            CancellationToken ct = timer.TokenSource.Token;

            Task task = Task.Run(() => {
                while (!ct.IsCancellationRequested) { }
            }, timer.TokenSource.Token);

            TimerHandler.AddTimer(timer);
            return task;
        }

		public bool TickTimer()
		{
			if (Completed)
			{
				this.onCompletion?.Invoke();
				this.onCompletion = null;
				return true;
			}
			return false;
		}
	}
}
