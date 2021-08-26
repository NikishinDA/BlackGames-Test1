using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.transform.up = gameObject.transform.up;
    }
    private void OnTriggerExit(Collider other)
    {
        other.transform.up = Vector3.up;
    }
}
