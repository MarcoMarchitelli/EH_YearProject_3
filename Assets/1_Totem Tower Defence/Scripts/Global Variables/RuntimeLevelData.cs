namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    /// <summary>
    /// Static class that contains all the runtime global data needed in a level.
    /// </summary>
    public static class RuntimeLevelData {
        /// <summary>
        /// Instances of Turret Modules that the player has (placed or in menu).
        /// </summary>
        public static List<TurretModule> turretModules;
    }
}