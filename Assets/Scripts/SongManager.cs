using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SongManager : MonoBehaviour
{
    private AudioSource SongSource;
    public PublicVariables Variables;
    void Start()
    {
        SongSource = this.GetComponent<AudioSource>();
        SongSource.volume = Variables.GetMusicVolume();
    }
}
