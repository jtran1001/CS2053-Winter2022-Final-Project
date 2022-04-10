using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LightController : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.05f;
    private Vector2 position = new Vector2(0f, 0f);
    private Rigidbody2D rb;
    public SlimeController Slime;
    public Text Instructions;
    

    private int State;

    private float startTime;
    private float journeyLength;

    public Text Lilae;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        position = Slime.transform.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, Slime.transform.position);
        State = 0;
        Lilae.text = "";
        Instructions.text = "";
    }
    void Update()
    {

        if (State == 0)
        {
            float distCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distCovered / journeyLength;
            position = Vector2.Lerp(transform.position, Slime.transform.position, fractionOfJourney);

            if (transform.position.y < -25)
            {
                State = 1;
            }

        }

        if (State == 1)
        {
            Lilae.text = "HELLO! SHOULDN'T A LITTLE SLIME LIKE YOU BE PLAYING IN A SWAMP WITH YOUR FRIENDS?";
            Instructions.text = "Press SPACE to jump/relpy.";
            if (Input.GetButton("Jump"))
            {
                State = 2;
                Instructions.text = "";
            }

        }

        if (State == 2)
        {

            Lilae.text = "AWW, THAT'S SO SAD! HERE, LET ME HELP YOU FIND A WAY OUT.";
            Instructions.text = "Left-click on the mouse to direct Lilae.";

            if (Input.GetButton("Fire1"))
            {
                State = 3;
                Lilae.text = "";
                Instructions.text = "";
            }
        }

        if (State == 3)
        {
            if (Input.GetButton("Fire1"))
            {
                mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
                rb.MovePosition(position);
                Lilae.text = "";
            }
            else
            {
                position = Vector2.Lerp(transform.position, Slime.transform.position, moveSpeed);
            }
        }

    }

    void LateUpdate()
    {


        rb.MovePosition(position);

    }

}
