using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FocusChecker : MonoBehaviour
{
    private bool focused;
    private float maxTime = 2f;
    private float timer = 0f;
    private bool played;

    public AudioSource alertByte;

    // Start is called before the first frame update
    void Start()
    {
        focused = true;
        played = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!focused)
        {
            timer += Time.deltaTime;

            if(timer >= maxTime)
            {
                if (!played)
                {
                    played = true;
                    alertByte.Play();
                }
            }
        }
        else
        {
            alertByte.Stop();
            played = false;
            timer = 0;
        }
    }

    public void OnBecameInvisible()
    {
        focused = false;
    }

    public void OnBecameVisible()
    {
        focused = true;
    }
}
