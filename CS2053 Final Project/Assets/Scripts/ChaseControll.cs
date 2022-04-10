using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseControll : MonoBehaviour
{
    public FlyingEnemy[] enemyArr;

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            foreach(FlyingEnemy enemy in enemyArr)
            {
                enemy.chase = true;
            }
            Debug.Log("found Player");
        }
        if (c.CompareTag("Light"))
        {
            foreach (FlyingEnemy enemy in enemyArr)
            {
                enemy.chase = false;
            }
            Debug.Log("Touch Light");
        }
    }

    private void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.CompareTag("Light"))
        {
            foreach (FlyingEnemy enemy in enemyArr)
            {
                enemy.chase = false;
            }
        }
        Debug.Log("Collision with Light tag");
    }

    private void OnTriggerExit2D(Collider2D c)
    {
        if (c.CompareTag("Player"))
        {
            foreach (FlyingEnemy enemy in enemyArr)
            {
                enemy.chase = false;
            }
        }
        Debug.Log("Exit Player");
    }
}
