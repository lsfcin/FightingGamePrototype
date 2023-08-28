using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float originalLocalX;
    public Vector3 originalLocalScale;
    
    [Range(0, 150)]
    public float speedX = 0.0f;

    [Range(0, 150)]
    public float accelerationX = 100.0f;

    [Range(0, 150)]
    public float topSpeed = 12.0f;

    // Start is called before the first frame update
    void Start()
    {
        this.originalLocalX = this.transform.localPosition.x;
        this.originalLocalScale = new Vector3(
            this.transform.localScale.x,
            this.transform.localScale.y,
            this.transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        this.speedX -= accelerationX * Time.deltaTime;
        if (this.transform.localPosition.x <= this.originalLocalX + 0.01f)
        {
            this.speedX = 0;
            this.transform.position = new Vector3(transform.parent.transform.position.x + this.originalLocalX, this.transform.position.y, this.transform.position.z);
            this.transform.localScale = originalLocalScale;
        }

        // If pressing space, attack
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Move back and forth
            speedX = topSpeed;

            // Play sound from GameObject PunchAudioSource
            AudioSource audioSource = GameObject.Find("PunchAudioSource").GetComponent<AudioSource>();
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }

        this.transform.localPosition += new Vector3(speedX/2.0f * Time.deltaTime, 0, 0);
        this.transform.localScale = new Vector3(
            this.transform.localScale.x + speedX * Time.deltaTime, 
            this.transform.localScale.y, 
            this.transform.localScale.z);

        // If this GameObject is colliding with GameObject Char2, then play sound from GameObject HitAudioSource
        if (this.GetComponent<BoxCollider2D>().IsTouching(GameObject.Find("Char2").GetComponent<BoxCollider2D>()))
        {
            AudioSource audioSource = GameObject.Find("HitAudioSource").GetComponent<AudioSource>();
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
        }
    }
}
