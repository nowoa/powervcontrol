using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreCalculator : MonoBehaviour
{


    private readonly Queue<int> _scoreValues = new Queue<int>();
    public int valueAmount = 5;
    public GameObject performanceMeter;
    public float currentPos;
    private float _targetPos;
    public float speed = 10;
    private float _speed;
    private int[] _scoreArray;
    private double _averageScore;
    private float _averageFloat;
    public Transform sliderTop;
    public Transform sliderBottom;
    private float _sliderValue;

    public Transform startingPos;
    /*
    public float minSpeed;
    public float maxSpeed;*/
    
    [FormerlySerializedAs("_lastValue")] [HideInInspector] public int lastValue;
    // Start is called before the first frame update
    void Start()
    {
        ScoreUpdate();
        _speed = 1 / speed;
        _targetPos = 0.5f;
        _sliderValue = -0.5f;
        currentPos = -0.5f;



    }

    // Update is called once per frame
    void Update()
    {
        _targetPos = _averageFloat / 2 + 0.5f;

        /*
        float absAverage = Mathf.Abs(_averageFloat);
        speed = Mathf.Lerp(minSpeed, maxSpeed, absAverage);*/
        /*
        _currentPos = performanceMeter.transform.position.y+1;*/
        /*_targetPos = (_averageFloat)+1;*/
        currentPos = Mathf.Lerp(currentPos, _sliderValue, speed*Time.deltaTime);
        var position = performanceMeter.transform.position;
        position = new Vector3(position.x, currentPos, position.z);
        performanceMeter.transform.position = position;

        /*Debug.Log(_targetPos + " " + _currentPos + " " + performanceMeter.transform.position.y);*/
    }

    public void ScoreUpdate()
    {
        if (_scoreValues.Count < valueAmount)
        {
            _scoreValues.Enqueue(lastValue);
        }
        else
        {
            _scoreValues.Dequeue();
            _scoreValues.Enqueue(lastValue);
        }

        _scoreArray = _scoreValues.ToArray();
        _averageScore = _scoreArray.Average();
        _averageFloat = (float)_averageScore;
        /*Debug.Log(_averageFloat);*/
        
        var t = _averageFloat / 2 + 0.5f;
        if (t <= -1)
        {
            t = -1;
        }

        _sliderValue = Mathf.Lerp(sliderBottom.position.y, sliderTop.position.y, t);


    }
}
