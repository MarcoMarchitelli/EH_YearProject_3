namespace SweetRage {
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.Utilities;

    public class Game_PlacementTime : Game_BaseState {
        [Header("Events")]
        public UnityEvent OnLeftMouseDown;
        public UnityEvent OnLeftMouseUp;

        [Header("Global Events")]
        public GameEvent OnPlaceTimeSkipClick;
        public GameEvent OnLevelEndClick;

        private bool count;
        private float timer, duration;

        public override void Enter () {
            base.Enter();

            //turret menu setup and UI update
            gameData.modulesMenuUI.Setup();
            gameData.modulesMenuUI.UpdateUI();

            //Local func
            void Rewind () {
                gameData.phaseUI.Rewind();
            }

            //wave phase graphics
            gameData.phaseUI.SetTexts( gameData.currentLevel.CurrentWave.preWaveText );
            gameData.phaseUI.Play( .5f, Rewind );

            duration = gameData.currentLevel.CurrentWave.placementTime;
            timer = 0;
            count = true;

            OnPlaceTimeSkipClick.OnInvoke += SkipHandler;
            OnLevelEndClick.OnInvoke += LevelEndClickHandler;
        }

        public override void Tick () {
            if ( Input.GetMouseButtonDown( 0 ) )
                OnLeftMouseDown.Invoke();
            else if ( Input.GetMouseButtonUp( 0 ) )
                OnLeftMouseUp.Invoke();

            if ( count ) {
                timer += Time.deltaTime;
                gameData.placeTimeUI.SetPercent( timer / duration );
                if ( timer >= duration ) {
                    SkipHandler();
                }
            }
        }

        private void LevelEndClickHandler () => gameData.GoToMainMenu();

        private void SkipHandler () {
            gameData.placeTimeUI.SetPercent( 0 );
            gameData.GoNext();
        }

        public override void Exit () {
            base.Exit();

            OnPlaceTimeSkipClick.OnInvoke -= SkipHandler;
            OnLevelEndClick.OnInvoke -= LevelEndClickHandler;
        }
    }
}