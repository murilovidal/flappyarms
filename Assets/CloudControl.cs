using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudControl : MonoBehaviour
{
    public float cloudSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * cloudSpeed * Time.deltaTime;
        if (transform.position.x < -6)
        {
            Destroy(gameObject);
        }

    }
}
