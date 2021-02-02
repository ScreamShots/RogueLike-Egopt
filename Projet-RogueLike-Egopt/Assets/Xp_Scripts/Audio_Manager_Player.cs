using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class Audio_Manager_Player : MonoBehaviour
{
    public AudioClip[] playerAudioClip;
    public AudioSource audioSourcePlayer;

    // Start is called before the first frame update
    void Start()
    {
        audioSourcePlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
