using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SlimeController : MonoBehaviour
{

    public int speed;
    public float fallMultiplier = 1.5f;
    public float lowJumpMultiplier = 2f;
    public float jumpVelocity;
    public Text HydrationText;

    Rigidbody2D rb;

    private Vector3 horizontalVelocity;
    private bool CanJump = false;
    private bool WaterZone = false;
    private int Hydration = 10;
    private int FullHydration = 10;
    private float LastResetTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        horizontalVelocity = new Vector3(0f, 0f, 0f);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalVelocity = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);

        if (CanJump is true)
        {
            if (Input.GetButtonDown("Jump"))
            {
                rb.velocity = Vector2.up * jumpVelocity;
            }
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && Input.GetButton("Jump"))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier) * Time.deltaTime;
            }
        }
        

        transform.position = transform.position + horizontalVelocity * Time.deltaTime * speed;

        if (WaterZone is false)
        {
            Hydration = FullHydration - ((int)Time.timeSinceLevelLoad - (int)LastResetTime);

        }
        else 
        {
            Hydration = 10; 
        }
        HydrationText.text = "Hydration: " + Hydration.ToString();

    }

    void OnTriggerEnter2D(Collider2D c)
    {
        
        if (c.gameObject.tag == "CanJumpGround")
        {
            CanJump = true;
        }
    }

    void OnTriggerStay2D(Collider2D c)
    {
        if (c.gameObject.tag == "WaterZone")
        {
            WaterZone = true;
        }
    }

    void OnTriggerExit2D(Collider2D c)
    {

        if (c.gameObject.tag == "CanJumpGround")
        {
            CanJump = false;
        }

        if (c.gameObject.tag == "WaterZone")
        {
            WaterZone = false;
            LastResetTime = Time.timeSinceLevelLoad;
        }
    }
}
