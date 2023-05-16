using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    Vector3 startPosition;

    public float amplitude; // 移動量
    public float speed; // 速度

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float z = amplitude * Mathf.Sin(Time.time * speed); // ２方向の移動量を計算
        transform.localPosition = startPosition + new Vector3(0, 0, z); // 新しい座標の計算
    }
}
