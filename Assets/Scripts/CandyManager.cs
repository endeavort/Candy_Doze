using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyManager : MonoBehaviour
{
    const int DefaultCandyAmount = 30; // キャンディ初期値
    const int RecoverySeconds = 10; // キャンディを増やす間隔（10秒）

    public int candy = DefaultCandyAmount; // 現在のキャンディ数
    int counter; // カウントダウン

    // 消費メソッド
    public void ConsumeCandy()
    {
        if (candy > 0) candy--;
    }

    // 現在の数を戻すメソッド
    public int GetCandyAmount()
    {
        return candy;
    }

    // 追加メソッド
    public void AddCandy(int amount)
    {
        candy += amount;
    }

    void OnGUI()
    {
        GUI.color = Color.black; // 色を黒に設定
        // 表示
        string label = "Candy ： " + candy;
        // カウントダウンを表示
        if (counter > 0) label = label + "（" + counter + "s）";
        GUI.Label(new Rect(50, 50, 100, 30), label);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(candy < DefaultCandyAmount && counter <= 0)
        {
            StartCoroutine(RecoverCandy()); // StartCoroutine()コルーチンをスタートする関数
        }
    }

    IEnumerator RecoverCandy()
    {
        counter = RecoverySeconds;
        while(counter > 0)
        {
            yield return new WaitForSeconds(1.0f); // 1秒後に再開
            counter--;
        }
        candy++;
    }
}
