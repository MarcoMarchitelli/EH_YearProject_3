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
            gameData.phaseUI.SetTexts( gameData.levelTD.CurrentWave.preWaveText );
            gameData.phaseUI.Play( .5f, Rewind );

            gameData.levelTD.CurrentWave.OnPreWaveEnd.AddListener( PreWaveEndHandler );
        }

        public override void Tick () {
            if ( Input.GetMouseButtonDown( 0 ) )
                OnLeftMouseDown.Invoke();
            else if ( Input.GetMouseButtonUp( 0 ) )
                OnLeftMouseUp.Invoke();
        }

        public override void Exit () {
            base.Exit();

            gameData.levelTD.CurrentWave.OnPreWaveEnd.RemoveListener( PreWaveEndHandler );
            gameData.levelTD.CurrentWave.OnWaveEnd.RemoveListener( WaveEndHandler );
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
            gameData.phaseUI.SetTexts( gameData.levelTD.CurrentWave.waveText );
            gameData.phaseUI.Play( .5f, Rewind );

            gameData.levelTD.CurrentWave.OnWaveEnd.AddListener( WaveEndHandler );
        }

        private void WaveEndHandler ( int id ) {
            gameData.levelTD.CurrentWave.gameObject.SetActive( false );
            gameData.GoNext();
        }
    }
}