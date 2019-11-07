namespace TotemTD {
    using UnityEngine;
    using UnityEngine.Events;

    public class WaveDataBuildUI : MonoBehaviour {
        [Header("Data")]
        public WaveData waveData;
        [Header("Prefabs")]
        public TurretBaseBuildUI turretBaseUIPrefab;
        public TurretModBuildUI turretModUIPrefab;
        public EnemyBuildUI enemyUIPrefab;
        [Header("Refs")]
        public Transform turretBasesContainer;
        public Transform turretModsContainer;
        public Transform enemiesContainer;
        [Header("Events")]
        public UnityWaveBuildUIEvent OnItemClick;

        private void Start () {
            if ( waveData )
                SetData( waveData );
        }

        public void SetData ( WaveData waveData ) {
            this.waveData = waveData;
            this.waveData.OnChanged += Refresh;
            Refresh();
        }

        private void OnDisable () {
            this.waveData.OnChanged -= Refresh;
        }

        public void Refresh () {
            CleanChildren( turretBasesContainer );
            CleanChildren( turretModsContainer );
            CleanChildren( enemiesContainer );
            foreach ( var item in waveData.turretBases ) {
                TurretBaseBuildUI tbUI = Instantiate(turretBaseUIPrefab, turretBasesContainer);
                tbUI.SetData( item );
                tbUI.OnClick += OnItemClick.Invoke;
            }
            foreach ( var item in waveData.turretMods ) {
                TurretModBuildUI tmUI = Instantiate(turretModUIPrefab, turretModsContainer);
                tmUI.SetData( item );
                tmUI.OnClick += OnItemClick.Invoke;
            }
            foreach ( var item in waveData.enemies ) {
                EnemyBuildUI eUI = Instantiate(enemyUIPrefab, enemiesContainer);
                eUI.SetData( item );
                eUI.OnClick += OnItemClick.Invoke;
            }
        }

        public void Remove ( WaveBuildUI item ) {
            waveData.Remove( item.data );
        }

        public void Add ( WaveBuildUI item ) {
            waveData.Add( item.data );
        }

        void CleanChildren ( Transform t ) {
            if ( t == null )
                return;
            int c = t.childCount;
            if ( c > 0 )
                for ( int i = 0; i < c; i++ ) {
                    Destroy( t.GetChild( i ).gameObject );
                }
        }
    }

    [System.Serializable]
    public class UnityWaveBuildUIEvent : UnityEvent<WaveBuildUI> { }
}