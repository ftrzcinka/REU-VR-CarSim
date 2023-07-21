using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaneAlertController: MonoBehaviour
{
    private Renderer rend;
    private Color color;

    public AudioSource alertByte;

    void Start()
    {
        rend = GetComponent<Renderer>();
        color = new Color(1f, 0.47f, 0.47f, 0f);
        rend.material.SetColor("_Color", color);
    }

    void OnTriggerEnter(Collider col)
    {
        color = new Color(1f, 0.47f, 0.47f, 0.4f);
        rend.material.SetColor("_Color", color);
        alertByte.Play();
    }

    void OnTriggerExit(Collider col)
    {
        color = new Color(1f, 0.47f, 0.47f, 0f);
        rend.material.SetColor("_Color", color);
        alertByte.Stop();
    }
}
