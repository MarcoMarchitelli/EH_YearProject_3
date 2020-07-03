using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using Deirin.Utilities;
using System.Collections;
using UnityEngine.Events;

public class LifebarUI : MonoBehaviour {
    [Header("Reference")]
    public Image image;
    public Image winImage;

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

    [Header("Events")]
    public UnityEvent OnStar1Reached;
    public UnityEvent OnStar2Reached;
    public UnityEvent OnStar3Reached;

    private bool star1Reached, star2Reached, star3Reached;

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

    public void AnimLerpTo1 ( float duration ) {
        StartCoroutine( LerpAnim( 1, duration ) );
    }

    public void PlayWinAnim ( float duration ) {
        StartCoroutine( WinAnim( image.fillAmount, duration ) );
    }

    private IEnumerator WinAnim ( float targetPercent, float duration ) {
        float percent = 0;
        float speed = 1f/duration;

        targetPercent = Mathf.Clamp01( targetPercent );

        while ( percent <= targetPercent ) {
            winImage.fillAmount = percent;

            if ( star1Reached == false && percent >= colorCPercent ) {
                OnStar1Reached.Invoke();
                star1Reached = true;
            }
            else if ( star2Reached == false && percent >= colorBPercent ) {
                OnStar2Reached.Invoke();
                star2Reached = true;
            }
            else if ( star3Reached == false && percent >= colorAPercent ) {
                OnStar3Reached.Invoke();
                star3Reached = true;
            }

            percent += Time.deltaTime * speed;
            percent = Mathf.Clamp( percent, 0, targetPercent );

            yield return null;
        }
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