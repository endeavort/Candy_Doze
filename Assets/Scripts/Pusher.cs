using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pusher : MonoBehaviour
{
    Vector3 startPosition;

    public float amplitude; // �ړ���
    public float speed; // ���x

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        float z = amplitude * Mathf.Sin(Time.time * speed); // �Q�����̈ړ��ʂ��v�Z
        transform.localPosition = startPosition + new Vector3(0, 0, z); // �V�������W�̌v�Z
    }
}
