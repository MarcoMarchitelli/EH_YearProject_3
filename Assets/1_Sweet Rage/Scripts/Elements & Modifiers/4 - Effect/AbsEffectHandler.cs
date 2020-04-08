namespace SweetRage
{
	using Deirin.EB;
	using Deirin.Utilities;
	using UnityEngine;

	public abstract class AbsEffectHandler<GenericEffectEnum> : BaseBehaviour
		where GenericEffectEnum : IEffectEnum
	{
		[Header("AbsEffectHandler Params"), Tooltip("Numero massimo di livelli consentiti per l'effetto")]
		public int maxCharge = 3;

		[SerializeField, ReadOnly]
		protected int currentCharge = 0;

		[Header("AbsEffectHandler Events"), Space]
		public UnityEvent_Int OnCurrentChargeRefresh;
		public UnityEvent_Int OnCurrentChargeIncreases;
		public UnityEvent_Int OnCurrentChargeDecreases;


		public abstract IEffectEnum effectType { get; }


		public void SetCurrentCharge(int value)
		{
			int oldValue = currentCharge;
			currentCharge = value;

			if (oldValue == value)
			{
				OnCurrentChargeRefresh?.Invoke(currentCharge);
			}
			else if (oldValue < value)
			{
				OnCurrentChargeIncreases?.Invoke(currentCharge);
			}
			else if (oldValue > value)
			{
				OnCurrentChargeDecreases?.Invoke(currentCharge);
			}

		}

		public int GetCurrentCharge()
		{
			return currentCharge;
		}

	}

}