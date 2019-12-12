namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Deirin.EB;

    public class ShooterModule : TurretModule {
        private ShooterModuleData customData;

        [Header("References")]
        public Shooter shooter;
        public LookAt lookAt;

        protected override void CustomSetup () {
            customData = data as ShooterModuleData;
            shooter.fireRate = customData.fireRate;
            shooter.projectileData = customData.projectileData;
            lookAt.turnRate = customData.turnRate;
        }
    }
}