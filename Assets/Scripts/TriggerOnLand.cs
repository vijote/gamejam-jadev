using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerOnLand : MonoBehaviour
{

    private Canvas canvas;
    private Image canvasImage;
    private float fadeDuration = 1f;
    private void Start()
    {
        Canvas[] canvases = FindObjectsByType<Canvas>(FindObjectsSortMode.InstanceID);
        foreach (Canvas c in canvases)
        {
            if (c.gameObject.name == "Fade") canvas = c; break;

        }
        
        canvasImage = canvas.GetComponentInChildren<Image>();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(Player.instance.IsAbleToEvolve());
        }
        
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
        SceneManager.LoadScene("LizardLevel");
    }

    private void OnDrawGizmos()
    {
        SphereCollider sc = GetComponent<SphereCollider>();
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sc.radius);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
