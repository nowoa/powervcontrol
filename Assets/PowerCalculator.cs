using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class PowerCalculator : MonoBehaviour
{
    private RuleManager _ruleManager;

    public GameObject increase;

    public GameObject decrease;


    public Transform playerScore;

    public float topBuffer;

    public float bottomBuffer;
    // Start is called before the first frame update
    void Start()
    {
        _ruleManager = FindObjectOfType<RuleManager>();
        increase.SetActive(false);
        decrease.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScore.localPosition.y > _ruleManager.idealRange + topBuffer || playerScore.localPosition.y < _ruleManager.idealRange - bottomBuffer)
        {
            decrease.SetActive(true);
            increase.SetActive(false);
        }
        else
        {
            increase.SetActive(true);
            decrease.SetActive(false);
        }
        
    }
}
