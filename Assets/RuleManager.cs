using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using Random = UnityEngine.Random;

public class RuleManager : MonoBehaviour
{
    [HideInInspector] public float idealRange;
    public float gain;
    public float lose;
    [HideInInspector]public float gainRate;
    [HideInInspector]public float loseRate;
    private float _top;
    private float _bottom;
    
    
    private int _random;


    public PowerCalculator powerCalculator;

    public ScoreCalculator playerScore;
    public ScoreCalculator opponentScore;

    public masterScore masterScore;

    
    
    
//RULES
    [HideInInspector] public bool perfectTiming, crushEnemy, stopInput, easyArrows, randomArrows;
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _top = powerCalculator.topBuffer;
        _bottom = powerCalculator.bottomBuffer;

        gainRate=gain * Time.deltaTime;
        loseRate=lose * Time.deltaTime;
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(SetRule), 0,15f);
    }

    // Update is called once per frame
    private void Update()
    {
        UpdateIdealRange();
        powerCalculator.topBuffer = _top;
        powerCalculator.bottomBuffer = _bottom;
        
        
    }

    private void SetRule()
    {
        perfectTiming = crushEnemy = stopInput =easyArrows =randomArrows= false;
        _random = Random.Range(1, 3);

        
        
    }
    
    void UpdateIdealRange()
    {
        switch (_random)
        {
            case 1:
                idealRange = masterScore.masterScoreFloat;
                _top = 0f;
                _bottom = 0.2f;
                //never outshine the master
                break;
            case 2:
                idealRange = 0f;
                _top = 1f;
                _bottom = 1f;
                crushEnemy = true;
                //crush your enemy totally -> every input deducts x power from your opponent, keyboardsmash (player gains no points)
                break;
            case 3:
                idealRange = -0.5f;
                _top = 0.2f;
                _bottom = 0.2f;
                // play a sucker to catch a sucker -> points are reversed (bad is good)
                break;
            case 4:
                idealRange = 0f;
                _top = 1f;
                _bottom = 1f;
                easyArrows = true;
                // make your accomplishments seem effortless -> arrows are spawned only half as often
                break;
            case 5:
                idealRange = playerScore.sliderTop.position.y;
                _top = 1f;
                _bottom = 1f;
                perfectTiming = true;
                // master the art of timing -> maybe it should deduct power for every wrong input
                break;
            case 6:
                idealRange = opponentScore.currentPos;
                _top = 0.1f;
                _bottom = 0.1f;
                // disarm and infuriate with the mirror effect
                break;
            case 7:
                idealRange = playerScore.sliderTop.position.y - 0.05f;
                _top = 0f;
                _bottom = 0.2f;
                // never appear too perfect
                break;
            case 8:
                idealRange = 0f;
                _top = 1f;
                _bottom = 1f;
                stopInput = true;
                // don't go past the mark you aimed for in victory, learn when to stop -> any input during this rule lowers score, this rule should last less long? 
                break;
            case 9:
                randomArrows = true;
                // plan all the way to the end -> arrows have a random direction
                break;
            default:
                //no rule
                break;
                
        }/*
        Debug.Log(idealRange);*/

    }
}
