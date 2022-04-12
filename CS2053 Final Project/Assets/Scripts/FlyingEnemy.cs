using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    public float speed;
    private GameObject player;
    private GameObject flashLight;
    public bool chase = false;
    public bool run = false;
    public Transform originPoint;

    void Start()
    {
        //Debug.Log("Start game");
        player = GameObject.FindGameObjectWithTag("Player");
        flashLight = GameObject.FindGameObjectWithTag("Light");
    }

    void Update()
    {
        if(player == null)
        {

            return;
        }
        if (chase == true)
        {

            Chase();
        }

        else
        {
            //Debug.Log("PLayer not found");
            ReturnOriginPoint();
        }
        Flip();
    }

    void FixedUpdate()
    {
        if (run == true)
        {
            //Debug.Log("Touch light");
            Run();
        }
        if (chase == true)
        {

            Chase();
        }

        else
        {
            //Debug.Log("PLayer not found");
            ReturnOriginPoint();
        }
        Flip();
    }
    private void Chase()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        //Debug.Log("Start Chasing");
    }

    private void ReturnOriginPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, originPoint.transform.position, speed * Time.deltaTime);
        //Debug.Log("Returning to base");
    }

    private void Run()
    {
        ReturnOriginPoint();
        //Debug.Log("Start Running");
    }

    private void Flip()
    {
        if(transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }
}
