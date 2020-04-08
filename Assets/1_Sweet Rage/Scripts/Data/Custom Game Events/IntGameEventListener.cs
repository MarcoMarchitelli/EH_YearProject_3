namespace TotemTD
{
	using UnityEngine;

	public class IntGameEventListener : MonoBehaviour
	{
		public IntGameEvent gameEvent;
		public UnityIntEvent response;

		private void OnEnable()
		{
			gameEvent.Subscribe(this);
		}

		private void OnDisable()
		{
			gameEvent.Unsubscribe(this);
		}

		public void OnInvoke(int e)
		{
			response.Invoke(e);
		}
	}
}