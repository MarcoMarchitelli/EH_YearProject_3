namespace TotemTD {
    using System.Collections.Generic;
    using UnityEngine;

    public class TurretMenu : MonoBehaviour {
        [Header("Refs")]
        public TurretUI turretUIPrefab;

        List<TurretBaseData> turrets;
        List<TurretUI> turretUIs = new List<TurretUI>();

        public void SetTurretsData ( List<TurretBaseData> turrets ) {
            this.turrets = turrets;
            UpdateUI();
        }

        public void UpdateUI () {
            int dataLength = turrets.Count;
            int uiLegth = turretUIs.Count;
            int loops = dataLength > uiLegth ? dataLength : uiLegth;
            for ( int i = 0; i < loops; i++ ) {
                TurretBaseData data = i <= dataLength-1 ? turrets[i] : null;
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

        public void Activate ( bool value ) {
            foreach ( var item in turretUIs ) {
                item.button.active = value;
            }
        }
    }
}