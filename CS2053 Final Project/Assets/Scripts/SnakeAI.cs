using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeAI : MonoBehaviour
{
    private Animator anim;
    private Vector3 velocity;
    private SpriteRenderer rend;
    public float speed = 2.0f;
    public float leftEdge = 0.0f;
    public float rightEdge = 5.0f;


    // Start is called before the first frame update
    void Start()
    {
        int startingMove = Random.Range(0,1);
        Vector3 velocity = new Vector3(1, 0f, 0f);
        rend = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        var dist = (transform.position - Camera.main.transform.position).z;
        /*var leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        var rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        var bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        var topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
*/
        float width = rend.bounds.size.x;
        float height = rend.bounds.size.y;

        if((transform.position.x <= leftEdge) && velocity.x < 0f){
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
    }
}
