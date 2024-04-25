using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class masterScore : MonoBehaviour
{

    private float _currentPos;

    private float _newPos;

    public float speed = 10;

    public GameObject performanceMeter;

    public float masterScoreFloat;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(randomPos), 2f,5f);
    }

    // Update is called once per frame
    void Update()
    {
        
        _currentPos = Mathf.Lerp(_currentPos, _newPos, speed*Time.deltaTime);
        performanceMeter.transform.localPosition = new Vector3(performanceMeter.transform.localPosition.x, _currentPos, performanceMeter.transform.localPosition.z);
        masterScoreFloat = performanceMeter.transform.localPosition.y;
        
    }
    
    
    void randomPos()
    {
        _newPos = (Random.Range(0, 11) / 10f)-0.5f;
    }
}
