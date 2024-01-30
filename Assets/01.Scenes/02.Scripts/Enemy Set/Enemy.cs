using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Hardware;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using static Unity.VisualScripting.Member;
using static UnityEditor.Progress;
public enum EnemyType// �� Ÿ�� ������
{
    Basic,
    Target,
    Follow
}
public class Enemy : MonoBehaviour
{


    // ��ǥ ���� �Ʒ��� �̵���Ű�� �ʹ�
    // �Ӽ�:
    // - �ӷ�
    public float EnemySpanwer = 1f;
    public float Health_Enemy = 2f;
    public float Speed = 3f;// �̵��ӵ� : �ʴ� 3��ŭ �̵��ϰڴ�.
    [Header("������")]
    public GameObject Item_HealthPrefab;
    public GameObject Item_SpeedPrefab;
    private  GameObject PlayerMovePrefab;

    public Animator MyAnimator;//�ִϸ��̼� 

    // BasicŸ�� �Ʒ��� �̵�
    // Target ó���¾�� �� �÷��̾ �ִ� �������� �̵�
    // �Ӽ� 
    // EnemyType Ÿ��
    // ���� ����:
    // 2. ������ ���� �̵��Ѵ�

    public EnemyType EnemyType;

    private Vector2 _dir;

    private GameObject _target;// GameObject target = GameObject.Find("Player")�� ������Ʈ�� �������� �����͸� ���� �Һ�� ����ȭ�� ���� �ʾ� �̷������� �۵��ϴ� ��

    public EnemyType ETpe { get; private set; }

    public AudioSource audioManger;

    public GameObject ExplosionVFXPrepre;
    private void Start()
    {
        //ĳ�� ���� ���� �����͸� �� ����� ��ҿ� �����صΰ� �ʿ��� �� ������ ���� ��
        // ������ �� �÷��̾ ã�Ƽ� ����صд�.


       _target = GameObject.Find("Player");
        MyAnimator = GetComponent<Animator>();
        GameObject i = GameObject.Find("audioManager");
        audioManger = i.GetComponent<AudioSource>();     

            if (EnemyType == EnemyType.Target )
            {
             //1.������ �� ������ ���Ѵ�(�÷��̾ �ִ� ����)
             //1-1 �÷��̾ ã�´�
             // GameObject target = GameObject.Find("Player");
             //GameObject.Find= GameObjectWithTag("Player");

             // 1-2 ������ ���Ѵ�(target - me)
               _dir = _target.transform.position - this.transform.position;
               _dir.Normalize();

             //1�� ������ ���Ѵ�
             //tan@ = y/x -> @ = y/x*atan
             float radian = Mathf.Atan2(_dir.y, _dir.x);
             Debug.Log(radian);//ȣ���� -> ���� ��
             float degree =radian *Mathf.Rad2Deg;
             //@ = y / x * atan
             Debug.Log($"{degree}");

             transform.rotation = Quaternion.Euler(new Vector3(0, 0, degree + 90));// �̹��� ���ҽ��� �°� 90���� ���Ѵ�.
             //transform.eulerAngles = new Vector3(0, 0, degree + 90);// �� �ڵ�� �� �ڵ�ε� �����ϴ�
            //transform.LookAt(_target.transform); 3d���� ���ֻ�� 2d������ ����� ���� ����
            }
            else
            {
               _dir = Vector2.down;
            }                 
    }
  
    void Update()
    {
        //���� ���� 
        // 1 ���ⱸ�ϱ�
        // Vector2 dir = new Vector2(0, -1);
        //transform.Translate(Vector2.down * Speed * Time.deltaTime);
        // 2 �̵���Ų��.
        //transform.Translate(Vector2.down * Speed * Time.deltaTime);

        transform.position += (Vector3)(_dir * Speed) * Time.deltaTime;
        if (EnemyType == EnemyType.Follow)
        {
           
            //1.������ �� ������ ���Ѵ�(�÷��̾ �ִ� ����)
            //1-1 �÷��̾ ã�´�
            // GameObject target = GameObject.Find("Player");
            //GameObject.Find= GameObjectWithTag("Player");

            // 1-2 ������ ���Ѵ�(target - me)
            _dir = _target.transform.position - this.transform.position;
            _dir.Normalize();
        }

        if (EnemyType == EnemyType.Follow)
        {
            
            _dir = _target.transform.position - this.transform.position;
            _dir.Normalize();


            float radian = Mathf.Atan2(_dir.y, _dir.x);
            Debug.Log(radian);//ȣ���� -> ���� ��
            float degree = radian * Mathf.Rad2Deg;

            Debug.Log($"{degree}");

            transform.rotation = Quaternion.Euler(new Vector3(0, 0, degree + 90));// �̹��� ���ҽ��� �°� 90���� ���Ѵ�.


        }
        
    }
    // ��ǥ �浹�ϸ� ���� �÷��̾ �����ϰ� �ʹ�
    // ���� ���� 
    // ���� �浹�� �Ͼ�� 
    // ���� �÷��̾ �����Ѵ�
    // �浿�� �Ͼ�� ȣ��Ǵ� �̺�Ʈ �Լ�
    // Enter Stay Exit
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //MyAnimator.SetInteger("a", (int)a);// int ����ȯ
        //MyAnimator.SetInteger("b", (int)b);// int ����ȯ
        //MyAnimator.SetInteger("c", (int)c);// int ����ȯ

        //�浹�� �������� ��
        Debug.Log("Enter");
        // �浹�� ���ӿ�����Ʈ�� �±׸� Ȯ��
        Debug.Log(collision.collider.tag);//Player or Bullet
                                          //2.�浹�� �ʿ� ���� ����
                                          // ���װ�(�÷��̾�)
        

        // ������(�� �ڽ�)
        //if (collision.collider.tag == "Player")
        if (collision.collider.CompareTag ("Player"))
        {
            Destroy(gameObject);
            //�÷��̾� ��ũ��Ʈ��  �����´�
            Player player = collision.collider.GetComponent<Player>();
            //�÷��̾� ü���� -= 1
            player.DecreaseHealth(1);

            //�÷��̾� ü���� ���ٸ�
            //if (player.GetHealth() <= 0)
            //{
                // ���װ�
               //Destroy(collision.collider.gameObject);
            //}
                Kill();
            
        }
        //else if (collision.collider.tag == "Bullet")
        else if (collision.collider.CompareTag ("Bullet"))
        {
            Bullet bullet = collision.collider.GetComponent<Bullet>();
            //�Ѿ��� ü���� 2�� �� �� ���Ѿ��� 0 ���� �Ѿ��� 1�� �����ϰ� ���� �浹�ؾ��Ѵ�.
            if (bullet.BTye == 0)
            {

                Health_Enemy -= 2;
                Debug.Log(Health_Enemy);
                Destroy(collision.gameObject);
            }
            if (bullet.BTye == 1)
            {
           
                Health_Enemy -= 1;
                Debug.Log(collision.gameObject);
                Destroy(collision.gameObject);
            }
            // �浹�� �ʿ� ���� �����Ѵ�
            //�Ҹ� ��ũ��Ʈ�� ��������
            if (Health_Enemy <= 0)
            {
               
                Debug.Log(Health_Enemy);
                //Main = 0,  //�����ص� 0���� ���
                //Sub = 1,
                //Pet = 2
                // ������
                Kill();
                //audioManger.Play();

                // ��ǥ 50 Ȯ���� ü�� �÷��ִ� ������ ������ ���� �̵��ӵ� �÷��ִ� ������
                if (Random.Range(0, 2) == 0)
                {
                    // ������ �����
                    GameObject item = Instantiate(Item_HealthPrefab);

                    // ��ġ�� ���� ��ġ�� ����
                    item.transform.position = this.transform.position;//this�� �ڽ��̶�� ���̴� �� Enemy��� ��
                }
                else if (Random.Range(0, 2) == 1)
                {

                    GameObject item_speed = Instantiate(Item_SpeedPrefab);
                    item_speed.transform.position = this.transform.position;
                }

            }
            else
            {

                    MyAnimator.Play("Hit");
                
                    //MyAnimator.Play("Hit",-1, 2)

            }
            // �Ѿ� ���� 
            //Destroy(collision.collider.gameObject);
            collision.collider.gameObject.SetActive(false);
        }
        
    }
    private void OnCollisionStay2D(Collision2D collisio)
    {
        //�浹 ���� �� �Ź�
        Debug.Log("Stay");
    }
    private void OnCollisionExit2D(Collision2D collisio)
    {

        // �浹�� ������ ��
      
        Debug.Log("Exit");
    }



    public void Kill()
    {

        Destroy(this.gameObject);
        GameObject vfx = Instantiate(ExplosionVFXPrepre);
        vfx.transform.position = this.transform.position;

        // ��ǥ ���� ���� �� ���� ������ �ø���, ���������� UI�� ǥ���ϰ� �ʹ�
        // �������� 
        // ���࿡ ���� ������?
        // ���ھ ������Ų��
        // ������ SocoeManager ���� ������Ʈ�� ã�ƿ´�
        //GameObject smgameObject = GameObject.Find("ScoreManager");
        // SocorManager ���ӿ�����Ʈ���� SocoeManager ��ũ��Ʈ ������Ʈ�� ���´�

        //ScoreManager scoreManager = smgameObject.GetComponent<ScoreManager>();
        // ������Ʈ��Socoe �Ӽ��� ������Ų��


        //ĸ��ȭ ��ģ �ڵ� ���� �����Բ� �����
        // �̱��� ��ü ������ ����
        //ScoreManager.Instance.AddScore();
        //int score = scoreManager.GetScore();
        //scoreManager.SetScore(score += 1);
        //Debug.Log(scoreManager.GetScore());


        //int curentScore = ScoreManager.Instance Instance,GetScore();
        //ScoreManager.Instance.SetScore(currentScore +1);

        ScoreManager.Instance. Score +=1;



        //// ��ǥ ���ھ ȭ�鿡 ǥ���Ѵ�
        //scoreManager.ScoreTesxtUI.text = $"����: {scoreManager.Score}";

        //// ��ǥ �ְ� ������ �����ϰ� UI�� ǥ���Ѵ�
        //GameObject.Find("ScoreManager1");
        //ScoreManager scoreManager1 = smgameObject.GetComponent<ScoreManager>();


        ////��ǥ �ְ� ������ �����ϰ� UI�� ǥ��

        ////���� ���������� �ְ� �������� ���ٸ�
        //if (scoreManager.Score > scoreManager.BastScore)
        //{
        //    //�ְ������� �����ϰ�
        //    scoreManager.BastScore = scoreManager.Score;

        //    // ��ǥ: �ְ������� ����
        //    //'PlayerPrefs'Ŭ������ ��� ȯ�漳���̶�� ��
        //    //-> ���� Ű(Key)�� '��'(Value) ���·� �����ϴ� Ŭ�����Դϴ�
        //    // ������ �� �ִ� ������ Ÿ��: int, float, string
        //    // Ÿ�Ժ��� ����/�αװ� ������ Set/Get �޼��尡 �ִ�.

        //    PlayerPrefs.SetInt("BastScore", scoreManager.BastScore);
        //    //���� �����Ͱ� ���� �� �������� ������ �Ұ���

        //    //UI�� ǥ���Ѵ�
        //    scoreManager.BastScoreTesxtUI.text = $"�ְ� ����: {scoreManager.Score}";
        //}
        // ��°�� ScoreManger�� �ű� �� ����

    }
}
