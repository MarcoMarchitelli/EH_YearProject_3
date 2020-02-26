namespace TotemTD
{
	using Deirin.EB;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;

	public abstract class AbsEffectsContainer<GenericEffectEnum, GenericEffectSource, GenericEffectHandler> : BaseBehaviour
		where GenericEffectEnum : IEffectEnum
		where GenericEffectSource : IEffectSource
		where GenericEffectHandler : AbsEffectHandler<GenericEffectEnum>
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

				List<GenericEffectHandler> GenericEffectHandlersList = Entity.GetBehaviours<GenericEffectHandler>();
				if(GenericEffectHandlersList != null)
				{
					GenericEffectHandler selectedEffectHandler = GenericEffectHandlersList.Find(x => x.effectType == (IEffectEnum)effect);
					if(selectedEffectHandler != null)
					{
						selectedEffectHandler.SetCurrentCharge(effectsDictionary[effect]);
					}
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

					List<GenericEffectHandler> GenericEffectHandlersList = Entity.GetBehaviours<GenericEffectHandler>();
					if (GenericEffectHandlersList != null)
					{
						GenericEffectHandler selectedEffectHandler = GenericEffectHandlersList.Find(x => x.effectType == (IEffectEnum)effect);
						if (selectedEffectHandler != null)
						{
							selectedEffectHandler.SetCurrentCharge(newChargeValue);
						}
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
			List<GenericEffectHandler> genericEffectHandlers = Entity.GetBehaviours<GenericEffectHandler>();
			if(genericEffectHandlers != null)
			{
				List<GenericEffectHandler> selectedEffectHandlers = genericEffectHandlers.FindAll(x => x.effectType is GenericEffectEnum);
				foreach (var item in selectedEffectHandlers)
				{
					item.SetCurrentCharge(0);
				}
			}
			

			effectsDictionary.Clear();
			OnRemoveAll?.Invoke();
		}

		public Dictionary<GenericEffectEnum, int> GetDictionaryCopy()
		{
			return new Dictionary<GenericEffectEnum, int>(effectsDictionary);
		}

		public void SendEffectsToOtherContainers(BaseEntity reciver)
		{
			AbsEffectsContainer<GenericEffectEnum, GenericEffectSource, GenericEffectHandler> ec;
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
