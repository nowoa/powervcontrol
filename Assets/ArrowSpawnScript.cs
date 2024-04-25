
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ArrowSpawnScript : MonoBehaviour
{

    public Transform[] spawnPos;
    public GameObject arrow;
    public float screenHeight = 40;
    private float _rotation;
    private float _bpm;
    public float bpm;
    /*private float _time;*/

    public float interval;
    // Start is called before the first frame update
    private void Start()
    {
        _bpm = 60 / bpm;
        InvokeRepeating(nameof(SpawnArrow), 0, _bpm);
    }

    // Update is called once per frame
    void Update()
    {


    }

    /*
    private void FixedUpdate()
    {
        if (_time < interval)
        {
            _time += Time.fixedDeltaTime;
        }
        else
        {
            SpawnArrow();
            _time = 0;
        }
        Debug.Log(_time);
    }*/

    private void SpawnArrow()
    {
        
        int randomNumber = Random.Range(0, 4);
        switch (randomNumber)
        {
            case 0:
                _rotation = 180;
                break;
            case 1:
                _rotation = 270;
                break;
            case 2:
                _rotation = 90;
                break;
            case 3:
                _rotation = 0;
                break;
            default:
                break;
        }

        
        
        //var rotationQuaternion = quaternion.Euler(0,0,rotation);
        
        Instantiate(arrow, spawnPos[randomNumber].position, Quaternion.Euler(0,0,_rotation));
        
    }
}
