using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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

    // ��ǥ: �¾ �� Ǯ���ٰ� �Ѿ��� (Ǯ ������)�� �����Ѵ�.
    // �Ӽ�:
    // - Ǯ ������ 
    public int PoolSize = 20;//(Ǯ ������)�� 20�� ����
    // - ������Ʈ Ǯ(�Ѿ�) Ǯ
    public List<GameObject>_bulletPool =null;//����Ʈ ���� 0�̳� ���� �������� ǥ�÷� null�� �Ϻη� ���� null�� ������ ���� ����
    //����
    // 1. �¾ ��
    private void Awake()
    {
        // 2. ������Ʈ Ǯ �Ҵ����ְ�
        _bulletPool = new List<GameObject>();

        // 3. �Ѿ� ���������κ��� �Ѿ��� Ǯ �����ŭ �������ش�
        for (int i = 0; i < PoolSize; i++) 
        {
            GameObject bullet = Instantiate(BulletPrefab);
            //bullet.SetActive(false);//��ġ�� �������
            // 4. ������ �Ѿ��� Ǯ���ٰ� �ִ´�
            _bulletPool.Add(bullet);

            bullet.SetActive(false);//������Ʈ�� ����
        }
    }
    

    [Header("�ѱ�����")]
    //public GameObject[] Muzzles;      // �迭�� �ѱ�
    public List<GameObject>Muzzles;// �迭�� ����Ʈ�� ���� Array�� �� ��� ���� ��������� ���� ��쿡�� ���

    [Header("�����ѱ�����")]
    //public GameObject[] Muzzles_serve;      // �迭�� �����ѱ�
    public List<GameObject> Muzzles_serve;// �迭�� ����Ʈ�� ���� Array�� �� ��� ���� ��������� ���� ��쿡�� ��� 


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
                FireSource.Play();
                Timer = COOL_TIME;// Ÿ�̸� �ʱ�ȭ




                //// ��ǥ �ѱ� ������ŭ �Ѿ��� Ǯ���� ��������
                ////����
                ////1.���� �ִ�(��Ȱ��ȭ) �Ѿ��� ã�Ƽ� ������(Ȱ��ȭ).
                //GameObject bullet = null;
                //foreach(GameObject b in _bulletPool)
                //{
                //   if (b.activeInHierarchy == false) 
                //   { 
                //       bullet = b;
                //       break;// ã�ұ� ������ �� �ڱ��� ã�� �ʿ䰡 ����
                //   }
                //}
                ////2. ���� �Ѿ��� ��ġ�� �� �ѱ��� ��ġ�� �ٲ۴�
                //bullet.transform.position = Muzzles[i].transform.position;
                ////3. �Ѿ��� Ų�� (�߻��Ѵ�)
                //bullet.SetActive(true);







                for (int i = 0; i < Muzzles.Count; i++)//List�� ��������Ƿ� Length ��� Count�� ����
                {
                   GameObject bullet = null;
                   foreach (GameObject b in _bulletPool)
                   {
                       if (b.activeInHierarchy == false)
                       {
                           bullet = b;
                           break;// ã�ұ� ������ �� �ڱ��� ã�� �ʿ䰡 ����
                       }
                   }
                    //2. ���� �Ѿ��� ��ġ�� �� �ѱ��� ��ġ�� �ٲ۴�
                    bullet.transform.position = Muzzles[i].transform.position;
                    //3. �Ѿ��� Ų�� (�߻��Ѵ�)
                    bullet.SetActive(true);

                     //// �Ѿ��� ����� 
                     //GameObject bullet = Instantiate(BulletPrefab); 
                     //// ��ġ�� �����Ѵ�
                     //bullet.transform.position = Muzzles[i].transform.position;
                }
                //�����Ѿ� 
                for (int i = 0; i < Muzzles_serve.Count; i++)//List�� ��������Ƿ� Length ��� Count�� ����
                {
                    // �Ѿ��� ����� 
                    GameObject bullet = Instantiate(BulletPrefab_serve);
                    // ��ġ�� �����Ѵ�
                    bullet.transform.position = Muzzles_serve[i].transform.position;
                }

        }


    }
}
