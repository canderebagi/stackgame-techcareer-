using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{

    public int haptic1;
    public int haptic2;
    public int sound;

    public Toggle soundToggle;
    public Toggle hapticToggle;

    private void Start()
    {

        SoundData();
        HapticData();
    }

    public void SoundPause()
    {
        if (soundToggle.isOn)
        {
            sound = 1;
            AudioListener.volume = sound;
            PlayerPrefs.SetInt("Sound", sound);
        }
        else
        {
            sound = 0;
            AudioListener.volume = sound;
            PlayerPrefs.SetInt("Sound", sound);
        }
    }
    public void Haptic()
    {
        if (hapticToggle.isOn)
        {
            haptic1 = 50;
            haptic2 = 50;
            PlayerPrefs.SetInt("Haptic1", haptic1);
            PlayerPrefs.SetInt("Haptic2", haptic2);
        }

        else
        {
            haptic1 = 1;
            haptic2 = 0;
            PlayerPrefs.SetInt("Haptic1", haptic1);
            PlayerPrefs.SetInt("Haptic2", haptic2);
        }

    }
    public void SoundData()
    {
        if (PlayerPrefs.HasKey("Sound"))
        {
            sound = PlayerPrefs.GetInt("Sound");

        }
        else
        {
            PlayerPrefs.SetInt("Sound", 1);

        }
        if (sound == 1)
        {
            soundToggle.isOn = true;
        }
        if (sound == 0)
        {
            soundToggle.isOn = false;
        }
    }
    public void HapticData()
    {
        if (PlayerPrefs.HasKey("Haptic1"))
        {
            haptic1 = PlayerPrefs.GetInt("Haptic1");

        }
        else
        {
            PlayerPrefs.SetInt("Haptic1", 50);
        }

        if (PlayerPrefs.HasKey("Haptic2"))
        {
            haptic2 = PlayerPrefs.GetInt("Haptic2");

        }
        else
        {
            PlayerPrefs.SetInt("Haptic2", 50);
        }

        if (haptic1 == 50)
        {
            hapticToggle.isOn = true;
        }
        if (haptic1 == 1)
        {
            hapticToggle.isOn = false;
        }
    }
}
