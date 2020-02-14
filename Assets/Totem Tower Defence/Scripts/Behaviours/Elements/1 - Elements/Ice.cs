using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice : Element
{
	[Header("Custom Parameters")]
	[Range(0, 1)] public float slowPercent = .1f;
	public float duration;

	public override ElementType GetElementType()
	{
		return ElementType.Ice;
	}
}
