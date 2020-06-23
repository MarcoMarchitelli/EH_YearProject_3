namespace SweetRage {
    using UnityEngine;
    using UnityEngine.Events;
    using Deirin.Utilities;

    public class Game_Wave : Game_BaseState {
        [Header("Events")]
        public UnityEvent OnLeftMouseDown;
        public UnityEvent OnLeftMouseUp;

        [Header("Global Events")]
        public GameEvent OnEnemyReachedEnd;
        public GameEvent OnLevelEndClick;
        public GameEvent_Float OnEndGateLifeChange;

        public override void Enter () {
            base.Enter();

            //Local func
            void Rewind () {
                gameData.phaseUI.Rewind();
            }

            //wave phase graphics
            gameData.phaseUI.SetTexts( gameData.currentLevelObject.entity.CurrentWave.waveText );
            gameData.phaseUI.Play( .5f, Rewind );

            gameData.currentLevelObject.entity.CurrentWave.StartWave();

            gameData.currentLevelObject.entity.CurrentWave.OnWaveEnd.AddListener( WaveEndHandler );
            OnEnemyReachedEnd.OnInvoke += LossHandler;
            OnLevelEndClick.OnInvoke += LevelEndClickHandler;
            OnEndGateLifeChange.OnInvoke += EndGateLifeChangeHandler;
        }

        public override void Tick () {
            if ( Input.GetMouseButtonDown( 0 ) )
                OnLeftMouseDown.Invoke();
            else if ( Input.GetMouseButtonUp( 0 ) )
                OnLeftMouseUp.Invoke();
        }

        private void EndGateLifeChangeHandler ( float percent ) => gameData.currentLevelObject.entity.SetCurrentScore( percent );

        private void LevelEndClickHandler () => gameData.GoToMainMenu();

        public void LossHandler () => gameData.GoLoss();

        private void WaveEndHandler ( int id ) {
            gameData.currentLevelObject.entity.CurrentWave.gameObject.SetActive( false );
            gameData.GoNext();
        }

        public override void Exit () {
            base.Exit();

            gameData.currentLevelObject.entity.CurrentWave.OnWaveEnd.RemoveListener( WaveEndHandler );
            OnEnemyReachedEnd.OnInvoke -= LossHandler;
            OnLevelEndClick.OnInvoke -= LevelEndClickHandler;
        }
    }
}