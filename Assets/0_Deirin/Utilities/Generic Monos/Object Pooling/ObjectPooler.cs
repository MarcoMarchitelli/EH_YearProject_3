namespace Deirin.Utilities {
    using System.Collections;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using UnityEngine;

    public class ObjectPooler : MonoBehaviour {
        public static ObjectPooler instance;

        public ObjectToPool[] objectsToPool;

        private Pool[] pools;

        private void Awake () {
            if ( instance == null )
                instance = this;
        }

        public void CreatePools () {
            pools = new Pool[objectsToPool.Length];

            for ( int i = 0; i < objectsToPool.Length; i++ ) {
                GameObject container = new GameObject("Pool " + i.ToString());
                container.transform.SetParent( transform );

                Pool currentPool = pools[i];

                currentPool.ID = objectsToPool[i].ID;

                for ( int j = 0; j < objectsToPool[j].amount; j++ ) {
                    currentPool.queue.Enqueue( Instantiate( objectsToPool[j].poolable, container.transform ) );
                }
            }
        }

        public static Poolable GetFromPool ( int ID ) {
            foreach ( Pool pool in instance.pools ) {
                if ( pool.ID == ID ) {
                    return pool.queue.Dequeue();
                }
            }

            return null;
        }

        public static void PutInPool ( Poolable poolable, int ID ) {
            foreach ( Pool pool in instance.pools ) {
                if ( pool.ID == ID ) {
                    pool.queue.Enqueue( poolable );
                }
            }
        }
    }

    public class ObjectToPool {
        public int ID;
        public Poolable poolable;
        public int amount;
    }

    public class Pool {
        public int ID;
        public Queue<Poolable> queue;
    }
}