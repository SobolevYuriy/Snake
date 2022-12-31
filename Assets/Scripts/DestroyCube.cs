using UnityEngine;
using TMPro;

public class DestroyCube : MonoBehaviour
{
    public int helthCube;
    [SerializeField] private TMP_Text _helthText1;
    [SerializeField] private TMP_Text _helthText2;

    private void Start()
    {
        helthCube = Random.Range(1, 6);
        _helthText1.text = helthCube.ToString();
        _helthText2.text = helthCube.ToString();  
    }

    private void OnCollisionEnter(Collision collision)
    {
        while (helthCube > 0)
        {
            if (collision.collider.CompareTag("Snake"))
            {
                helthCube--;
                collision.collider.GetComponent<Tail>().RemoveTail();
            }
        }
        Destroy(gameObject);
    }
}
