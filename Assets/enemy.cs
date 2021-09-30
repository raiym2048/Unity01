using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class enemy : MonoBehaviour
{
    public float speed = 0.04f;
    public Vector3[] positions;

    public int currentTarget;

    private void FixedUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, positions[currentTarget], speed);
        if(transform.position == positions[currentTarget])
        {
            if(currentTarget < positions.Length - 1)
            {
                currentTarget++;
            }
            else
            {
                currentTarget = 0;
            }
        }
    }

}
