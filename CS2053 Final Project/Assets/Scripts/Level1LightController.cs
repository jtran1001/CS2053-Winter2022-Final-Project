using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level1LightController : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.05f;
    private Vector2 position = new Vector2(0f, 0f);
    private Rigidbody2D rb;
    public SlimeController Slime;
    public Text Instructions;
    public Text Lilae;

    private int State;
    private float startTime;
    private float journeyLength;
    private bool keyA;
    private bool keyD;

    

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
        keyA = Input.GetKeyDown(KeyCode.A);
        keyD = Input.GetKeyDown(KeyCode.D);

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
            Lilae.text = "\"HELLO! MY NAME IS LILAE! SHOULDN'T A LITTLE SLIME LIKE YOU BE PLAYING IN A SWAMP WITH YOUR FRIENDS?\"";
            Instructions.text = "Press SPACE to jump/relpy.";
            Slime.Hydration = 20;
            if (Input.GetButton("Jump"))
            {
                State = 2;
                Instructions.text = "";
            }

        }

        if (State == 2)
        {

            Lilae.text = "\"AWW, THAT'S SO SAD! HERE, LET ME HELP YOU FIND A WAY OUT.\"";
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
            Lilae.text = "\"PLEASE WATCH YOUR HYDRATION, I CAN SEE YOU CHANGING COLORS FAST! I'VE NEVER KNOWN A SLIME WHO LIVED LONG AFTER THEY TURNED GREY.\"";
            Instructions.text = "Use the A and D keys to move to the water.";
            if (Input.GetButton("Fire1"))
            {
                
                State = 4;
                mousePosition = Input.mousePosition;
                mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
                position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
                rb.MovePosition(position);
                
            }
            else
            {
                position = Vector2.Lerp(transform.position, Slime.transform.position, moveSpeed);
            }
        }
        if (State == 4)
        {
            if (keyA is true || keyD is true)
            {
                Lilae.text = "";
                Instructions.text = "";
            }

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
