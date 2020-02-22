namespace TotemTD {
    using System.Collections.Generic;
    using UnityEngine;
    using Deirin.Utilities;

    [CreateAssetMenu]
    public class TurretModuleListVariable : ScriptableObject {
        [ReadOnly] public List<TurretModule> value;
    }
}