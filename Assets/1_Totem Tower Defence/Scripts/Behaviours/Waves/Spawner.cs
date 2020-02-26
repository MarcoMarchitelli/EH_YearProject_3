namespace TotemTD
{
	using Deirin.EB;
	using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;
    using Deirin.Utilities;
    using UnityEngine.Events;

	[DisallowMultipleComponent]
    public class Spawner : BaseBehaviour
	{
		[Header("Params")]
		public Enemy enemy;
		public Vector3ArrayVariable pathPoints;
		public int enemeyToSpawnChunk = 1;
		public bool disableSpawner = false;

		[ReadOnly, Space]
		public int spawnedEnemy = 0;

		[Header("Events"), Space]
		public UnityEvent onSpawnerStart;
		public UnityEvent onSpawnerStop;
		public UnityEvent onEnemySpawn;

		protected override void CustomSetup()
		{
			base.CustomSetup();
			enemeyToSpawnChunk = Mathf.Max(0, enemeyToSpawnChunk);
			spawnedEnemy = 0;
		}

		public void StartSpawner()
		{
			disableSpawner = false;
			onSpawnerStart?.Invoke();
		}

		public void StopSpawner()
		{
			disableSpawner = true;
			onSpawnerStop?.Invoke();
		}

		public void SpawnEnemy()
		{
			if(enemy && !disableSpawner && pathPoints)
			{
				InstantiateEnemy();
				spawnedEnemy += enemeyToSpawnChunk;
				onEnemySpawn?.Invoke();
			}
		}

		private void InstantiateEnemy()
		{
			//Da Implementare
		}


	}

}