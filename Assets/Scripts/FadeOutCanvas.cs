using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutCanvas : MonoBehaviour
{
    private Image canvasImage;
    private float fadeDuration = 1f;
    private void Start()
    {
        canvasImage = this.gameObject.GetComponentInChildren<Image>();

        StartCoroutine(FadeCanvas(1f, 0f));
    }
    private System.Collections.IEnumerator FadeCanvas(float startAlpha, float targetAlpha)
        {
            float elapsedTime = 0f;
            float currentAlpha;
            Color currentColor = canvasImage.color;
            Color targetColor = new Color(0f, 0f, 0f, targetAlpha);
            while (elapsedTime < fadeDuration)
            {
                elapsedTime += Time.deltaTime;
                float t = elapsedTime / fadeDuration;
                currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, t);
                canvasImage.color = new Color(0f, 0f, 0f, currentAlpha);
                yield return null;
            }
            currentAlpha = targetAlpha;
        }

    }
