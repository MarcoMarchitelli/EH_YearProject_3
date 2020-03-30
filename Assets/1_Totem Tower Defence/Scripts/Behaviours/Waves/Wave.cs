namespace SweetRage {
    using Deirin.EB;
    using UnityEngine;
    using System.Collections.Generic;
    using System.Linq;
    using Deirin.Utilities;

    [DisallowMultipleComponent]
    public class Wave : BaseBehaviour, IStoppable {
        [Min(1)] int index = 0;
        //public TurretModule

        [Header("Events"), Space]
        public UnityEvent_Int onPreWaveStart;
        public UnityEvent_Int onPreWaveEnd;
        public UnityEvent_Int onWaveStart;
        public UnityEvent_Int onWaveEnd;

        //Property
        public bool Stopped { get; private set; }
        public IStoppable[] StoppableItems { get; private set; }



        protected override void CustomSetup () {
            base.CustomSetup();

            List<IStoppable> tmpStoppableItems = GetComponentsInChildren<IStoppable>().ToList();
            tmpStoppableItems.Remove( this );
            StoppableItems = tmpStoppableItems.ToArray();
            Stopped = true;
        }

        public void StartPreWave () {
            onPreWaveStart?.Invoke( index );
        }

        public void EndPreWave () {
            onPreWaveStart?.Invoke( index );
        }


        public void StartWave () {
            if ( Stopped ) {
                Stopped = false;
                onWaveStart?.Invoke( index );
            }
        }

        public void Stop ( bool callEvent = true ) {
            if ( !Stopped ) {
                Stopped = true;
                StopAllStoppableChilds();
                if ( callEvent )
                    onWaveEnd?.Invoke( index );
            }
        }

        private void StopAllStoppableChilds () {
            foreach ( var stoppableItem in StoppableItems ) {
                stoppableItem.Stop( false );
            }
        }

    }

}