using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;

public class ScoreCalculator : MonoBehaviour
{


    private Queue<int> _scoreValues = new Queue<int>();
    public int valueAmount = 5;
    public GameObject performanceMeter;
    private float _currentPos;
    private float _targetPos;
    public float speed = 10;
    private float _speed;
    private int[] _scoreArray;
    private double _averageScore;
    private float _averageFloat;
    public Transform sliderTop;
    public Transform sliderBottom;
    private float _sliderValue;
    
    [FormerlySerializedAs("_lastValue")] [HideInInspector] public int lastValue;
    // Start is called before the first frame update
    void Start()
    {
        _speed = 1 / speed;
    }

    // Update is called once per frame
    void Update()
    {
        _targetPos = _averageFloat / 2 + 0.5f;
        
        /*
        _currentPos = performanceMeter.transform.position.y+1;*/
        /*_targetPos = (_averageFloat)+1;*/
        _currentPos = Mathf.Lerp(_currentPos, _sliderValue, speed*Time.deltaTime);
        performanceMeter.transform.position = new Vector3(performanceMeter.transform.position.x, _currentPos, performanceMeter.transform.position.z);
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
        Debug.Log(_averageFloat);
        
        var t = _averageFloat / 2 + 0.5f;
        
        _sliderValue = Mathf.Lerp(sliderBottom.position.y, sliderTop.position.y, t);


    }
}
