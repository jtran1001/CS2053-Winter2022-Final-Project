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
    public GameObject deathMask;
    public AudioSource slimePlop;
    

    Rigidbody2D rb;

    private Vector3 horizontalVelocity;
    private bool CanJump = false;
    private bool WaterZone = false;
    private int Hydration = 10;
    private int FullHydration = 10;
    private float LastResetTime = 0;
    private bool inAir = false;

    // Start is called before the first frame update
    void Start()
    {
        horizontalVelocity = new Vector3(0f, 0f, 0f);
        rb = GetComponent<Rigidbody2D>();
        
        deathMask.SetActive(false);
        slimePlop = GetComponent<AudioSource>();
        slimePlop.Pause();
        Time.timeScale = 1;
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
                inAir = true;
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
            if(inAir){
            slimePlop.Play(0);
            inAir = false;
            slimePlop.Pause();
            }
        }
        if(c.gameObject.tag == "Ground"){
            if(inAir){
                slimePlop.PlayOneShot(slimePlop.clip, 1);
                inAir = false;
            }
        }
        if (c.gameObject.tag == "Enemy_Snake")
        {

            deathMask.SetActive(true);
            //Time.timeScale = 0.1;
            StartCoroutine(DeathPause());
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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