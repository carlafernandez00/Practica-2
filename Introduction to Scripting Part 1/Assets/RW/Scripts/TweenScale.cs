using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TweenScale : MonoBehaviour
{
    public float targetScale;        //Final scale
    public float timeToReachTarget;  //time in sec to reach the target scale
    private float startScale;        //Scale of the game obj at the moment
    private float percentScaled;     //Used to change the scale (0-1)

    // Start is called before the first frame update
    void Start()
    {
        startScale = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        // Increase the scaling until the percentScaled gets value 1 
        if (percentScaled < 1f)
        {
            percentScaled += Time.deltaTime / timeToReachTarget; //update the percentScaled considerung the time between frames
            float scale = Mathf.Lerp(startScale, targetScale, percentScaled); //Get the scale value corresponding to the percentScaled
            transform.localScale = new Vector3(scale, scale, scale); //modify the object's scale

        }
    }
}
