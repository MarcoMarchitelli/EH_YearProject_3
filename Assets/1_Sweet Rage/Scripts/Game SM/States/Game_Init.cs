namespace SweetRage {
    using UnityEngine;
    using DG.Tweening;

    public class Game_Init : Game_BaseState {
        public override void Enter () {
            base.Enter();

            DOTween.SetTweensCapacity( 500, 50 );

            //load levels from resources
            GameObject[] loadedLevelObjects = Resources.LoadAll<GameObject>( "Levels/" );

            int count = loadedLevelObjects.Length;
            gameData.levelObjects = new LevelObject[count];
            for ( int i = 0; i < count; i++ ) {
                LevelObject lo = new LevelObject();
                lo.prefab = Instantiate( loadedLevelObjects[i], gameData.levelContainer ) ;
                lo.entity = lo.prefab.GetComponentInChildren<LevelEntity>();
                gameData.levelObjects[i] = lo;
            }

            gameData.saveData = ( SaveData ) SerializationManager.Load( SerializationManager.saveFolderPath + "/save.save" );
            //if we got a save file we load level states.
            if ( gameData.saveData != null ) {
                for ( int i = 0; i < gameData.levelObjects.Length; i++ ) {
                    gameData.levelObjects[i].entity.state = gameData.saveData.levelStates[i];
                }
            }

            DontDestroyOnLoad( gameData.animator.gameObject );

            //------ audio setup happens in scene ------
            //gameData.GoNext();
        }
    }
}