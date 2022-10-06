using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

// 継承 = 他のクラスの機能を受け継いで拡張
public class ToNextScene : MonoBehaviour
{
    [Tooltip("切り替えたいシーン名"), SerializeField]
    string nextScene = default;

    //何回も呼び出されないようにするため
    bool sceneChanged;

    public void ChangeScene()
    {
        if (sceneChanged) return;

        sceneChanged = true;
        TinyAudio.PlaySE(TinyAudio.SE.Start);
        SceneManager.LoadScene(nextScene);
    }
}
