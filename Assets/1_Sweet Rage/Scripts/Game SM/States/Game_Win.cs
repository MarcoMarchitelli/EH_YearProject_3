namespace SweetRage {
    using Deirin.Utilities;
    using System;
    using UnityEngine;

    public class Game_Win : Game_BaseState {
        [Header("Global Events")]
        public GameEvent OnLevelEndClick;

        public override void Enter () {
            base.Enter();

            //save locally the current level max score.
            gameData.currentLevelObject.entity.SaveMaxScore();

            //if we didn't load anything we create a save class.
            if ( gameData.saveData == null ) {
                gameData.saveData = new SaveData();
                gameData.saveData.levelStates = new LevelState[gameData.levelObjects.Length];
                for ( int i = 0; i < gameData.saveData.levelStates.Length; i++ ) {
                    gameData.saveData.levelStates[i] = gameData.levelObjects[i].entity.state;
                }
            }

            //save in class and then in file the current level state.
            int currentLevelIndex = Array.IndexOf( gameData.levelObjects, gameData.currentLevelObject );
            gameData.saveData.levelStates[currentLevelIndex] = gameData.currentLevelObject.entity.state;
            SerializationManager.Save( "save", gameData.saveData );

            OnLevelEndClick.OnInvoke += LevelEndClickHandler;
        }

        private void LevelEndClickHandler () {
            gameData.GoNext();
        }

        public override void Exit () {
            OnLevelEndClick.OnInvoke -= LevelEndClickHandler;
        }
    }
}