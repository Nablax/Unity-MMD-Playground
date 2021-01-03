using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AgentControl : MonoBehaviour
{
    // Start is called before the first frame update
    private int mood;
    private GameManager_stage gameManager;
    private Animator agentMood;
    private int curScore;
    void Start()
    {
        agentMood = GetComponent<Animator>();
        agentMood.Play("Idle");
        gameManager = GameObject.FindWithTag("Gamescore").GetComponent<GameManager_stage>();
    }

    void FixedUpdate() {
        curScore = gameManager.getScore();
        if(curScore == 0){
            agentMood.Play("Idle");
        }
        else if(curScore < 0){
            agentMood.Play("Happy0");
        }
        else{
            int curState = (curScore / 2000) + 1;
            if(curState > 5) curState = 5;
            agentMood.Play("Happy" + curState.ToString());
        }
    }
}
