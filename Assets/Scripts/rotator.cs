using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    public float speed = 100f;
    public bool changeDirection;
    private void Update()
    {
        transform.Rotate(0f, 0f, speed * Time.deltaTime);
    }
}
