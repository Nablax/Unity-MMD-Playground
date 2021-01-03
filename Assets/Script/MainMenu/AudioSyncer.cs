using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncer : MonoBehaviour
{
	public float bias;
	public float timeStep;
	public float timeToBeat;
	public float restSmoothTime;

	private float previousAudioValue;
	private float audioValue;
	private float timer;

	protected bool isBeat;

	public virtual void onBeat()
	{
		timer = 0;
		isBeat = true;
	}

	public virtual void onUpdate()
	{
		// update audio value
		previousAudioValue = audioValue;
		audioValue = AudioSpectrum.spectrumValue;

		// if audio value went below the bias during this frame
		if (previousAudioValue > bias && audioValue <= bias)
		{
			// if minimum beat interval is reached
			if (timer > timeStep)
				onBeat();
		}

		// if audio value went above the bias during this frame
		if (previousAudioValue <= bias &&
			audioValue > bias)
		{
			// if minimum beat interval is reached
			if (timer > timeStep)
				onBeat();
		}

		timer += Time.deltaTime;
	}

	private void Update()
	{
		onUpdate();
	}

	
}