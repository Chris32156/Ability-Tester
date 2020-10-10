using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] float minX; 
    [SerializeField] float maxX;
    [SerializeField] float minY;
    [SerializeField] float maxY;

    // Start is called before the first frame update
    void Start()
    {
        RandomizePosition();
    }

    public void RandomizePosition()
    {
        Vector3 newPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
        Debug.Log(newPos.x + " y" + newPos.y);
        transform.position = newPos;
    }
}
