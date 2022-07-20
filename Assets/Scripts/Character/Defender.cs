using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : Character
{
    // Start is called before the first frame update
    void Start()
    {
        Cost = 200;
        Debug.Log("Cost " + Cost);
    }
}
