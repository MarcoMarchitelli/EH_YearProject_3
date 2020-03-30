namespace SweetRage
{
	using Deirin.EB;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;


	public class EnemyIceHandler : AbsEnemyElementHandler
	{
		[Header("Ice Params"), Tooltip("Percentuale di riduzione del movimento"), Range(0, 1), Space]
		public float slow = 0.3f;



	}

}