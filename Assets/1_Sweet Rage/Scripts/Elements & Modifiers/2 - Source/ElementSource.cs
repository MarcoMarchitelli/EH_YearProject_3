namespace SweetRage
{
	using Deirin.EB;

	public class ElementSource : BaseBehaviour, IEffectSource
	{
		public ElementScriptableEnum elementType;

		public IEffectEnum GetEffect()
		{
			return elementType;
		}
	}

}