namespace TotemTD
{
	using Deirin.EB;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;


	public class EnemyFireHandler : AbsEnemyElementHandler
	{
		[Header("Fire Params"), Tooltip("Danni inflitti ad ogni tick"), Space]
		public float dps = 1;
		[Tooltip("Frequenza di applicazione dei danni")]
		public float tickFrequence = 0.5f;

		[Header("Fire Events"), Space]
		public UnityEvent OnTick;

	}

}