using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ArrowDetection : MonoBehaviour
{
    private bool _colliding;
    private GameObject _arrow;
    public int button;
    private ScoreCalculator _scoreCalculator;
    // Start is called before the first frame update
    void Start()
    {
        _scoreCalculator = FindObjectOfType<ScoreCalculator>();
    }

    // Update is called once per frame




    private void OnTriggerEnter(Collider other)
    {
        _arrow = other.gameObject;
            _colliding = true;

        
    }

    private void OnTriggerExit(Collider other)
    {
        _colliding = false;
        _scoreCalculator.lastValue = 0;
        _scoreCalculator.ScoreUpdate();
    }

    private void Update()
    {
        
        if(Input.GetKeyDown(KeyCode.LeftArrow) && button==1) PointAssignment();
        
        if(Input.GetKeyDown(KeyCode.DownArrow) && button==2) PointAssignment();
        
        if(Input.GetKeyDown(KeyCode.UpArrow) && button==3) PointAssignment();
        
        if(Input.GetKeyDown(KeyCode.RightArrow) && button==4) PointAssignment();
        
        
    }
    
    void PointAssignment()
    {
        if (_colliding)
        {/*
            Debug.Log("correct");*/
            Destroy(_arrow);
            _scoreCalculator.lastValue = 1;
            _scoreCalculator.ScoreUpdate();
            _colliding = false;
        }

        else
        {
            _scoreCalculator.lastValue = -2;
            _scoreCalculator.ScoreUpdate();
            /*Debug.Log("wrong");*/
        }
    }
    
}
