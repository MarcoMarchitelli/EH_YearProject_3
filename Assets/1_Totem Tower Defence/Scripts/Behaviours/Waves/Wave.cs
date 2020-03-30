namespace TotemTD
{
    using Deirin.EB;
    using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;
    using UnityEngine.Events;
	using System.Linq;
    using Deirin.Utilities;

    [DisallowMultipleComponent]
	public class Wave : BaseBehaviour, IStoppable
	{
		[Min(1)] int index = 0;
		//public TurretModule

		[Header("Events"), Space]
		public UnityIntEvent onPreWaveStart;
		public UnityIntEvent onPreWaveEnd;
		public UnityIntEvent onWaveStart;
		public UnityIntEvent onWaveEnd;

		//Property
		public bool Stopped { get; private set; }
		public IStoppable[] StoppableItems { get; private set; }



		protected override void CustomSetup()
		{
			base.CustomSetup();

			List<IStoppable> tmpStoppableItems = GetComponentsInChildren<IStoppable>().ToList();
			tmpStoppableItems.Remove(this);
			StoppableItems = tmpStoppableItems.ToArray();
			Stopped = true;
		}

		public void StartPreWave()
		{
			onPreWaveStart?.Invoke(index);
		}

		public void EndPreWave()
		{
			onPreWaveStart?.Invoke(index);
		}


		public void StartWave()
		{
			if(Stopped)
			{
				Stopped = false;
				onWaveStart?.Invoke(index);
			}
		}

		public void Stop(bool callEvent = true)
		{
			if(!Stopped)
			{
				Stopped = true;
				StopAllStoppableChilds();
				if(callEvent)
					onWaveEnd?.Invoke(index);
			}
		}

		private void StopAllStoppableChilds()
		{
			foreach(var stoppableItem in StoppableItems)
			{
				stoppableItem.Stop(false);
			}
		}

	}

}