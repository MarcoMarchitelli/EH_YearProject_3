using Deirin.EB;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class EnemyFireHandler : EnemyElementHandler
{
	[Space, Tooltip("Danni inflitti ad ogni tick")]
	public float dps = 1;
	[Tooltip("Frequenza di applicazione dei danni")]
	public float tickFrequence = 0.5f;

	[Space] 
	public UnityEvent OnTick;

	public override ElementSource.ElementTypeEnum elementType 
	{ 
		get => ElementSource.ElementTypeEnum.Fire; 
	}
}
