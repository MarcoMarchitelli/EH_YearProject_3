namespace TotemTD {
    using System.Collections.Generic;
    using UnityEngine;

    public class TurretMenu : MonoBehaviour {
        [Header("Refs")]
        public TurretUI turretUIPrefab;
        public TurretModUI turretModUIPrefab;

        List<TurretBaseData> turretBasesData;
        List<TurretModData> turretModsData;
        List<TurretUI> turretBaseUIs = new List<TurretUI>();
        List<TurretModUI> turretModUIs = new List<TurretModUI>();

        public void SetTurretsData ( List<TurretBaseData> turrets ) {
            this.turretBasesData = turrets;
            UpdateTurretBasesUI();
        }

        public void SetTurretModsData ( List<TurretModData> turretModsData ) {
            this.turretModsData = turretModsData;
            UpdateTurretModsUI();
        }

        public void UpdateUI () {
            UpdateTurretBasesUI();
            UpdateTurretModsUI();
        }

        public void Activate ( bool value ) {
            foreach ( var item in turretBaseUIs ) {
                item.button.active = value;
            }
            foreach ( var item in turretModUIs ) {
                item.button.active = value;
            }
        }

        private void UpdateTurretModsUI () {
            int dataLength = turretModsData.Count;
            int uiLegth = turretModUIs.Count;
            int loops = dataLength > uiLegth ? dataLength : uiLegth;
            for ( int i = 0; i < loops; i++ ) {
                TurretModData data = i <= dataLength-1 ? turretModsData[i] : null;
                TurretModUI ui = i <= uiLegth-1 ? turretModUIs[i] : null;
                if ( data && !ui ) {
                    TurretModUI t = Instantiate(turretModUIPrefab, transform);
                    t.turretModData = data;
                    turretModUIs.Add( t );
                }
                else if ( ui && !data ) {
                    Destroy( ui.gameObject );
                }
                else {
                    ui.turretModData = data;
                }
            }
        }

        private void UpdateTurretBasesUI () {
            int dataLength = turretBasesData.Count;
            int uiLegth = turretBaseUIs.Count;
            int loops = dataLength > uiLegth ? dataLength : uiLegth;
            for ( int i = 0; i < loops; i++ ) {
                TurretBaseData data = i <= dataLength-1 ? turretBasesData[i] : null;
                TurretUI ui = i <= uiLegth-1 ? turretBaseUIs[i] : null;
                if ( data && !ui ) {
                    TurretUI t = Instantiate(turretUIPrefab, transform);
                    t.turretData = data;
                    turretBaseUIs.Add( t );
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