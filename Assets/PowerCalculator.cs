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
            decrease.SetActive(true);
            increase.SetActive(false);
            powerScore -= ruleManager.loseRate;
        }
        else
        {
            increase.SetActive(true);
            decrease.SetActive(false);
            powerScore += ruleManager.gainRate;
        }

        /*Debug.Log(powerScore +" " + this.gameObject.name);*/
    }
}
