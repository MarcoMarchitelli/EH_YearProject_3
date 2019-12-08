namespace TotemTD {
    using UnityEngine;
    using UnityEngine.Events;

    public class Game_Wave : Game_BaseState {
        [Header("Events")]
        public UnityEvent OnLeftMouseClick;

        public override void Enter () {
            base.Enter();

            //wave phase graphics
            gameData.phaseUI.SetTexts( "WAVE", "INCOMING" );
            gameData.phaseUI.Play( .5f, () =>
                gameData.phaseUI.Rewind(() => { 
                    //close time graphics
                    gameData.placeTimeUI.gameObject.SetActive( false );
                    //deactivate turret menu
                    gameData.turretMenu.Activate( false );
                    gameData.waveManager.StartWave();
                }
                )
            );
        }

        public override void Tick () {
            if ( Input.GetMouseButtonDown( 0 ) )
                OnLeftMouseClick.Invoke();
        }
    }
}