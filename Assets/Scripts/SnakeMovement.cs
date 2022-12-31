using UnityEngine;
using System.Collections.Generic;

public class SnakeMovement : MonoBehaviour
{
    public float ForwardSpeed;
    public float Sensetivity;

    private Rigidbody _snakeRigidbody;

    private Vector3 _lastPosition;
    private float _speed;

    public LevelNumber LevelNumber;
    private int _levelTarget;

    AudioManager audioManager;

    //private GameManager _gameManager;

    void Start()
    {
        _snakeRigidbody = GetComponent<Rigidbody>();

        audioManager = FindObjectOfType<AudioManager>();
        
        _levelTarget = 1;
        LevelNumber = FindObjectOfType<LevelNumber>();
    }

    private void FixedUpdate()
    {
        _snakeRigidbody.velocity = new Vector3(ForwardSpeed, 0, -_speed);

        _speed = 0;

        SnakeMove();
        AddSpeed();
    }

    private void SnakeMove()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _speed = 0;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 delta = Input.mousePosition - _lastPosition;
            _speed += delta.x * Sensetivity;
            _lastPosition = Input.mousePosition;
        }
    }

    private void AddSpeed()
    {
        if (LevelNumber.GetComponent<LevelNumber>().level == _levelTarget)
        {
            ForwardSpeed += 1f;
            _levelTarget += 1;
            Debug.Log(ForwardSpeed);
        }
    }
}
