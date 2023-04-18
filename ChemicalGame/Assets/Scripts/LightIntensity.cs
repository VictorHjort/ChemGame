using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightIntensity : MonoBehaviour
{
    public bool lightRed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lightRed)
        {
            foreach (Transform childTransform in this.transform)
            {
                Light w = childTransform.GetComponent<Light>();
                w.intensity = 5.48f;
            }

        }
        if (!lightRed)
        {
            foreach (Transform childTransform in this.transform)
            {
                Light w = childTransform.GetComponent<Light>();
                w.intensity = 0;
            }
        }
    }
}
