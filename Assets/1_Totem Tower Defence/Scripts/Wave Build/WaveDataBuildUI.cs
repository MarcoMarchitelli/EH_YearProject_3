namespace SweetRage {
    using UnityEngine;

    public class WaveDataBuildUI : MonoBehaviour {
        [Header( "Data" )]
        public WaveData waveData;

        [Header("Prefabs")]
        public TurretModuleBuildUI turretModuleUIPrefab;
        public EnemyBuildUI enemyUIPrefab;

        [Header("Refs")]
        public Transform shootersContainer;
        public Transform modsContainer;
        public Transform enemiesContainer;

        private void UpdateModulesUI () {
            //destroy
            int shooters = shootersContainer.childCount;
            for ( int i = 0; i < shooters; i++ ) {
                Destroy( shootersContainer.GetChild( i ).gameObject );
            }
            int mods = modsContainer.childCount;
            for ( int i = 0; i < mods; i++ ) {
                Destroy( modsContainer.GetChild( i ).gameObject );
            }

            //instantiate
            int modules = waveData.turretModules.Count;
            for ( int i = 0; i < modules; i++ ) {
                TurretModule t =  waveData.turretModules[i];
                switch ( t.turretType.moduleType ) {
                    case TurretType.ModuleType.shooter:
                    TurretModuleBuildUI tUI = Instantiate(turretModuleUIPrefab, shootersContainer);
                    tUI.SetData( t );
                    break;
                    case TurretType.ModuleType.element:
                    case TurretType.ModuleType.modifier:
                    TurretModuleBuildUI tmUI = Instantiate(turretModuleUIPrefab, modsContainer);
                    tmUI.SetData( t );
                    break;
                }
            }
        }

        private void UpdateEnemiesUI () {
            //destroy
            int enemies = enemiesContainer.childCount;
            for ( int i = 0; i < enemies; i++ ) {
                Destroy( enemiesContainer.GetChild( i ).gameObject );
            }

            //instantiate
            enemies = waveData.enemies.Count;
            for ( int i = 0; i < enemies; i++ ) {
                EnemyBuildUI eUI = Instantiate(enemyUIPrefab, enemiesContainer);
                eUI.SetData( waveData.enemies[i] );
            }
        }

        #region API
        public void AddModule ( TurretModule module ) {
            waveData.turretModules.Add( module );
            UpdateModulesUI();
        }

        public void AddEnemy ( Enemy enemy ) {
            waveData.enemies.Add( enemy );
            UpdateEnemiesUI();
        }

        public void RemoveModule ( TurretModule module ) {
            waveData.turretModules.Remove( module );
            UpdateModulesUI();
        }
        public void RemoveEnemy ( Enemy enemy ) {
            waveData.enemies.Remove( enemy );
            UpdateEnemiesUI();
        }

        public void UpdateUI () {
            UpdateModulesUI();
            UpdateEnemiesUI();
        } 
        #endregion
    }
}