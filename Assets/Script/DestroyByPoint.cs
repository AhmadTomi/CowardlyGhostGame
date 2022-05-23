using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByPoint : MonoBehaviour
{
    Transform DestroyPoint;

    private void Start()
    {
        DestroyPoint = FindObjectOfType<PlayerController>().Destroypoint;
    }

    private void Update()
    {
        if (DestroyPoint.position.z > transform.position.z)
        {
            Destroy(gameObject);
        }
    }
}
