using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSpectrum : MonoBehaviour
{
    public static float spectrumValue { get; private set; }

    // unity'll automatically populate this array
    private float[] audioSpectrum;

    private void Update()
    {
        AudioListener.GetSpectrumData(audioSpectrum, 0, FFTWindow.Hamming);

        if (audioSpectrum != null && audioSpectrum.Length > 0)
        {
            spectrumValue = audioSpectrum[0] * 100;
        }
    }

    private void Start()
    {
        // beat buffer
        audioSpectrum = new float[128];
    }
}