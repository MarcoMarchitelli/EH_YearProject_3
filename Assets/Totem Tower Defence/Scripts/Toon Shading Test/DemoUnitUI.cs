namespace ToonShadingDemo {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class DemoUnitUI : MonoBehaviour {
        [HideInInspector] public DemoUnit demoUnit;

        public void Rotate ( bool value ) {
            demoUnit.rotator.Active( value );
        }
    }
}