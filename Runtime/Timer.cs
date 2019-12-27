using System;
using UnityEngine;

namespace QuickTimer
{
	public struct Timer
	{
		public float StartTime { get; private set; }
		private float delay;
		event Action onCompletion;
		public bool Completed => Time.time - StartTime >= delay;

		public Timer(float delay, Action onCompletion = null)
		{
			this.StartTime = Time.time;
			this.delay = delay;
			this.onCompletion = onCompletion;
			TimerHandler.AddTimer(this);
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
