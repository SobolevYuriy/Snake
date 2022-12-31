using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public RoadPrefs[] _roadsPrefs;

    public List<RoadPrefs> roadsSpawn = new List<RoadPrefs>();
    public Transform Snake;

    public RoadPrefs FirstRoad;

    void Start()
    {
        roadsSpawn.Add(FirstRoad);
    }

    private void Update()
    {
        if (Snake.position.x > roadsSpawn[roadsSpawn.Count - 1].End.position.x - 110)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        RoadPrefs _road = Instantiate(_roadsPrefs[Random.Range(0, _roadsPrefs.Length)]);
        _road.transform.position = roadsSpawn[roadsSpawn.Count - 1].End.position - _road.Beggin.localPosition;
        roadsSpawn.Add(_road);

        if (roadsSpawn.Count > 3)
        {
            Destroy(roadsSpawn[0].gameObject);
            roadsSpawn.RemoveAt(0);
        }
    }
}
