using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Deirin.Utilities;
using System.Collections;

public class LifebarUI : MonoBehaviour {
    [Header("Reference")]
    public Image image;

    [Header("Parameters")]
    public Color colorA, colorB, colorC;
    public float lerpSpeed;

    public void Lerp ( float t ) {
        t = Mathf.Clamp01( t );
        image.DOFillAmount( t, lerpSpeed ).SetEase( Ease.Linear ).Play();

        Color targetColor;

        if ( t > .4f )
            targetColor = t.Remap( 0.6f, 0.7f, colorB, colorA );
        else
            targetColor = t.Remap( 0.3f, 0.4f, colorC, colorB );

        image.DOColor( targetColor, lerpSpeed ).SetEase( Ease.Linear ).Play();
    }

    public void AnimLerpTo1 ( float speed ) {
        StartCoroutine( LerpAnim( 1, speed ) );
    }

    private IEnumerator LerpAnim ( float targetPercent, float duration ) {
        float percent = 0;
        float speed = 1f/duration;

        targetPercent = Mathf.Clamp01( targetPercent );

        while ( percent <= targetPercent ) {
            image.fillAmount = percent;

            if ( percent > .4f )
                image.color = percent.Remap( 0.6f, 0.7f, colorB, colorA );
            else
                image.color = percent.Remap( 0.3f, 0.4f, colorC, colorB );

            percent += Time.deltaTime * speed;

            yield return null;
        }
    }
}