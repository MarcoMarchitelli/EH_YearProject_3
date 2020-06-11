namespace SweetRage {
    using UnityEngine;
    using DG.Tweening;

    public class Game_Init : Game_BaseState {
        public override void Enter () {
            base.Enter();

            DOTween.SetTweensCapacity( 500, 50 );

            //load levels
            GameObject[] levelContainers = Resources.LoadAll<GameObject>( "Levels/" );

            int count = levelContainers.Length;
            gameData.levelsEntities = new LevelEntity[count];
            for ( int i = 0; i < count; i++ ) {
                gameData.levelsEntities[i] = levelContainers[i].GetComponentInChildren<LevelEntity>();
            }

            //------ audio setup happens in scene ------
            gameData.GoNext();
        }
    }
}