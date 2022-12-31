using UnityEngine;
using TMPro;

public class Point : MonoBehaviour
{
    [SerializeField] private TMP_Text _pointText;
    public int point;

    private void Start()
    {
        point = 0;
    }

    public void AddPoint()
    {
        point++;
        _pointText.text = point.ToString();
    }

    public void RemovePoint()
    {
        point--;
        _pointText.text = point.ToString();      
    }
}
