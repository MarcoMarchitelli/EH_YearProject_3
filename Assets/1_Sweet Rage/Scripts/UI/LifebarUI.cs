using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Deirin.Utilities;
using System.Collections;

public class LifebarUI : MonoBehaviour {
    [Header("Reference")]
    public Image image;

    [Header("Parameters")]
    public float lerpStartOffset = .1f;
    public Color colorA;
    [Range(0,1)] public float colorAPercent;
    public Color colorB;
    [Range(0,1)] public float colorBPercent;
    public Color colorC;
    [Range(0,1)] public float colorCPercent;
    public Color colorD;
    public float lerpSpeed;

    public void Lerp ( float t ) {
        t = Mathf.Clamp01( t );
        image.DOFillAmount( t, lerpSpeed ).SetEase( Ease.Linear ).Play();

        Color targetColor = Color.clear;

        if ( t > colorAPercent - lerpStartOffset )
            targetColor = t.Remap( colorAPercent - lerpStartOffset, colorAPercent, colorB, colorA );
        else 
        if ( t > colorBPercent )
            targetColor = t.Remap( colorBPercent, colorBPercent + lerpStartOffset, colorC, colorB );
        else
            targetColor = t.Remap( colorCPercent, colorCPercent + lerpStartOffset, colorD, colorC );

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