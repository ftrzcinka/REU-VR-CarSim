using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    private bool run;

    public List<Light> trafficLights;
    public bool StartGreen = true;
    public GameObject ring;
    private Renderer rend;
    private Color color;


    void Start()
    {
        run = true;
        rend = ring.GetComponent<Renderer>();
    }

    void Update()
    {
        if (run)
        {
            run = false;
            if (StartGreen)
            {
                trafficLights[2].enabled = false;
                trafficLights[1].enabled = false;
                trafficLights[0].enabled = true;
                color = new Color(0f, 1f, 0f, 1f);
                rend.material.SetColor("_Color", color);
                StartCoroutine(GreenToYellow());
            }
            else
            {
                trafficLights[1].enabled = false;
                trafficLights[0].enabled = false;
                trafficLights[2].enabled = true;
                color = new Color(1f, 0f, 0f, 1f);
                rend.material.SetColor("_Color", color);
                StartCoroutine(RedToGreen());
            }
        }
    }

    IEnumerator GreenToYellow()
    {
        yield return new WaitForSeconds(6f);

        trafficLights[0].enabled = false;
        trafficLights[2].enabled = false;
        trafficLights[1].enabled = true;
        color = new Color(1f, 1f, 0f, 1f);
        rend.material.SetColor("_Color", color);
        StartCoroutine(YellowToRed());
    }

    IEnumerator YellowToRed()
    {
        yield return new WaitForSeconds(2f);

        trafficLights[1].enabled = false;
        trafficLights[0].enabled = false;
        trafficLights[2].enabled = true;
        color = new Color(1f, 0f, 0f, 1f);
        rend.material.SetColor("_Color", color);
        StartCoroutine(RedToGreen());
    }

    IEnumerator RedToGreen()
    {
        yield return new WaitForSeconds(9f);

        trafficLights[2].enabled = false;
        trafficLights[1].enabled = false;
        trafficLights[0].enabled = true;
        color = new Color(0f, 1f, 0f, 1f);
        rend.material.SetColor("_Color", color);
        StartCoroutine(GreenToYellow());
    }
}
