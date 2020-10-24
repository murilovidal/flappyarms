using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PipeSpawner : MonoBehaviour
{
    public GameObject pipeModel;
    public float interval;
    public float gap = 3;
    float timer;
    bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        timer = interval;
    }

    // Update is called once per frame
    void Update()
    {
        float height;
        

        if (Input.GetMouseButtonDown(0))
        {
            started = true;
        }
        if (started)
        {
            timer += Time.deltaTime;
            if (timer > interval)
            {
                //spawnar novo pipe
                height = UnityEngine.Random.Range(-3f, -0.5f);
                timer -= interval;
                Instantiate(pipeModel, transform.position + Vector3.up * height, Quaternion.identity, transform);
                Instantiate(pipeModel, transform.position + Vector3.up * (height + gap), Quaternion.AngleAxis(180f, Vector3.forward), transform);
            }
        }
    }

    internal void Stop()
    {
        foreach (Transform child in transform)
        {
            child.GetComponent<PipeControl>().enabled = false;
        }
        enabled = false;
    }
}
