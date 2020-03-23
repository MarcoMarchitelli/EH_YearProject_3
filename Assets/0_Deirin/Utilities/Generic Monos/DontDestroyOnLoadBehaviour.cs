namespace Deirin.Utilities {
	using UnityEngine;

	public class DontDestroyOnLoadBehaviour : MonoBehaviour {
		private void Awake () {
			DontDestroyOnLoad( gameObject );
		}
	}
}