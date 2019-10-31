namespace TotemTD {
    using System.Collections.Generic;
    using UnityEngine;

    public class TurretMenu : MonoBehaviour {
        [Header("Refs")]
        public TurretUI turretUIPrefab;

        TurretData[] turrets;
        List<TurretUI> turretUIs = new List<TurretUI>();

        public void SetTurretsData ( TurretData[] turrets ) {
            this.turrets = turrets;
            UpdateUI();
        }

        public void UpdateUI () {
            int dataLength = turrets.Length;
            int uiLegth = turretUIs.Count;
            int loops = dataLength > uiLegth ? dataLength : uiLegth;
            for ( int i = 0; i < loops; i++ ) {
                TurretData data = i <= dataLength-1 ? turrets[i] : null;
                TurretUI ui = i <= uiLegth-1 ? turretUIs[i] : null;
                if ( data && !ui ) {
                    TurretUI t = Instantiate(turretUIPrefab, transform);
                    t.turretData = data;
                    turretUIs.Add( t );
                }
                else if ( ui && !data ) {
                    Destroy( ui.gameObject );
                }
                else {
                    ui.turretData = data;
                }
            }
        }
    }
}