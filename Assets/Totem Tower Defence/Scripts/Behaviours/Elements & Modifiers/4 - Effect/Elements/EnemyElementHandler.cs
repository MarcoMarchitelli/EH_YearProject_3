namespace TotemTD
{
	using Deirin.EB;
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using UnityEngine;
	using UnityEngine.Events;

	public abstract class EnemyElementHandler : BaseBehaviour
	{
		[SerializeField] private ElementScriptableEnum _elementType;

		[Header("Params"), Tooltip("Numero massimo di livelli consentiti per l'effetto")]
		public int maxCharge = 3;
		[Space, Tooltip("Durata dell'effetto alla prima applicazione")]
		public float duration = 1f;
		[Tooltip("Tempo extra aggiunto all'effetto se viene riapplicato mentre è ancora in corso")]
		public float extraTime = 1f;

		public ElementScriptableEnum elementType {
			get => _elementType;
		}
	}

}