using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using Random = UnityEngine.Random;

public class RuleManager : MonoBehaviour
{
    [HideInInspector] public float idealRange;
    private int _random;

    private masterScore _masterScore;

    private PowerCalculator _powerCalculator;
    // Start is called before the first frame update
    void Start()
    {
        _powerCalculator = FindObjectOfType<PowerCalculator>();
        _masterScore = FindObjectOfType<masterScore>();
    }

    private void OnEnable()
    {
        InvokeRepeating(nameof(setRule), 0,15f);
    }

    // Update is called once per frame
    void Update()
    {
        updateIdealRange();
    }
    
    void setRule()
    {
        _random = Random.Range(1, 3);

        
        
    }
    
    void updateIdealRange()
    {
        switch (_random)
        {
            case 1:
                idealRange = _masterScore.masterScoreFloat;
                _powerCalculator.topBuffer = 0f;
                _powerCalculator.bottomBuffer = 0.2f;
                //never outshine the master
                break;
            case 2:
                idealRange = 0f;
                _powerCalculator.topBuffer = 0.1f;
                _powerCalculator.bottomBuffer = 0.1f;
                //crush your enemy totally
                break;
            case 3:
                idealRange = 0.3f;
                // play a sucker to catch a sucker
                break;
            case 4:
                idealRange = 0.4f;
                // make your accomplishments seem effortless
                break;
            case 5:
                idealRange = 0.5f;
                // master the art of timing
                break;
            case 6:
                idealRange = 0.6f;
                // disarm and infuriate with the mirror effect
                break;
            case 7:
                idealRange = 0.7f;
                // never appear too perfect
                break;
            case 8:
                idealRange = 0.8f;
                // don't go past the mark you aimed for in victory, learn when to stop
                break;
            default:
                //no rule
                break;
                
        }/*
        Debug.Log(idealRange);*/

    }
}
