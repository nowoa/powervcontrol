using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ArrowDetection : MonoBehaviour
{
    private bool _colliding;
    private GameObject _arrow;
    public int button;
    [HideInInspector]public bool correct;
    [HideInInspector]public bool wrong;

    public ScoreCalculator scoreCalculator;
    // Start is called before the first frame update
    void Start()
    {
        
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
        scoreCalculator.lastValue = 0;
        scoreCalculator.ScoreUpdate();
    }

    private void Update()
    {
        correct = wrong = false;
        if(Input.GetKeyDown(KeyCode.A) && button==1) PointAssignment();
        
        if(Input.GetKeyDown(KeyCode.S) && button==2) PointAssignment();
        
        if(Input.GetKeyDown(KeyCode.W) && button==3) PointAssignment();
        
        if(Input.GetKeyDown(KeyCode.D) && button==4) PointAssignment();
        
        if(Input.GetKeyDown(KeyCode.LeftArrow)&&button==5) PointAssignment();
        
        if(Input.GetKeyDown(KeyCode.DownArrow)&&button==6)PointAssignment();
        if(Input.GetKeyDown(KeyCode.UpArrow)&&button==7)PointAssignment();
        if(Input.GetKeyDown(KeyCode.RightArrow)&&button==8)PointAssignment();
        
        
    }
    
    void PointAssignment()
    {
        if (_colliding)
        {/*
            Debug.Log("correct");*/
            Destroy(_arrow);
            scoreCalculator.lastValue = 1;
            scoreCalculator.ScoreUpdate();
            _colliding = false;
            correct = true;
        }

        else
        {
            scoreCalculator.lastValue = -2;
            scoreCalculator.ScoreUpdate();
            /*Debug.Log("wrong");*/
            wrong = true;
        }
    }
    
}
