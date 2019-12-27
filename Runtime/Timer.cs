using System;
using UnityEngine;

namespace Beef.Timer
{

	public struct Timer
	{
		public float StartTime { get; private set; }
		private float delay;
		event Action onCompletion;
		public bool DeleteOnCompletion { get; private set; }
		public bool Completed => Time.time - StartTime >= delay;

		public Timer( float delay, bool deleteOnCompletion, Action onCompletion = null)
		{
			this.StartTime = Time.time;
			this.delay = delay;
			this.DeleteOnCompletion = deleteOnCompletion;
			this.onCompletion = onCompletion;
			TimerHandler.AddTimer(this);
		}
		
		public void TickTimer()
		{
			if (Completed)
			{
				this.onCompletion?.Invoke();
				this.onCompletion = null;
			}
		}
	}
}
