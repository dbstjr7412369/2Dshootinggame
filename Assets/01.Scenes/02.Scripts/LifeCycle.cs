using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCycle : MonoBehaviour
{
    private void Awake()
    {
        // �ν��Ͻ�ȭ �� ���Ŀ� ȣ��
        //�ַ� ������ ���³� ������ �ʱ�ȭ �� �� ��� 
        Debug.Log("Awake");
    }

    private void OnEnable()
    {
        //��밡���� ������ ȣ��ȴ�
        //����ڰ� ���� �̺�Ʈ�� ������ �� �ַ� ���
        Debug.Log("OnEnable");
    }
    private void Start()
    {
        // ������ �� ȣ��ȴ�.
        // �ٸ� ��ũ��Ʈ�� ��� Aweke ��� ����� ���� ȣ��ȴ�.
        Debug.Log("Start");

    }
    //Input ������Ʈ
    private void Update()
    {
        //�� �����Ӹ��� ȣ��ȴ�
    }
    // �ڷ�ƾ ������Ʈ
    private void LateUpdate()
    {
        // ��� Ȱ��ȭ�� ��ũ��Ʈ�� Update �Լ��� ȣ��ǰ� ���� �� ���� ȣ��ȴ�.
    }
    private void OnDisable()
    {
        // ��� �Ұ����� ������ ȣ��ȴ�
        // ����ڰ� ���� �̺�Ʈ�� ���� ������ ��
        Debug.Log("OnDisable");
    }
    //����Ƽ ���� 120p�� �ڼ��� ������ ���´�
}
