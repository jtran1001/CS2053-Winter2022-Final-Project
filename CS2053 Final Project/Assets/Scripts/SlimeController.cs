﻿using System;
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
    public GameObject deathMask;
    public AudioClip Water;
    public AudioClip Hit;

    Rigidbody2D rb;

    private Vector3 horizontalVelocity;
    private bool CanJump = false;
    private bool WaterZone = false;
    public int FullHydration = 10;
    public int Hydration = 10;
    private float LastResetTime = 0;
    private int State;
    private AudioSource playerAudio;

    SpriteRenderer m_SpriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        horizontalVelocity = new Vector3(0f, 0f, 0f);
        rb = GetComponent<Rigidbody2D>();

        deathMask.SetActive(false);
        Time.timeScale = 1;
        Hydration = FullHydration+10;
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_SpriteRenderer.color = new Color(0, 255, 0, 255);
        State = 1;
        HydrationText.text = "";

        playerAudio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        if (WaterZone is false)
        {
            Hydration = FullHydration - ((int)Time.timeSinceLevelLoad - (int)LastResetTime);
        }
        else
        {
            Hydration = FullHydration;
        }
        //HydrationText.text = "Hydration: " + Hydration.ToString();


        if (Hydration < 0)
        {
            m_SpriteRenderer.color = new Color(0, 0, 0, 0);
            State = 2;
            deathMask.SetActive(true);
            //Time.timeScale = 0.1;
            StartCoroutine(DeathPause());
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else if (Hydration <= 4)
        {
            m_SpriteRenderer.color = new Color(0, 0, 0, 255);
        }
        else if (Hydration <= 8)
        {
            m_SpriteRenderer.color = new Color(255, 0, 0, 100);
        }
        else if (Hydration <= 12)
        {
            m_SpriteRenderer.color = new Color(255, 255, 0, 150);
        }
        else if (Hydration <= 16)
        {
            m_SpriteRenderer.color = new Color(0, 255, 0, 200);
        }
        else
        {
            m_SpriteRenderer.color = new Color(0, 255, 255, 255);
        }

        if (State == 1)
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
        }
    }

    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "WaterZone")
        {
            WaterZone = true;
            playerAudio.PlayOneShot(Water, 1.0f);
        }

        if (c.gameObject.tag == "CanJumpGround")
        {
            CanJump = true;

        }
        if(c.gameObject.tag == "Ground"){

        }
        if (c.gameObject.tag == "Enemy")
        {
            playerAudio.PlayOneShot(Hit, 1.0f);
            deathMask.SetActive(true);
            //Time.timeScale = 0.1;
            StartCoroutine(DeathPause());
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            State = 2;
        }
        if (c.gameObject.tag == "ExitPoint1")
        {
            SceneManager.LoadScene("MH_Level2");
        }
        if (c.gameObject.tag == "ExitPoint2")
        {
            SceneManager.LoadScene("MH_Level1");
        }
        if (c.gameObject.tag == "ExitPoint3")
        {
            SceneManager.LoadScene("SlimeGame1");
        }
        if (c.gameObject.tag == "ExitPoint4")
        {
            SceneManager.LoadScene("SlimeGame2");
        }
        if (c.gameObject.tag == "ExitPoint5")
        {
            SceneManager.LoadScene("Boss");
        }
        if (c.gameObject.tag == "EndPoint")
        {
            SceneManager.LoadScene("End");
        }
    }

    IEnumerator DeathPause(){
        yield return new WaitForSecondsRealtime(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
