using UnityEngine;
using System.Collections.Generic;

public static class AudioSettings 
{
    public static float Master = 1f;
    public static float SFX = 0.8f;
    public static float Music = 0.8f;

    static AudioSettings()
    {
        Music = 0.8f;
    }
}
