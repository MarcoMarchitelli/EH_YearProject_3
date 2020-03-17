namespace TotemTD
{
	using Deirin.EB;

	public class ModifierSource : BaseBehaviour, IEffectSource
	{
		public ModifierScriptableEnum modifierType;

		public IEffectEnum GetEffect()
		{
			return modifierType;
		}
	}

}