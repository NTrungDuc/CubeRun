using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform Cube;
    [SerializeField] private Vector3 offset;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.position = Cube.position + offset;
    }
}
