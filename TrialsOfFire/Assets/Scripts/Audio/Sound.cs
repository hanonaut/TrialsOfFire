using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SoundType { SFX, Music }

[System.Serializable]
public class Sound
{
    public string soundName;
    public SoundType soundType;

    public AK.Wwise.Event soundEvent;

}
