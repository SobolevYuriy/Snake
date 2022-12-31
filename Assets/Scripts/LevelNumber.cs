using UnityEngine;
using TMPro;

public class LevelNumber : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelText;
    public int level;

    public Point Point;
    private int _target;

    [SerializeField] private ParticleSystem _confeti;

    void Start()
    {
        _target = 10;      
    }

    private void Update()
    {
        _levelText.text = "LVL: " + (level + 1).ToString();

        if (Point.GetComponent<Point>().point == _target)
        {
            level += 1;
            _confeti.Play();
            _target += 10;
        }
    }
}
