using Deirin.EB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShooterElements : BaseBehaviour
{
	private Dictionary<Element.ElementType, int> elementsDictionary;

	public UnityElementTypeIntEvent OnAddElement;
	public UnityElementTypeIntEvent OnRemoveElement;
	public UnityEvent OnRemoveAll;

	protected override void CustomSetup()
	{
		base.CustomSetup();
		elementsDictionary = new Dictionary<Element.ElementType, int>();
	}

	public void Add(Element element)
	{
		if(element != null)
		{
			Element.ElementType curentType = element.GetElementType();
			if (elementsDictionary.ContainsKey(curentType))
			{
				elementsDictionary[curentType]++;
			}
			else
			{
				elementsDictionary.Add(curentType, 1);
			}
			OnAddElement?.Invoke(curentType, elementsDictionary[curentType]);
			Debug.LogWarning(Entity + "." + curentType + " --> " + elementsDictionary[curentType]);
		}
	}

	public void Remove(Element element)
	{
		if (element != null)
		{
			Element.ElementType curentType = element.GetElementType();
			if (elementsDictionary.ContainsKey(curentType) && elementsDictionary[curentType] > 0)
			{
				elementsDictionary[curentType]--;
				OnRemoveElement?.Invoke(curentType, elementsDictionary[curentType]);
			}
		}
	}

	public void RemoveAll()
	{
		elementsDictionary = new Dictionary<Element.ElementType, int>();
		OnRemoveAll?.Invoke();
	}

	public Dictionary<Element.ElementType, int> GetDictionary()
	{
		return new Dictionary<Element.ElementType, int>(elementsDictionary);
	}

}

[System.Serializable]
public class UnityElementTypeIntEvent : UnityEvent<Element.ElementType, int> { }