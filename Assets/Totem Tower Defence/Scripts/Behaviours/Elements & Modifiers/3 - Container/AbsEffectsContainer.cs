namespace TotemTD
{
	using Deirin.EB;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;

	public abstract class AbsEffectsContainer<GenericEffectEnum, GenericEffectSource> : BaseBehaviour
		where GenericEffectEnum : IEffectEnum
		where GenericEffectSource : IEffectSource
	{
		protected Dictionary<GenericEffectEnum, int> effectsDictionary = new Dictionary<GenericEffectEnum, int>();
		public int maxCharge = 3;

		public Unity_IEffectEnum_Int_Event OnAddEffect;
		public Unity_IEffectEnum_Int_Event OnRemoveEffect;
		public UnityEvent OnRemoveAll;

		protected override void CustomSetup()
		{
			base.CustomSetup();
			maxCharge = Mathf.Max(maxCharge, 0);
		}

		public virtual void Add(GenericEffectEnum effect, int charge)
		{
			if (charge > 0)
			{
				if (effectsDictionary.ContainsKey(effect))
				{
					effectsDictionary[effect] = Mathf.Min(maxCharge, effectsDictionary[effect] + charge);
				}
				else
				{
					effectsDictionary.Add(effect, Mathf.Min(maxCharge, charge));
				}
				OnAddEffect?.Invoke(effect, effectsDictionary[effect]);
				//Debug.LogWarning(Entity + "." + element + " --> " + elementsDictionary[element]);
			}
		}

		public void Add(GenericEffectSource effect)
		{
			if (effect != null)
			{
				Add((GenericEffectEnum)effect.GetEffect(), 1);
			}
		}

		public virtual void Remove(GenericEffectEnum effect, int charge)
		{
			if (charge > 0)
			{
				if (effectsDictionary.ContainsKey(effect) && effectsDictionary[effect] > 0)
				{
					int newChargeValue = Mathf.Max(0, effectsDictionary[effect] - charge);
					effectsDictionary[effect] = newChargeValue;
					if (newChargeValue <= 0)
					{
						effectsDictionary.Remove(effect);
					}
					OnRemoveEffect?.Invoke(effect, newChargeValue);
				}
			}
		}

		public void Remove(GenericEffectSource effect)
		{
			if (effect != null)
			{
				Remove((GenericEffectEnum)effect.GetEffect(), 1);
			}
		}

		public void RemoveAll()
		{
			effectsDictionary.Clear();
			OnRemoveAll?.Invoke();
		}

		public Dictionary<GenericEffectEnum, int> GetDictionaryCopy()
		{
			return new Dictionary<GenericEffectEnum, int>(effectsDictionary);
		}

		public void SendEffectsToOtherContainers(BaseEntity reciver)
		{
			AbsEffectsContainer<GenericEffectEnum, GenericEffectSource> ec;
			if (reciver != null && reciver.TryGetBehaviour(out ec) && effectsDictionary != null)
			{
				foreach (var item in effectsDictionary)
				{
					ec.Add(item.Key, item.Value);
				}
			}
		}

	}

}
