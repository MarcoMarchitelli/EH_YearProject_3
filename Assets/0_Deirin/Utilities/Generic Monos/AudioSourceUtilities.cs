using UnityEngine;
using UnityEngine.Events;

public class AudioSourceUtilities : MonoBehaviour {
    public AudioSource audioSource;

    public UnityEvent OnPlayEnd;
    public UnityEvent OnPlay;

    private float duration;

    public void Awake () {
        duration = audioSource.clip.length;
    }

    public void Play () {
        audioSource.Play();
    }
}