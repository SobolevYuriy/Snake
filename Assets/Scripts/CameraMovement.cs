using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject _snake;
    [SerializeField] private Vector3 _distanceFromObject;
    [SerializeField] private float _smoothing=1f;

    private float _speedSnake;

    private void Start()
    {
        _speedSnake = _snake.GetComponent<SnakeMovement>().ForwardSpeed;
    }

    private void FixedUpdate()
    {
        Vector3 positionToGo = _snake.transform.position + _distanceFromObject;
        Vector3 smoothPosition = Vector3.Lerp(transform.position,positionToGo,Time.fixedDeltaTime*_smoothing*_speedSnake);
        transform.position = smoothPosition;
    }
}
