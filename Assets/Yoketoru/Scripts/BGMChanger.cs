using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMChanger : MonoBehaviour
{
    [Tooltip("鳴らすBGM"), SerializeField]
    TinyAudio.BGM bgm = TinyAudio.BGM.GameOver;

    void Start()
    {
        TinyAudio.PlayBGM(bgm);
    }
}
