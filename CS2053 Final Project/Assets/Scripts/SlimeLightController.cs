using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeLightController : MonoBehaviour
{
    public SlimeController Slime;
    private int Hydration;


    // Start is called before the first frame update
    void Start()
    {
        Hydration = Slime.Hydration;
    }

    // Update is called once per frame
    void Update()
    {
        if (Hydration < 0)
        {
            
        }
        else if (Hydration <= 4)
        {
            
        }
        else if (Hydration <= 8)
        {
            
        }
        else if (Hydration <= 12)
        {
            
        }
        else if (Hydration <= 16)
        {
            
        }
        else
        {
            
        }
    }
}
