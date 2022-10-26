using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Tooltip("速さ"), SerializeField]
    float speed = 20;
    float cameraDistance;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        cameraDistance = Vector3.Distance(transform.position, Camera.main.transform.position);
    }

    void FixedUpdate()
    {
        var mpos = Input.mousePosition;
        //Debug.Log(mpos);
        mpos.z = cameraDistance;
        var wp = Camera.main.ScreenToWorldPoint(mpos);

        // to = 現在地から目的地wpへの向きと大きさ(ベクトル)
        Vector3 to = wp - transform.position;

        if (to.magnitude < 0.01f) 
        {
            rb.velocity = Vector3.zero;
        }
        else
        {
            float step = speed * Time.deltaTime;
            float dist = Mathf.Min(to.magnitude, step);
            float v = dist / Time.deltaTime;
            rb.velocity = v * to.normalized;
        }
        //transform.position = wp;
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.collider.CompareTag("Enemy"))
        {
            GameManager.ToGameover();
        }
    }
}
