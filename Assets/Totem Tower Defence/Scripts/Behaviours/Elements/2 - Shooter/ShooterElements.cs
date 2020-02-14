using Deirin.EB;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterElements : BaseBehaviour
{
	private Dictionary<Element.ElementType, int> elementsDictionary;

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
			}
		}
	}

	public void RemoveAll()
	{
		elementsDictionary = new Dictionary<Element.ElementType, int>();
	}

	public Dictionary<Element.ElementType, int> GetDictionary()
	{
		return new Dictionary<Element.ElementType, int>(elementsDictionary);
	}

}
