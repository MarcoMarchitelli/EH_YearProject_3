namespace SweetRage {
	using UnityEngine;

	[CreateAssetMenu( menuName = "Sweet Rage/Turret Type" )]
	public class TurretType : ScriptableObject {
		public enum ModuleType { shooter, element, modifier }
		public ModuleType moduleType;
	}
}