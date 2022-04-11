using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    public float moveSpeed = 0.05f;
    private Vector2 position = new Vector3(0f, 0f, -5f);
    private Rigidbody2D rb;
    public SlimeController Slime;

    private int State;

    private float startTime;
    private float journeyLength;

    private float x;
    private float y;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        position = Slime.transform.position;
        startTime = Time.time;
        journeyLength = Vector3.Distance(transform.position, Slime.transform.position);
        State = 0;
    }
    void Update()
    {

        if (State == 0)
        {
            float distCovered = (Time.time - startTime) * moveSpeed;
            float fractionOfJourney = distCovered / journeyLength;
            position = Vector2.Lerp(transform.position, Slime.transform.position, fractionOfJourney);

            if (transform.position.y <= -28.4 )
            {
                State = 1;
            }

        }       

    }

    void LateUpdate()
    {
        if (State == 0)
        {
            rb.MovePosition(position);
        }
        else
        {
            x = Slime.transform.position.x;
            y = Slime.transform.position.y;

            transform.position = new Vector3(x,y,-11f);
        }
    }

}
