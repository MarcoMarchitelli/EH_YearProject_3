namespace TotemTD
{
	using Deirin.EB;
	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;
    using UnityEngine.Events;
    using Deirin.Utilities;

    [RequireComponent(typeof(Spawner))]
	public class SpawnedEnemyThreshold : BaseBehaviour
	{
		[ReadOnly, SerializeField] Spawner spawner;

		[Header("Params"), Space]
		public int threshold = 0;

		[Header("Events"), Space]
		[Tooltip("Called during OnEnemySpawn")] public UnityEvent onSpawnedEnemyExceedThreshold;
		[Tooltip("Called during OnEnemySpawn")] public UnityEvent onSpawnedEnemyNotExceedThreshold;


		protected override void CustomSetup()
		{
			base.CustomSetup();
			threshold = Mathf.Max(0, threshold);
			spawner = GetComponent<Spawner>();
			spawner.onEnemySpawn.AddListener(CheckThreshold);
		}


		public void CheckThreshold()
		{
			if(threshold >= spawner.spawnedEnemy)
			{
				onSpawnedEnemyExceedThreshold?.Invoke();
			}
			else
			{
				onSpawnedEnemyNotExceedThreshold.Invoke();
			}
		}


	}

}