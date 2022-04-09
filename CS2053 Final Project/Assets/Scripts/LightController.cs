using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LightController : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;
    private Vector2 position = new Vector2(0f, 0f);
    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }
    
    void FixedUpdate()
    {
        rb.MovePosition(position);
      
    }

}
