using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBeatSyncScale : AudioSyncer
{
	public Vector3 beatScale, restScale;
	public Vector3 spawnLocation;


	void Start()
    {
		this.transform.GetComponent<NoteObject>().enabled = false;
    }

	private void cloneNote()
    {
		if (GameManager_stage.currentNoteCount < GameManager_stage.noteLimit)
        {
			var temp = GameObject.Instantiate(this, transform.parent, false);
			temp.transform.GetComponent<AudioBeatSyncScale>().enabled = false;
			temp.name = "clonedNote";

			//temp.transform.SetParent(this.transform, );

			temp.transform.GetComponent<NoteObject>().enabled = true;

			GameManager_stage.currentNoteCount++;
		}			
    }

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
		transform.GetComponent<AudioBeatSyncScale>().enabled = false;
		isBeat = false;
	}

	public override void onUpdate()
	{
		base.onUpdate();
		if (isBeat) return;

		//transform.localScale = Vector3.Lerp(transform.localScale, restScale, restSmoothTime * Time.deltaTime);
	}

	public override void onBeat()
	{
		base.onBeat();

		StopCoroutine("cloneNote");
		StartCoroutine("cloneNote");
	}
}