namespace TotemTD {
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
            foreach ( var moduleGroup in waveData.moduleGroups ) {
                for ( int i = 0; i < moduleGroup.quantity; i++ ) {
                    TurretModule t = moduleGroup.module;
                    switch ( t.type ) {
                        case TurretModule.ModuleType.shooter:
                        TurretModuleBuildUI tUI = Instantiate(turretModuleUIPrefab, shootersContainer);
                        tUI.SetData( t );
                        break;
                        case TurretModule.ModuleType.element:
                        case TurretModule.ModuleType.modifier:
                        TurretModuleBuildUI tmUI = Instantiate(turretModuleUIPrefab, modsContainer);
                        tmUI.SetData( t );
                        break;
                    }
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
            foreach ( var moduleGroup in waveData.moduleGroups ) {
                TurretModule t = moduleGroup.module;
                if ( module == t ) {
                    moduleGroup.AddModule();
                }
            }
            //waveData.turretModules.Add( module );
            UpdateModulesUI();
        }

        public void AddEnemy ( Enemy enemy ) {
            waveData.enemies.Add( enemy );
            UpdateEnemiesUI();
        }

        public void RemoveModule ( TurretModule module ) {
            foreach ( var moduleGroup in waveData.moduleGroups ) {
                TurretModule t = moduleGroup.module;
                if ( module == t ) {
                    moduleGroup.RemoveModule();
                }
            }
            //waveData.turretModules.Remove( module );
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