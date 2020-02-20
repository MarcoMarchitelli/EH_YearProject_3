using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class EnemyElementsContainer : ElementsContainer
{
	protected Dictionary<ElementScriptableEnum, Dictionary<int, float>> elementsChargeExpire = new Dictionary<ElementScriptableEnum, Dictionary<int, float>>();


	protected void AddNewElementToElementChargeExpire(ElementScriptableEnum element, int charge, float time, float extraTime, bool forceReset = false)
	{
		time = Mathf.Max(time, 0);
		extraTime = Mathf.Max(extraTime, 0);

		if (elementsChargeExpire == null)
		{
			elementsChargeExpire = new Dictionary<ElementScriptableEnum, Dictionary<int, float>>();
		}

		if (!elementsChargeExpire.ContainsKey(element))
		{
			elementsChargeExpire.Add(element, new Dictionary<int, float>());
		}

		if (!elementsChargeExpire[element].ContainsKey(charge))
		{
			elementsChargeExpire[element].Add(charge, time);
		}
		else
		{
			if (forceReset)
			{
				elementsChargeExpire[element][charge] = time;
			}
			else
			{
				elementsChargeExpire[element][charge] += extraTime;
			}
		}
	}


	public override void Add(ElementScriptableEnum element, int charge)
	{
		if (charge > 0)
		{
			List<EnemyElementHandler> eehList = Entity.GetBehaviours<EnemyElementHandler>();
			EnemyElementHandler selectedElementHandler = eehList.Find(x => x.elementType == element);
			if (selectedElementHandler != null)
			{
				int realCharge = Mathf.Min(maxCharge, selectedElementHandler.maxCharge, charge);
				if (!elementsDictionary.ContainsKey(element))
				{
					elementsDictionary.Add(element, realCharge);
					//TODO: replace Time.time with some value that indicate real game time, to avoid some weird case
					AddNewElementToElementChargeExpire( element, 
														realCharge, 
														selectedElementHandler.duration + Time.time,
														selectedElementHandler.extraTime,
														true );
				}

				//TODO: replace Time.time with some value that indicate real game time, to avoid some weird case
				elementsDictionary[element] = Mathf.Max(elementsDictionary[element], realCharge);
				AddNewElementToElementChargeExpire( element,
												    realCharge,
												    selectedElementHandler.duration + Time.time,
												    selectedElementHandler.extraTime,
												    false );
				
				OnAddElement?.Invoke(element, elementsDictionary[element]);
				//Debug.LogWarning(elementsDictionary[element] + " | " + Time.time);
			}
		}
	}

	public override void Remove(ElementScriptableEnum element, int charge)
	{
		int actMaxCharge = 0;
		elementsChargeExpire[element].Remove(charge);

		for (int i = 1; i <= maxCharge; i++)
		{
			if (elementsChargeExpire[element].ContainsKey(i))
			{
				actMaxCharge = i;
			}
		}

		elementsDictionary[element] = actMaxCharge;

		if (actMaxCharge <= 0)
		{
			elementsDictionary.Remove(element);
			elementsChargeExpire.Remove(element);
		}

		OnRemoveElement?.Invoke(element, actMaxCharge);
		//Debug.LogWarning(actMaxCharge + " | " + Time.time);
	}


	public override void OnUpdate()
	{
		
		foreach (var elementItem in elementsChargeExpire.ToList())
		{
			//TODO: replace Time.time with some value that indicate real game time, to avoid some weird case
			var elementsToRemove = elementItem.Value.Where(x => x.Value <= Time.time).ToList();
			foreach(var item in elementsToRemove)
			{
				Remove(elementItem.Key, item.Key);
			}
		}

	}

}
