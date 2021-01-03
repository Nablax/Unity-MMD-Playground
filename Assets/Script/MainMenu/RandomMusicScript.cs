using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class RandomMusicScript : MonoBehaviour
{
    public AudioClip[] audioList;
    // Start is called before the first frame update
    void Start()
    {
        System.Random rand = new System.Random();

        var audioComponent = gameObject.GetComponent<AudioSource>() as AudioSource;

        if (audioComponent != null)
        {
            audioComponent.clip = audioList[rand.Next(audioList.Length)];
            audioComponent.Play();
        }
        else
        {
            throw new NullReferenceException();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
