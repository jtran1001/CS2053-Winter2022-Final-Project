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
        }
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
    }
}
