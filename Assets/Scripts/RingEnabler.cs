using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingEnabler : MonoBehaviour
{
    public GameObject ring;

    void OnTriggerEnter(Collider col)
    {
        ring.SetActive(true);
    }

    void OnTriggerExit(Collider col)
    {
        ring.SetActive(false);
    }
}
