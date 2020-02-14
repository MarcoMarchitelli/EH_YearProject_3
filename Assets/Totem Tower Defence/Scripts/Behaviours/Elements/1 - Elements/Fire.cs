using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : Element
{
	[Header("Params")]
	public float DPS;
	public float duration;

	public override ElementType GetElementType()
	{
		return ElementType.Fire;
	}
}
