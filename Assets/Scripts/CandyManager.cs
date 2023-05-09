using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandyManager : MonoBehaviour
{
    const int DefaultCandyAmount = 30; // �L�����f�B�����l
    const int RecoverySeconds = 10; // �L�����f�B�𑝂₷�Ԋu�i10�b�j

    public int candy = DefaultCandyAmount; // ���݂̃L�����f�B��
    int counter; // �J�E���g�_�E��

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
        // �J�E���g�_�E����\��
        if (counter > 0) label = label + "�i" + counter + "s�j";
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
            StartCoroutine(RecoverCandy()); // StartCoroutine()�R���[�`�����X�^�[�g����֐�
        }
    }

    IEnumerator RecoverCandy()
    {
        counter = RecoverySeconds;
        while(counter > 0)
        {
            yield return new WaitForSeconds(1.0f); // 1�b��ɍĊJ
            counter--;
        }
        candy++;
    }
}
