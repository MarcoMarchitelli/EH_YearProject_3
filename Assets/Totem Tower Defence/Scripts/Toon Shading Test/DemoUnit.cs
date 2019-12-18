namespace ToonShadingDemo {
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using Deirin.EB;

	public class DemoUnit : MonoBehaviour {
		[Header("Refs")]
		public Rotator rotator;
		public DemoUnitUI UI;
		public Material material;

		private void Awake () {
			UI.demoUnit = this;
		}
	}
}