using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.ContentSizeFitter;

public class EnemySpanwer : MonoBehaviour
{
    //����: �����ð����� ���� �����ؼ� �� ��ġ�� ���ٳ���ʹ�.

    // �ʿ� �Ӽ�:
    // �� ������
    // �����ð�
    // ����ð� 

    // ��������
    //1. �ð��� �帣�ٰ�
    //2. ���࿡ �ð��� �����ð��� �Ǹ�
    //3. ���������κ��� ���� �����Ѵ�
    //4. ������ ���� ��ġ�� �� ��ġ�� �ٲ۴�

    // ��ǥ �������ð��� �����ϰ� �ϰ� �ʹ�
    // �ʿ�Ӽ�
    //�ּҽð�
    //�ִ�ð�
    public float MinTime = 0.5f;
    public float MaxTime = 1.5f;

    [Header("�� ������")]
    public GameObject EnemyPrefab;

    [Header("�� ���� �ӵ�")]
    public float Timer = 10.0f;
    public float COOL_TIME = 1.0f;

    [Header("�� ����")]
    public GameObject[] EnemySpanwer_1;      

    [Header("�ڵ����")]
    public bool AutMode = false;
    private void Start()
    {
        // ������ �� �� �����ð��� �����ϰ� �����Ѵ�.
        RandomSpawnTime();

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("�� ����");
            AutMode = true;
        }
        Timer -= Time.deltaTime;// Ÿ�̸� ����

        // 1. Ÿ�̸Ӱ� 0���� ���� ���¿��� �߻� ��ư�� ������
       
        if (Timer <= 0)
        {
            // Ÿ�̸� �ʱ�ȭ
            Timer = COOL_TIME;
            
            for (int i = 0; i < EnemySpanwer_1.Length; i++)
            {
                // �Ѿ��� ����� 
                GameObject Enemy = Instantiate(EnemyPrefab);
                // ��ġ�� �����Ѵ�
                Enemy.transform.position = EnemySpanwer_1[i].transform.position;
                RandomSpawnTime();
            }
        }
    }
    private void RandomSpawnTime()
    {
        Timer = Random.Range(MinTime, MaxTime);
    }
}
