namespace TotemTD {
    using UnityEngine;
    using System.Collections.Generic;

    public class Bullet : MonoBehaviour {
        [Header("Data")]
        public BulletData data;

        [Header("Refs")]
        public Mover mover;
        public EnemyDamageDealer enemyDamageDealer;

        public List<TurretModData> turretMods = new List<TurretModData>();

        public void AddMod ( TurretModData mod ) {
            turretMods.Add( mod );
        }

        public void RemoveMod ( TurretModData mod ) {
            turretMods.Remove( mod );
        }

        public void Setup () {
            mover.speed = data.speed;
            enemyDamageDealer.damage = data.damage;
        }

        public void SetDebuffToEnemy ( Enemy enemy ) {
            enemy.SetMods( turretMods );
        }
    }
}