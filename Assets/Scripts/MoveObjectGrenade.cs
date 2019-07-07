using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObjectGrenade : MonoBehaviour
{
    public static float speed = 4f;

    void FixedUpdate()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -5.1)
        {
            Destroy(gameObject);
        }
    }
}