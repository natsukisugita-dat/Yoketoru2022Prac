using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopBGMAndPlaySE : MonoBehaviour
{
    [Tooltip("鳴らすSE"), SerializeField]
    TinyAudio.SE se = TinyAudio.SE.Miss;

    void Start()
    {
        TinyAudio.StopBGM();
        TinyAudio.PlaySE(se);
    }
}
