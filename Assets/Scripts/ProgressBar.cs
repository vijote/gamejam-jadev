using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public static ProgressBar instance;

    private Slider slider;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        instance = this;
    }

    public void SetProgress(int newProgress) {
        slider.value = newProgress;
    }

    public void SetMaxProgress(int newMaxProgress)
    {
        slider.maxValue = newMaxProgress;
    }
}
