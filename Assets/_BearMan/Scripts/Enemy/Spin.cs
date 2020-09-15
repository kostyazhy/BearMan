using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float speed = 3.0f;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }

    void Update() {
        _transform.Rotate(0, speed, 0, Space.World); 
     }
}
