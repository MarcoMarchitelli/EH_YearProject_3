namespace SweetRage {
    using UnityEngine;
    using UnityEngine.Events;

    public class Game_Wave : Game_BaseState {
        [Header("Events")]
        public UnityEvent OnLeftMouseDown;
        public UnityEvent OnLeftMouseUp;

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
            gameData.phaseUI.SetTexts( gameData.currentLevelEntity.CurrentWave.preWaveText );
            gameData.phaseUI.Play( .5f, Rewind );

            gameData.currentLevelEntity.CurrentWave.OnPreWaveEnd.AddListener( PreWaveEndHandler );
        }

        public override void Tick () {
            if ( Input.GetMouseButtonDown( 0 ) )
                OnLeftMouseDown.Invoke();
            else if ( Input.GetMouseButtonUp( 0 ) )
                OnLeftMouseUp.Invoke();
        }

        public override void Exit () {
            base.Exit();

            gameData.currentLevelEntity.CurrentWave.OnPreWaveEnd.RemoveListener( PreWaveEndHandler );
            gameData.currentLevelEntity.CurrentWave.OnWaveEnd.RemoveListener( WaveEndHandler );
        }

        public void LossHandler () {
            gameData.GoLoss();
        }

        private void PreWaveEndHandler ( int id ) {
            //Local func
            void Rewind () {
                gameData.phaseUI.Rewind();
            }

            //wave phase graphics
            gameData.phaseUI.SetTexts( gameData.currentLevelEntity.CurrentWave.waveText );
            gameData.phaseUI.Play( .5f, Rewind );

            gameData.currentLevelEntity.CurrentWave.OnWaveEnd.AddListener( WaveEndHandler );
        }

        private void WaveEndHandler ( int id ) {
            gameData.currentLevelEntity.CurrentWave.gameObject.SetActive( false );
            gameData.GoNext();
        }
    }
}