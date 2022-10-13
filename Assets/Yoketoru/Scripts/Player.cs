using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        var mpos = Input.mousePosition;
        Debug.Log(mpos);
    }
}
