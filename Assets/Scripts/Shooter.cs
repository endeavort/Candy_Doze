using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    const int MaxShotPower = 5;
    const int RecoverySeconds = 3;

    int shotPower = MaxShotPower;
    AudioSource shotSound;

    public GameObject[] candyPrefabs; // �z��ɂ��ăL�����f�B�����ׂē����
    public Transform candyParentTransform; // ��̃Q�[���I�u�W�F�N�g�ucandies�v�̈ʒu���
    public CandyManager candyManager;
    public float shotForce;
    public float shotTorque;
    public float baseWidth;

    // Start is called before the first frame update
    void Start()
    {
        shotSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) Shot();
    }

    public void Shot()
    {
        if (candyManager.GetCandyAmount() <= 0 || shotPower <= 0)
        {
            return;
        }

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

        candyManager.ConsumeCandy(); // ����
        ConsumePower(); // �p���[����
        shotSound.Play();

        void OnGUI() // ��ʏo��
        {
            GUI.color = Color.black; // �F�����ɐݒ�
            string label = "";
            for(int i = 0; i < shotPower; i++)
            {
                label = label + "+";
            }
            GUI.Label(new Rect(50, 65, 100, 30), label);
        }

        void ConsumePower() // �p���[����
        {
            shotPower--;
            StartCoroutine(RecoverPower()); // �p���[�񕜗p
        }

        IEnumerator RecoverPower()
        {
            yield return new WaitForSeconds(RecoverySeconds);
            shotPower++;
        }

    }
}
