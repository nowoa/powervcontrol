using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PowerSlider : MonoBehaviour
{

    public PowerCalculator playerLeft;

    public PowerCalculator playerRight;

    public Transform sliderLeft;
    public Transform sliderRight;
    public GameObject powerMeter;
    [FormerlySerializedAs("_sliderLeftPos")] public float sliderLeftPos;
    [FormerlySerializedAs("_sliderRightPos")] public float sliderRightPos;
    [FormerlySerializedAs("_powerLeft")] public float powerLeft;
    [FormerlySerializedAs("_powerRight")] public float powerRight;

    [FormerlySerializedAs("_powerRatio")] public float powerRatio;
    // Start is called before the first frame update
    void Start()
    {
        sliderLeftPos = sliderLeft.position.x;
        sliderRightPos = sliderRight.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        
        powerLeft = playerLeft.powerScore;
        powerRight = playerRight.powerScore;
        UpdateScore();
    }
    
    
    void UpdateScore()
    {
        powerRatio = powerLeft / (powerLeft + powerRight);
        var position = Mathf.Lerp(sliderLeftPos, sliderRightPos, powerRatio);

        powerMeter.transform.position = new Vector3(position,powerMeter.transform.position.y, powerMeter.transform.position.z);
        
        Debug.Log(powerRatio);

    }
}

