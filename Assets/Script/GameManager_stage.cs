using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager_stage : MonoBehaviour
{
    public static GameManager_stage instance;
    public static int noteLimit = 10;
    public static int currentNoteCount = 0;

    public int NL = noteLimit, CNC = currentNoteCount;

    public TextMeshProUGUI tmp;

    private int score;
    private int scorePerNote = 100;
    private int multiplier = 1;
    //private int penaltyMultiplier = 0;
    public int totalNotes = 0, hitNotes = 0;
    public double accuracy = 0.0;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        tmp = tmp.GetComponent<TextMeshProUGUI>();
        tmp.SetText("00000");

        totalNotes = 0;
        hitNotes = 0;

        NL = noteLimit;
        CNC = currentNoteCount;
    }

    // Update is called once per frame
    void Update()
    {
        tmp.SetText(score.ToString());

        if (totalNotes > 0)
            accuracy = ((double)hitNotes / (double)totalNotes) * 100.0;
    }

    public void noteHit()
    {
        Debug.Log("Hit Note");
        tmp.SetText(score.ToString() + " +" + scorePerNote + "x" + multiplier);

        totalNotes++;
        hitNotes++;
        

        score += scorePerNote * (++multiplier);
    }

    public void noteMissed()
    {
        Debug.Log("Missed Note");

        totalNotes++;

        score -= (scorePerNote / 10);
        multiplier = 1;
    }

    public int getScore()
    {
        return score;
    }
}
