namespace TotemTD
{
	using System.Collections.Generic;
	using UnityEngine;
    using UnityEngine.Events;

    [CreateAssetMenu(menuName = "TotemTD/Custom Game Events/Int Game Event")]
	public class IntGameEvent : ScriptableObject
	{
		[HideInInspector]
		public int value;
		private List<IntGameEventListener> listeners = new List<IntGameEventListener>();

		public void Subscribe(IntGameEventListener listener)
		{
			listeners.Add(listener);
		}

		public void Unsubscribe(IntGameEventListener listener)
		{
			listeners.Remove(listener);
		}

		public void Invoke()
		{
			for (int i = 0; i < listeners.Count; i++)
			{
				listeners[i].OnInvoke(value);
			}
		}

		public void Invoke(int e)
		{
			for (int i = 0; i < listeners.Count; i++)
			{
				listeners[i].OnInvoke(e);
			}
		}
	}

	[System.Serializable]
	public class UnityIntEvent : UnityEvent<int> { }

}