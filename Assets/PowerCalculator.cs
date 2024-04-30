using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PowerCalculator : MonoBehaviour
{
    

    public GameObject increase;

    public GameObject decrease;


    public Transform playerScore;

    public float topBuffer;

    public float bottomBuffer;

    public RuleManager ruleManager;

    public ScoreCalculator scoreCalculator;

    [HideInInspector]public float powerScore;
    // Start is called before the first frame update
    void Start()
    {
        powerScore = 50;
        increase.SetActive(false);
        decrease.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScore.localPosition.y > ruleManager.idealRange + topBuffer || playerScore.localPosition.y < ruleManager.idealRange - bottomBuffer)
        {
            if (!ruleManager.perfectTiming)
            {
                
                decrease.SetActive(true);
                increase.SetActive(false);
                
                powerScore -= ruleManager.loseRate;
            }
        }
        else
        {
            if(!ruleManager.perfectTiming)
            {
                
                increase.SetActive(true);
                decrease.SetActive(false);
                powerScore += ruleManager.gainRate;
            }
        }
        
        if (ruleManager.perfectTiming)
        {
            
            if (scoreCalculator.lastValue == 1)
            {
                powerScore += 1;
            }
            else if(scoreCalculator.lastValue == 0)
            {
                powerScore -= 1;
            }
            else if(scoreCalculator.lastValue==-2)
            {
                powerScore -= 2;
            }
        }

        /*Debug.Log(powerScore +" " + this.gameObject.name);*/
    }
}
