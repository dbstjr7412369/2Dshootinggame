using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    // ��ǥ �ٸ� ��ü�� �浹�ϸ� �浹�� ��ü�� �ı�(����)�ع�����
    // ��������
    // ���࿡ �ٸ� ��ü�� �浹�ϸ�
    // �浹�� ��ü�� �ı��� ������

    // ���࿡ �ٸ� ��ü�� �浹�ϸ� 

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag ("Bullet"))
        {
            otherCollider.gameObject.SetActive(false);
        }
        else
        {
           //�浹�� ��ü�� �ı��ع�����
           Destroy(otherCollider.gameObject);
        }
    }
}