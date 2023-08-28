using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Change X scale based on distance from GameObject Char1 and Char2
        float distance = 
            Vector3.Distance(
                GameObject.Find("Char1").transform.position, 
                GameObject.Find("Char2").transform.position);

        this.transform.localScale = new Vector3(distance, this.transform.localScale.y, this.transform.localScale.z);

        // Play sound from GameObject TestAudioSource
        if(distance < 5.0f)
        {
            AudioSource audioSource = GameObject.Find("ProximityAudioSource").GetComponent<AudioSource>();
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
