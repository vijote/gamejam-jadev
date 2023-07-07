using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public static ProgressBar instance;

    private Slider slider;

    public TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        instance = this;
        textMeshPro = GetComponentInChildren<TextMeshProUGUI>(true);//includeInactive=true
        textMeshPro.gameObject.SetActive(false);
    }
    public void SetProgress(int newProgress) {
        slider.value = newProgress;
    }

    public void SetMaxProgress(int newMaxProgress)
    {
        slider.maxValue = newMaxProgress;
    }
}
