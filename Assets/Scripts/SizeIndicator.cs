using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SizeIndicator : MonoBehaviour
{
    [SerializeField] private Sprite smallSizeIcon;
    [SerializeField] private Sprite mediumSizeIcon;
    [SerializeField] private Sprite largeSizeIcon;

    private static SizeIndicator instance;
    private Image imageComponent;

    public static void SetIndicator(Size size)
    {
        if(size == Size.Small)
        {
            instance.imageComponent.sprite = instance.smallSizeIcon;
            return;
        }

        if(size == Size.Medium)
        {
            instance.imageComponent.sprite = instance.mediumSizeIcon;
            return;
        }

        if(size == Size.Large)
        {
            instance.imageComponent.sprite = instance.largeSizeIcon;
            return;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        imageComponent = GetComponent<Image>();
    }
}
