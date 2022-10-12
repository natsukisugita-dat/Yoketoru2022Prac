using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallChangeScene : MonoBehaviour
{
    ToNextScene toNextScene;

    static float IgnoreKeySeconds => 0.5f;
    float ignoreTime;

    void Start()
    {
        toNextScene = GetComponent<ToNextScene>();
        ignoreTime = 0;
    }

    void Update()
    {
        ignoreTime += Time.deltaTime;
        if (ignoreTime < IgnoreKeySeconds) return;

        if (Input.GetButtonUp("Next"))
        {
            toNextScene.ChangeScene();
        }
    }
}
