using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject cloudModel1;
    public GameObject cloudModel2;
    public GameObject cloudModel3;
    public GameObject cloudModel4;
    float timer;
    
    static T RandomCloud<T>()
    {
        int rand = UnityEngine.Random.Range(0 ,3);
        var v = Enum.GetValues(typeof(T));
        return (T)v.GetValue(rand);
    }
    public enum CloudTypes
    {
        model1,
        model2,
        model3,
        model4
    }
    CloudTypes cloudTypes = CloudTypes.model1;
    public float interval;
    // Start is called before the first frame update
    void Start()
    {
        timer = interval;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > interval)
        {
            //spawn random cloud
            cloudTypes = RandomCloud<CloudTypes>();
            switch (cloudTypes)
            {
                case CloudTypes.model1:
                    Instantiate(cloudModel1, transform.position, Quaternion.identity, transform);
                    break;
                case CloudTypes.model2:
                    Instantiate(cloudModel2, transform.position, Quaternion.identity, transform);
                    break;
                case CloudTypes.model3:
                    Instantiate(cloudModel3, transform.position, Quaternion.identity, transform);
                    break;
                case CloudTypes.model4:
                    Instantiate(cloudModel4, transform.position, Quaternion.identity, transform);
                    break;
                default:
                    break;
            }
            timer -= interval;
        }

    }
}
