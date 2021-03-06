﻿namespace TotemTD {
    using UnityEngine;
    using UnityEngine.Events;

    public class Game_Placement : Game_BaseState {
        [Header("Events")]
        public UnityEvent OnLeftMouseClick;

        public override void Enter () {
            base.Enter();

            //placement phase graphics
            gameData.phaseUI.SetTexts( "PLACEMENT", "PHASE" );
            gameData.phaseUI.Play( .5f, () => gameData.phaseUI.Rewind( PhaseUIEndHandler ) );

            gameData.waveManager.OnPlaceTimeEnd.AddListener( gameData.GoNext );
        }

        public override void Tick () {
            if ( Input.GetMouseButtonDown( 0 ) )
                OnLeftMouseClick.Invoke();
        }

        private void PhaseUIEndHandler () {
            //activate turret menu
            gameData.turretMenu.Activate( true );
            //time graphics
            //gameData.placeTimeUI.Open();
            //HACK
            gameData.placeTimeUI.gameObject.SetActive( true );
            gameData.waveManager.StartPlaceTime();
        }

        public override void Exit () {
            base.Exit();
            gameData.waveManager.OnPlaceTimeEnd.RemoveListener( gameData.GoNext );
        }
    }
}