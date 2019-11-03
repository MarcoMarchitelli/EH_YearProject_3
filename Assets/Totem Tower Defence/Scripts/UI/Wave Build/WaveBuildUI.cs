namespace TotemTD {
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class WaveBuildUI : MonoBehaviour {
        public GameElement data;
        public System.Action<WaveBuildUI> OnClick;

        public void SetData ( GameElement data ) {
            this.data = data;
            CustomSetData();
        }

        protected virtual void CustomSetData () {

        }

        public virtual void Refresh () {

        }

        public virtual void Click () {
            OnClick?.Invoke( this );
        }
    }
}