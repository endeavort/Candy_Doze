using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    const int MaxShotPower = 5;
    const int RecoverySeconds = 3;

    int shotPower = MaxShotPower;
    AudioSource shotSound;

    public GameObject[] candyPrefabs; // 配列にしてキャンディをすべて入れる
    public Transform candyParentTransform; // 空のゲームオブジェクト「candies」の位置情報
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


        Rigidbody candyRigidbody = candy.GetComponent<Rigidbody>(); // candyからRigidbodyの部分のみ取り出し
        candyRigidbody.AddForce(transform.forward * shotForce); // 力を加える
        candyRigidbody.AddTorque(new Vector3(0, shotTorque, 0)); // ねじりの強さ

        candyManager.ConsumeCandy(); // 消費
        ConsumePower(); // パワー消費
        shotSound.Play();

        void OnGUI() // 画面出力
        {
            GUI.color = Color.black; // 色を黒に設定
            string label = "";
            for(int i = 0; i < shotPower; i++)
            {
                label = label + "+";
            }
            GUI.Label(new Rect(50, 65, 100, 30), label);
        }

        void ConsumePower() // パワー消費
        {
            shotPower--;
            StartCoroutine(RecoverPower()); // パワー回復用
        }

        IEnumerator RecoverPower()
        {
            yield return new WaitForSeconds(RecoverySeconds);
            shotPower++;
        }

    }
}
