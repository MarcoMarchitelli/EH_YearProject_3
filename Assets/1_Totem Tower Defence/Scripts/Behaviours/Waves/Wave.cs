namespace TotemTD
{
    using Deirin.EB;
    using UnityEngine;
	using System.Collections;
	using System.Collections.Generic;
    using UnityEngine.Events;

    [DisallowMultipleComponent]
	public class Wave : BaseBehaviour
	{

		[Header("Events"), Space]
		public UnityEvent onWaveStart;
		public UnityEvent onWaveEnd;

	}

}