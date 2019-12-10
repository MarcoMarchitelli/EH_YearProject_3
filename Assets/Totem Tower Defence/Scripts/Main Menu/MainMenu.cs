using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {
    [Header("REFERENCES")]
    public Button[] buttons;
    public Transform pointer;

    [Header("PARAMETERS")]
    public int firstSelectedIndex = 0;
    public float pointerXOffset;

    private Button current;
    private int currentIndex;

    private void Start () {
        currentIndex = firstSelectedIndex;
        current = buttons[currentIndex];
    }

    public void DownHandler () {
        if ( currentIndex < buttons.Length - 1 ) {
            currentIndex++;
            Select( buttons[currentIndex] );
        }
    }

    public void UpHandler () {
        if ( currentIndex > 0 ) {
            currentIndex--;
            Select( buttons[currentIndex] );
        }
    }

    public void ClickHandler () {
        current.onClick.Invoke();
    }

    private void Select ( Button button ) {
        current = button;
        pointer.position = button.transform.position + Vector3.right * pointerXOffset;
    }
}