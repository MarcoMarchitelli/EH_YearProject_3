namespace TotemTD
{
	using Deirin.EB;
	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine.Events;
	using Deirin.Utilities;

	[RequireComponent(typeof(Wave))]
	public class GiveTurretModule : BaseBehaviour
	{
		[Header("Params"), Space]
		public TurretModule module;
		public int number = 1;

		public bool standardAutoAdd = true;

		[Header("Events"), Space]
		[Tooltip("Called during OnEnemySpawn")] public UnityEvent onSpawnedEnemyNotExceedThreshold;
		[Tooltip("Called during OnEnemySpawn")] public UnityEvent onSpawnedEnemyExceedThreshold;

		//Property
		public Wave TargetWave { get; private set; }


		protected override void CustomSetup()
		{
			base.CustomSetup();
			number = Mathf.Max(1, number);
			TargetWave = GetComponent<Wave>();
			//TODO: Subscribe to correct event if "standardAutoAdd" == true
		}

		//TODO: Function to instantiate (or tell someone to do it) modules 

	}

}