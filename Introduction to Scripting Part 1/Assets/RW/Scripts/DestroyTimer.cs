using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTimer : MonoBehaviour
{
    public float timeToDestroy;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDestroy); //destory after timeToDestroy sec.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
