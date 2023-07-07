using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TriggerOnLand : MonoBehaviour
{

    [SerializeField] private string sceneName;
    [SerializeField] private RawImage image;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            image.gameObject.SetActive(true);
            StartCoroutine(FadeImage(image,0f,1f,1f));
        }
    }


    private System.Collections.IEnumerator FadeImage(RawImage image,float startAlpha, float targetAlpha,float fadeDuration)
    {
        float elapsedTime = 0f;
        float currentAlpha;
        Color currentColor = image.color;
        Color targetColor = new Color(0f, 0f, 0f, targetAlpha);
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / fadeDuration;
            currentAlpha = Mathf.SmoothStep(startAlpha, targetAlpha, t);
            //currentAlpha = Mathf.Lerp(startAlpha, targetAlpha, t); //this is linear interpolation instead of smooth interp, this is more ugly for me
            image.color = new Color(0f, 0f, 0f, currentAlpha);
            yield return null;
        }
        currentAlpha = targetAlpha;
        SceneManager.LoadScene(sceneName);
    }



    private void OnDrawGizmos()
    {
        SphereCollider sc = GetComponent<SphereCollider>();
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, sc.radius);
    }
}
