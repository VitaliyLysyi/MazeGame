using System;

[Serializable]
public class SettingsData
{
    public float musicVolume;
    public float soundVolume;
    public bool vibration;

    public SettingsData()
    {
        musicVolume = 1f;
        soundVolume = 1f;
        vibration = true;
    }
}
