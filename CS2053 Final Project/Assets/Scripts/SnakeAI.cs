using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAI : MonoBehaviour
{
    private Animator anim;
    private Vector3 velocity;
    private SpriteRenderer rend;
    private bool lunge = false;
    public float speed = 1.0f;
    public float lungeModifier = 2.0f;
    public float leftEdge = 0.0f;
    public float rightEdge = 5.0f;
    public float snakeVisionRange = 3.0f;
    public GameObject player;
    public AudioSource snakeHiss;
    


    // Start is called before the first frame update
    void Start()
    {
        int startingMove = Random.Range(0,1);
        Vector3 velocity = new Vector3(1, 0f, 0f);
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        snakeHiss = GetComponent<AudioSource>();
        snakeHiss.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        Transform playerTransform = player.transform;
        Vector3 playerPos = playerTransform.position;
        var dist = (transform.position - Camera.main.transform.position).z;

        float width = rend.bounds.size.x;
        float height = rend.bounds.size.y;
        snakeHiss.Pause();

        //lunging/swarming behaviour, jump on the player while in the snake territory and keep hitting
        if((playerPos.x <= transform.position.x - snakeVisionRange) && (velocity.x > 0f)){
            velocity = new Vector3(speed*lungeModifier, 0f, 0f);
            lunge = true;
        }
        if((playerPos.x <= transform.position.x - snakeVisionRange) && (velocity.x < 0f)){
            velocity = new Vector3(-speed*lungeModifier, 0f, 0f);
            lunge = true;
        }

        //regular back and forth movement
        if((transform.position.x <= leftEdge)){
            velocity = new Vector3(speed, 0f, 0f);
        }
        if((transform.position.x >= rightEdge)){
            velocity = new Vector3(-speed, 0f, 0f);
        }
        

        transform.position = transform.position + velocity * Time.deltaTime * speed;
    }

    void LateUpdate(){
        if(velocity.x >= 0){
            anim.Play("SnakeRight");
        }
        if(velocity.x < 0){
            anim.Play("SnakeLeft");
        }
        if(lunge){
            snakeHiss.Play(0);
            lunge = false;
            snakeHiss.Pause();
        }
    }
}
