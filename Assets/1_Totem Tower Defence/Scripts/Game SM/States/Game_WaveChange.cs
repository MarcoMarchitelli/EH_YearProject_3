namespace SweetRage {
    using UnityEngine;
    using UnityEngine.Events;

    public class Game_WaveChange : Game_BaseState {
        [Header("Events")]
        public UnityEvent OnLeftMouseDown;
        public UnityEvent OnLeftMouseUp;

        public override void Enter () {
            base.Enter();

            if ( gameData.levelTD.GoToNextWave() )
                gameData.GoNext();
            else
                gameData.GoWin();
        }

        public override void Tick () {
            if ( Input.GetMouseButtonDown( 0 ) )
                OnLeftMouseDown.Invoke();
            else if ( Input.GetMouseButtonUp( 0 ) )
                OnLeftMouseUp.Invoke();
        }
    }
}