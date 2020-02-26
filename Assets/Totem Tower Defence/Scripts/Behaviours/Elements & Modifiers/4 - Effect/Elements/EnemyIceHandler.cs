namespace TotemTD
{
	using Deirin.EB;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;


	public class EnemyIceHandler : EnemyElementHandler
	{
		[Space, Tooltip("Percentuale di riduzione del movimento"), Range(0, 1)]
		public float slow = 0.3f;



	}

}