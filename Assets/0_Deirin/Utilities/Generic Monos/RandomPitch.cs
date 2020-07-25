namespace Deirin.Utilities {
    using UnityEngine;

    public class RandomPitch : MonoBehaviour {
        public AudioSource audioSource;

        public float min, max;

        public void RandomizePitch () {
            audioSource.pitch = Random.Range( min, max );
        }

        public void PlayRandomized () {
            RandomizePitch();
            audioSource.Play();
        }
    }
}