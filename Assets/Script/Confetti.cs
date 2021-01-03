using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Confetti : MonoBehaviour
{
    public ParticleSystem confetti;

    // Start is called before the first frame update
    void Start()
    {
        confetti = gameObject.GetComponent<ParticleSystem>() as ParticleSystem;
        confetti.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager_stage.instance.getScore() >= 4000)
        {
            confetti.Play();
        }
        else
        {
            confetti.Stop();
        }

    }
}
