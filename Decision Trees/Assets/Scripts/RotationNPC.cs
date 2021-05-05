using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationNPC : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;

    void Update()
    {
        Vector3 relativePos = playerTransform.position - transform.position;

        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
}
