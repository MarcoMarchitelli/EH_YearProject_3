namespace TotemTD {
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using TMPro;

	public class ModuleContainerUI : MonoBehaviour {
		[Header("Refs")]
		public TextMeshProUGUI text;
		public TurretModuleUI moduleUIPrefab;

		private List<TurretModule> modules;

		public void Setup () {

		}
	}
}