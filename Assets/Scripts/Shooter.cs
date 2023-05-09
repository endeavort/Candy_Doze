using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject[] candyPrefabs; // �z��ɂ��ăL�����f�B�����ׂē����
    public Transform candyParentTransform; // ����̃Q�[���I�u�W�F�N�g�ucandies�v�̈ʒu���
    public float shotForce;
    public float shotTorque;
    public float baseWidth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shot();
    }

    void Shot()
    {
        GameObject SelectCandy()
        {
            int select = Random.Range(0, candyPrefabs.Length);
            return candyPrefabs[select];
        }

        Vector3 GetInstantiatPosition()
        {
            float x = baseWidth * (Input.mousePosition.x / Screen.width) - (baseWidth / 2);
            return transform.position + new Vector3(x, 0, 0);
        }

        GameObject candy = Instantiate(SelectCandy(), GetInstantiatPosition(), Quaternion.identity);
        candy.transform.parent = candyParentTransform;


        Rigidbody candyRigidbody = candy.GetComponent<Rigidbody>(); // candy����Rigidbody�̕����̂ݎ��o��
        candyRigidbody.AddForce(transform.forward * shotForce); // �͂�������
        candyRigidbody.AddTorque(new Vector3(0, shotTorque, 0)); // �˂���̋���
    }
}
