using System.Collections.Generic;
using UnityEngine;

public class Tail : MonoBehaviour
{
    public Transform SnakeHead;
    public float TailDiametr;

    private List<Transform> _snakeTails = new();
    private List<Vector3> _positions = new();

    [SerializeField] private Point _point;

    public GameManager GameManager;

    [SerializeField] private ParticleSystem _sparks;


    void Start()
    {
        _positions.Add(SnakeHead.position);
    }

    void FixedUpdate()
    {
        TailPosition();
    }

    private void TailPosition()
    {
        float distance = ((Vector3)SnakeHead.position - _positions[0]).magnitude;

        if (distance > 0.7)
        {
            Vector3 direction = ((Vector3)SnakeHead.position - _positions[0]).normalized;

            _positions.Insert(0, _positions[0] + direction * TailDiametr);
            _positions.RemoveAt(_positions.Count - 1);

            distance -= TailDiametr;
        }

        for (int i = 0; i < _snakeTails.Count; i++)
        {
            _snakeTails[i].position = Vector3.Lerp(_positions[i + 1], _positions[i], distance / TailDiametr);
        }
    }

    public void AddTails()
    {
        Transform tail = Instantiate(SnakeHead, _positions[_positions.Count - 1], Quaternion.identity, transform);
        _snakeTails.Add(tail);
        _positions.Add(tail.position);
        _point.AddPoint();
    }

    public void RemoveTail()
    {
        if (_snakeTails.Count > 0)
        {
            Destroy(_snakeTails[0].gameObject);
            _snakeTails.RemoveAt(0);
            _positions.RemoveAt(1);
            _point.RemovePoint();
            _sparks.Play();
        }
        else
            GameManager.OnPlayerDied();        
    }
}
