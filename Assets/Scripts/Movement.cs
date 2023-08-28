using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // [Range(0, 50)]
    public float topHorizontalSpeed = 7.0f;
    // [Range(0, 50)]
    public float horizontalAcceleration = 40.0f;
    public float horizontalSpeed = 0.0f;
    
    // [Range(0, 50)]
    public float gravity = 40.0f;
    // [Range(0, 50)]
    public float jumpTopSpeed = 15.0f;
    public float jumpSpeed = 0.0f;
    public float floorHeight;

    // Start is called before the first frame update
    void Start()
    {
        this.floorHeight = this.transform.position.y;
    }

    // Update is called once per frame  
    void Update()
    {
        decreaseSpeed();

        transform.position += new Vector3(horizontalSpeed * Time.deltaTime, 0, 0);
        
        // If pressing D or joystick left, move character to the right 
        if (Input.GetKey(KeyCode.D))
        {
            increaseSpeed(1.0f);
        }
        // If pressing A, move character to the left
        if (Input.GetKey(KeyCode.A))
        {
            increaseSpeed(-1.0f);
        }

        // If pressing W, move character up
        if (Input.GetKey(KeyCode.W) && 
            this.transform.position.y == this.floorHeight)
        {
            jumpSpeed = jumpTopSpeed;
        }
        
        transform.position += new Vector3(0, jumpSpeed * Time.deltaTime, 0);

    }

    private void decreaseSpeed()
    {
        horizontalSpeed = Util.approachZero(horizontalSpeed, horizontalAcceleration);

        jumpSpeed -= gravity * Time.deltaTime;
        if (this.transform.position.y <= this.floorHeight)
        {
            jumpSpeed = 0;
            this.transform.position = new Vector3(this.transform.position.x, this.floorHeight, this.transform.position.z);
        }
    }

    private void increaseSpeed(float direction)
    {
        horizontalSpeed += horizontalAcceleration * direction * 2 * Time.deltaTime;
        if (horizontalSpeed > topHorizontalSpeed)
        {
            horizontalSpeed = topHorizontalSpeed;
        }
        else if (horizontalSpeed < -topHorizontalSpeed)
        {
            horizontalSpeed = -topHorizontalSpeed;
        }
    }
}
