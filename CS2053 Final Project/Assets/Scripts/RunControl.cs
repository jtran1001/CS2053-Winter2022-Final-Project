using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunControl : MonoBehaviour
{
    public FlyingEnemy[] enemyArr;

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Light"))
        {
            foreach (FlyingEnemy enemy in enemyArr)
            {
                enemy.chase = false;
                enemy.run = true;
            }
            Debug.Log("Touch Light");
        }
    }
}
