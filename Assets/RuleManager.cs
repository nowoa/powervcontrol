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

    [HideInInspector]public string ruleText;
    private int _random;

    public textDisplay textdisplay;
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
        _random = Random.Range(1,10 );

        
        
    }
    
    void UpdateIdealRange()
    {
        switch (_random)
        {
            case 1:
                idealRange = masterScore.masterScoreFloat;
                _top = 0f;
                _bottom = 0.2f;

                ruleText = @"
<b>NEVER OUTSHINE THE MASTER</b>
Make sure to stay below the master's performance level, but don't stray too far behind!
";
                textdisplay.UpdateText();
                //DONE
                break;
            case 2:
                idealRange = 0f;
                _top = 1f;
                _bottom = 1f;
                crushEnemy = true;
                
                ruleText = @"
<b>CRUSH YOUR ENEMY TOTALLY</b>
Every button you press decreases your opponents power, so let loose!
";
                textdisplay.UpdateText();
                //crush your enemy totally -> every input deducts x power from your opponent, keyboardsmash (player gains no points)
                break;
            case 3:
                idealRange = -0.5f;
                _top = 0.2f;
                _bottom = 0.2f;
                
                ruleText = @"
<b>PLAY A SUCKER TO CATCH A SUCKER</b>
Play dumb to win big, less is more when it comes to performance level.
";
                textdisplay.UpdateText();
                // DONE play a sucker to catch a sucker -> points are reversed (bad is good) 
                break;
            case 4:
                idealRange = 0f;
                _top = 1f;
                _bottom = 1f;
                easyArrows = true;
                
                
                ruleText = @"
<b>MAKE YOUR ACCOMPLISHMENTS SEEM EFFORTLESS</b>
Stay ahead of your opponent and also close your eyes lol
";
                textdisplay.UpdateText();
                // make your accomplishments seem effortless -> arrows are spawned only half as often
                break;
            case 5:
                idealRange = playerScore.sliderTop.position.y;
                _top = 1f;
                _bottom = 1f;
                perfectTiming = true;
                
                ruleText = @"
<b>MASTER THE ART OF TIMING</b>
I think this one is pretty obvious (play perfectly)
";
                textdisplay.UpdateText();
                // master the art of timing -> maybe it should deduct power for every wrong input
                break;
            case 6:
                idealRange = opponentScore.performanceMeter.transform.position.y +0.5f;
                _top = 0.1f;
                _bottom = 0.1f;
                
                ruleText = @"
<b>INFURIATE WITH THE MIRROR EFFECT</b>
Copy your opponents moves as closely as possible.
";
                textdisplay.UpdateText();
                // disarm and infuriate with the mirror effect
                break;
            case 7:
                idealRange = playerScore.sliderTop.position.y - 0.05f;
                _top = 0f;
                _bottom = 0.2f;
                
                ruleText = @"
<b>NEVER APPEAR TOO PERFECT</b>
Aim for near-perfection!
";
                textdisplay.UpdateText();
                // never appear too perfect
                break;
            case 8:
                idealRange = 0f;
                _top = 1f;
                _bottom = 1f;
                stopInput = true;
                
                ruleText = @"
<b>LEARN WHEN TO STOP</b>
...it's now.
";
                textdisplay.UpdateText();
                // don't go past the mark you aimed for in victory, learn when to stop -> any input during this rule lowers score, this rule should last less long? 
                break;
            case 9:
                randomArrows = true;
                
                ruleText = @"
<b>PLAN ALL THE WAY TO THE END</b>
I'm too tired to come up with flavortext, the arrows disappear lol
";
                textdisplay.UpdateText();
                // plan all the way to the end -> arrows have a random direction
                break;
            default:
                //no rule
                break;
                
        }
Debug.Log(idealRange);
    }

    
}
