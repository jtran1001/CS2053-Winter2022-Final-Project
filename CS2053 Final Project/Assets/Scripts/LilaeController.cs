using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LilaeController : MonoBehaviour
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
