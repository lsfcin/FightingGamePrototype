using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public float approachZero(float quantity, float decrement)
    {
        if (quantity < 0.0f)
        {
            quantity += decrement * Time.deltaTime;

            if (quantity > 0.0f)
            {
                quantity = 0.0f;
            }
        }
        else if (quantity > 0.0f)
        {
            quantity -= decrement * Time.deltaTime;

            if (quantity < 0.0f)
            {
                quantity = 0.0f;
            }
        }

        return quantity;
    }
}
