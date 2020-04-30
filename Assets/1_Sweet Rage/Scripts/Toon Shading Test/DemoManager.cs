namespace ToonShadingDemo {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using DG.Tweening;

    public class DemoManager : MonoBehaviour {
        [Header("Refs")]
        public DemoUnit[] units;
        public Transform selectedPosition;
        public Transform unitsContainer;

        [Header("Params")]
        public KeyCode[] upNavKeys;
        public KeyCode[] downNavKeys;
        public float distanceBetweenUnits;
        public float transitionDuration = 1f;
        public Ease transitionEase;

        private DemoUnit selected;
        private int selectedIndex = 0;
        private bool transitioning;

        #region Monos
        private void Awake () {
            selected = units[selectedIndex];
        }

        private void Update () {
            if ( transitioning == true )
                return;
            for ( int i = 0; i < upNavKeys.Length; i++ ) {
                if ( Input.GetKeyDown( upNavKeys[i] ) ) {
                    Select( 1 );
                    return;
                }
            }
            for ( int i = 0; i < downNavKeys.Length; i++ ) {
                if ( Input.GetKeyDown( downNavKeys[i] ) ) {
                    Select( -1 );
                    return;
                }
            }
        }
        #endregion

        #region Publics
        public void Select ( int xDir ) {
            if ( xDir > 0 )
                selectedIndex++;
            else if ( xDir < 0 )
                selectedIndex--;

            if ( selectedIndex < 0 ) {
                selectedIndex = 0;
                return;
            }
            else if ( selectedIndex > units.Length - 1 ) {
                selectedIndex = units.Length - 1;
                return;
            }

            selected.UI.gameObject.SetActive( false );
            selected = units[selectedIndex];
            selected.UI.gameObject.SetActive( true );

            transitioning = true;
            unitsContainer.DOKill();
            unitsContainer.DOLocalMoveY( unitsContainer.position.y + distanceBetweenUnits * -xDir, transitionDuration )
                .SetEase( transitionEase )
                .onComplete += () => transitioning = false;
        }
        #endregion
    }
}