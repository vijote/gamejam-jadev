using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOutCanvas : MonoBehaviour
{
    private RawImage canvasImage;
    [SerializeField]
    private float fadeDuration = 1f;
    private void Start()
    {
        canvasImage = this.gameObject.GetComponent<RawImage>();
        StartCoroutine(SmoothFadeCanvas(1f, 0f));
    }

    private System.Collections.IEnumerator SmoothFadeCanvas(float startAlpha, float targetAlpha)
    {
        float elapsedTime = 0f;
        float currentAlpha;
        Color currentColor = canvasImage.color;
        Color targetColor = new Color(0f, 0f, 0f, targetAlpha);
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;
            currentAlpha = Mathf.SmoothStep(startAlpha, targetAlpha, t);
            //currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, t); //this is linear interpolation instead of smooth interp, this is more ugly for me
            canvasImage.color = new Color(0f, 0f, 0f, currentAlpha);
            yield return null;
        }
        currentAlpha = targetAlpha;
    }
}
