using Deirin.EB;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ElementsContainer : BaseBehaviour
{
	protected Dictionary<ElementSource.ElementTypeEnum, int> elementsDictionary = new Dictionary<ElementSource.ElementTypeEnum, int>();
	public int maxCharge = 3;

	public UnityElementTypeIntEvent OnAddElement;
	public UnityElementTypeIntEvent OnRemoveElement;
	public UnityEvent OnRemoveAll;

	protected override void CustomSetup()
	{
		base.CustomSetup();
		maxCharge = Mathf.Max(maxCharge, 0);
	}

	public virtual void Add(ElementSource.ElementTypeEnum element, int charge)
	{
		if (charge > 0)
		{
			if (elementsDictionary.ContainsKey(element))
			{
				elementsDictionary[element] = Mathf.Min(maxCharge, elementsDictionary[element] + charge);
			}
			else
			{
				elementsDictionary.Add(element, Mathf.Min(maxCharge, charge));
			}
			OnAddElement?.Invoke(element, elementsDictionary[element]);
			//Debug.LogWarning(Entity + "." + element + " --> " + elementsDictionary[element]);
		}
	}

	public void Add(ElementSource element)
	{
		if(element != null)
		{
			Add(element.elementType, 1);
		}
	}

	public virtual void Remove(ElementSource.ElementTypeEnum element, int charge)
	{
		if (charge > 0)
		{
			if (elementsDictionary.ContainsKey(element) && elementsDictionary[element] > 0)
			{
				int newChargeValue = Mathf.Max(0, elementsDictionary[element] - charge);
				elementsDictionary[element] = newChargeValue;
				if(newChargeValue <= 0)
				{
					elementsDictionary.Remove(element);
				}
				OnRemoveElement?.Invoke(element, newChargeValue);
			}
		}
	}
	
	public void Remove(ElementSource element)
	{
		if (element != null)
		{
			Remove(element.elementType, 1);
		}
	}

	public void RemoveAll()
	{
		elementsDictionary.Clear();
		OnRemoveAll?.Invoke();
	}

	public Dictionary<ElementSource.ElementTypeEnum, int> GetDictionary()
	{
		return new Dictionary<ElementSource.ElementTypeEnum, int>(elementsDictionary);
	}

	public void SendElementsToOtherContainers(BaseEntity reciver)
	{
		ElementsContainer ec;
		if(reciver != null && reciver.TryGetBehaviour<ElementsContainer>(out ec) && elementsDictionary != null)
		{
			foreach(var item in elementsDictionary)
			{
				ec.Add(item.Key, item.Value);
			}
		}
	}

}

[System.Serializable]
public class UnityElementTypeIntEvent : UnityEvent<ElementSource.ElementTypeEnum, int> { }