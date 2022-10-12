#define DEBUG_KEY

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        TinyAudio.PlaySE(TinyAudio.SE.Start);
    }

    void Update()
    {
#if DEBUG_KEY
        if(Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene("Gameover", LoadSceneMode.Additive);
        }
        else if(Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("Clear", LoadSceneMode.Additive);
        }
#endif
    }
}
