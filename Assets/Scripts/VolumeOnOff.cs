using UnityEngine;
using UnityEngine.UI;

public class VolumeOnOff : MonoBehaviour
{
    [SerializeField] private Image image;

    [SerializeField] private Sprite offSprite;

    [SerializeField] private Sprite onSprite;

    private bool isVolumeOn = true;

    public void VolumeOffOn() 
    {
        if (isVolumeOn) 
        {
            AudioListener.volume = 0;
            image.overrideSprite = offSprite;
            isVolumeOn = false;
        }

        else 
        {
            AudioListener.volume = 1;
            image.overrideSprite = onSprite;
            isVolumeOn = true;
        }
    }
}
