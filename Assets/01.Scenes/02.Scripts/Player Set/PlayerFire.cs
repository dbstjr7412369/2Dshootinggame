using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // �Ѿ� �߻� ����
    // ��ǥ �Ѿ��� ���� �߻��ϰ� �ʹ�
    // �Ӽ�
    // - �Ѿ�
    // - �ѱ���ġ
    // ���� ����
    // 1. �߻� ��ư�� ������
    // 2. ���������κ��� �Ѿ��� �������� �����
    // 3. ���� �Ѿ��� ��ġ�� �ѱ��� ��ġ�� �ٲ۴�.
    //Prefad ��Ȱ���� ������ �ڵ�

    [Header("�Ѿ� ������")]
    public GameObject BulletPrefab;// �Ѿ� ������
    [Header("�����Ѿ� ������")]
    public GameObject BulletPrefab_serve;// ���� �Ѿ� ������

    [Header("�ѱ�����")]
    public GameObject[] Muzzles;      // �迭�� �ѱ�
    [Header("�����ѱ�����")]
    public GameObject[] Muzzles_serve;      // �迭�� �����ѱ�

    [Header("Ÿ�̸�")]
    public float Timer = 10.0f;
    public const float COOL_TIME = 0.6f;
    public float BoomTimer = 5f;
    public const float BoomCOOL_TIME = 0f;

    [Header("�ڵ����")]
    public bool AutMode = false;

    //�Ҹ�
    public AudioSource FireSource;
    //������ �� ������
    public GameObject BoomPrepre;


    private void Start()
    {
        Timer = 0;// public float Timer = 10.0f;�� �ʱ�ȭ�� ��
        AutMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("�ڵ����ݸ��");
            AutMode = true;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("�������ݸ��");
            AutMode = false;
        }
        Timer -= Time.deltaTime;// Ÿ�̸� ����
        // 1. Ÿ�̸Ӱ� 0���� ���� ���¿��� �߻� ��ư�� ������


        // �Ѿ� �߻� ��Ÿ�� ���� (0.6�ʿ� �� �� �߻� ����)
        // Ÿ�̸� ���
        BoomTimer -= Time.deltaTime;// ��ź Ÿ�̸� ����
        if (Input.GetKeyDown(KeyCode.Alpha3) && BoomTimer <= 0f)
        {

            if (BoomTimer <= 0f && Input.GetKeyDown(KeyCode.Alpha3))
            {
                BoomTimer = BoomCOOL_TIME;

                Debug.Log("�ʻ�� ��ź����");

                GameObject boom = Instantiate(BoomPrepre);
                //boom.transform.position = Vector2.zero;
                //boom.transform.position = new Vector2(0 ,0);
                //boom.transform.position = new Vector2(0 ,1.6f);
            }
        }


        bool ready = (AutMode || Input.GetKeyDown(KeyCode.Space));
        if (Timer <= 0 && ready)
        {
                //GameObject bullet2 = Instantiate(BulletPrefab);
                //bullet2.transform.position = Muzzle2.transform.position;
                //��ǥ �ѱ���ŭ �Ѿ��� ����� ���� �Ѿ��� ��ġ�� �� �ѱ��� ��ġ�� �ٲ۴�.
                //1�� Ű�� �ڵ� ���� ��� / 2�� Ű �� ���� ���� ���
                Timer = COOL_TIME;
                FireSource.Play();
                for (int i = 0; i < Muzzles.Length; i++)
                {
                    // �Ѿ��� ����� 
                    GameObject bullet = Instantiate(BulletPrefab);
                    // ��ġ�� �����Ѵ�
                    bullet.transform.position = Muzzles[i].transform.position;
                }
                //�����Ѿ� 
                for (int i = 0; i < Muzzles_serve.Length; i++)
                {
                    // �Ѿ��� ����� 
                    GameObject bullet = Instantiate(BulletPrefab_serve);
                    // ��ġ�� �����Ѵ�
                    bullet.transform.position = Muzzles_serve[i].transform.position;
                }

        }


    }
}
