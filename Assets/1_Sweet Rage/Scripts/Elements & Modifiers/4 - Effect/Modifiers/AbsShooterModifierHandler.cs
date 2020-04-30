namespace SweetRage {
	using UnityEngine;

	public abstract class AbsShooterModifierHandler : AbsEffectHandler<ModifierScriptableEnum> {
		[Header("Base Params"), Space]
		[SerializeField] private ModifierScriptableEnum modifierType;

		public override IEffectEnum effectType {
			get => modifierType;
		}
	}
}