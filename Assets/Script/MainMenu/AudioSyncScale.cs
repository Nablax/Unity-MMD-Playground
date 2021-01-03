using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSyncScale : AudioSyncer
{
	public Vector3 beatScale, restScale;

	private IEnumerator MoveToScale(Vector3 target)
	{
		Vector3 current = transform.localScale;
		Vector3 initial = current;
		float timer = 0;

		while (current != target)
		{
			current = Vector3.Lerp(initial, target, timer / timeToBeat);
			timer += Time.deltaTime;

			transform.localScale = current;

			yield return null;
		}

		isBeat = false;
	}

	public override void onUpdate()
	{
		base.onUpdate();

		if (isBeat) return;

		transform.localScale = Vector3.Lerp(transform.localScale, restScale, restSmoothTime * Time.deltaTime);
	}

	public override void onBeat()
	{
		base.onBeat();

		StopCoroutine("MoveToScale");
		StartCoroutine("MoveToScale", beatScale);
	}
}