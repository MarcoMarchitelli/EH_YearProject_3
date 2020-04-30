namespace SweetRage
{
	using UnityEngine;

	public abstract class AbsEnemyElementHandler : AbsEffectHandler<ElementScriptableEnum>
	{
		[Header("AbsEnemyElementHandler Params"), Space]
		[SerializeField] private ElementScriptableEnum _elementType;
		[Space, Tooltip("Durata dell'effetto alla prima applicazione")]
		public float duration = 1f;
		public bool refreshDuration = true;
		[Tooltip("Tempo extra aggiunto all'effetto se viene riapplicato mentre è ancora in corso")]
		public float extraTime = 1f;


		public override IEffectEnum effectType 
		{
			get => _elementType;
		}	
	}
}