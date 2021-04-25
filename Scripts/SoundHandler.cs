using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundHandler : MonoBehaviour
{

    public AudioSource sound;
    public AudioClip[] clips;



    // Start is called before the first frame update
    void Start()
    {
        sound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void play_sound(int i)
    {
        sound.PlayOneShot(clips[i], 1f);
    }

   
}
