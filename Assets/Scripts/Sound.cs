using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Min(0)]
    public float volume;

    public bool loop = false;

    [HideInInspector]
    public AudioSource source;
}
