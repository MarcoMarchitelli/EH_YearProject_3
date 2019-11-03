namespace TotemTD {
    using System.Collections.Generic;
    using UnityEngine;

    [CreateAssetMenu]
    public class WaveData : ScriptableObject {
        public float placeTime;
        public float spawnInterval;
        public List<EnemyData> enemies;
        public List<TurretBaseData> turretBases;
        public List<TurretModData> turretMods;

        public System.Action OnChanged;

        public void Add ( GameElement ge ) {
            if ( ge is TurretBaseData ) {
                turretBases.Add( ge as TurretBaseData );
                OnChanged?.Invoke();
            }
            else if ( ge is TurretModData ) {
                turretMods.Add( ge as TurretModData );
                OnChanged?.Invoke();
            }
            else
            if ( ge is EnemyData ) {
                enemies.Add( ge as EnemyData );
                OnChanged?.Invoke();
            }
        }

        public void Remove ( GameElement ge ) {
            if ( ge is TurretBaseData ) {
                if ( !turretBases.Contains( ge as TurretBaseData ) )
                    return;
                turretBases.Remove( ge as TurretBaseData );
                OnChanged?.Invoke();
            }
            else if ( ge is TurretModData ) {
                if ( !turretMods.Contains( ge as TurretModData ) )
                    return;
                turretMods.Remove( ge as TurretModData );
                OnChanged?.Invoke();
            }
            else
            if ( ge is EnemyData ) {
                if ( !enemies.Contains( ge as EnemyData ) )
                    return;
                enemies.Remove( ge as EnemyData );
                OnChanged?.Invoke();
            }
        }
    }
}