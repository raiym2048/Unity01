using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class insertion : MonoBehaviour
{
    public Vector2 positions;
    public float speed = 4;
    public void FixedUpdate()
    {
        float angle = transform.eulerAngles.z;
        transform.Rotate(0, 0, speed * 50f * Time.deltaTime);
    }
}
