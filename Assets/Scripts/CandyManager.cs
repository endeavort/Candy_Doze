using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyManager : MonoBehaviour
{
    const int DefaultCandyAmount = 30; // �L�����f�B�����l
    public int candy = DefaultCandyAmount; // ���݂̃L�����f�B��

    // ����\�b�h
    public void ConsumeCandy()
    {
        if (candy > 0) candy--;
    }

    // ���݂̐���߂����\�b�h
    public int GetCandyAmount()
    {
        return candy;
    }

    // �ǉ����\�b�h
    public void AddCandy(int amount)
    {
        candy += amount;
    }

    void OnGUI()
    {
        GUI.color = Color.black; // �F�����ɐݒ�
        // �\��
        string label = "Candy �F " + candy;
        GUI.Label(new Rect(50, 50, 100, 30), label);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
