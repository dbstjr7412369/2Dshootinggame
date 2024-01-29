using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using static UnityEngine.UI.ContentSizeFitter;

public class Item : MonoBehaviour
{
    private float _timer = 0f;//�ð�
    public const float STOP_TIME = 1.0f;

    public int MyType = 0; // 0: ü���� �÷��ش� 1: ���ǵ带 �÷��ش�
    private GameObject _target;
    public float Speed = 3f;
    private Vector2 _dir;
    public GameObject ExplosionVFXItemHeaithPrepre;
    public GameObject ExplosionVFXItemSpeedPrepre;
    Animator MyAnimator;
    // �ٸ� �ݶ��̴��� ���� Ʈ���Ű� �ߵ��� ��


    public void Start()
    {



        MyAnimator = GetComponent<Animator>();
        MyAnimator.SetInteger("ItemType", MyType);


    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collison Enter!");
        //MyAnimator.SetInteger("Itemtype", Itemtype);// int ����ȯ
        //MyAnimator.SetInteger("i2", (int)i2);// int ����ȯ
        //MyAnimator.SetInteger("i3", (int)i3);// int ����ȯ
    }

    //�ٸ� �ݶ��̴��� ���� Ʈ���Ű� �ߵ��� ��
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        Debug.Log("Ʈ���� ����");


        // ���� �÷��̾��� ü���� �ø��� �ʹ�
        // ���� 
        // 
        //GameObject playerGameObjeact = GameObject.Find("Player");
        //Player player = otherCollider.GetComponent<Player>();


        //Player player = otherCollider.gameObject.GetComponent<Player>();//���� ���� �ڵ�鵵 ���� �����̴�

        //player.Health++;
        //Debug.Log($"���� �÷��̾��� ü�� : {player.Health}");



        //if (otherCollider.tag == "Player")
        //{
        //   Player player = otherCollider.GetComponent<Player>();
        //   player.Health += 1.0f;
        //}
        //if (otherCollider.tag == "Player")// ���� ���� �ڵ�
        //{


        //Destroy (this .gameObject);
        //}
    }


    // �ٸ� �ݶ��̴��� ���� Ʈ���Ű� �ߵ� ���� ��
    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        _timer += Time.deltaTime;
        if (_timer >= STOP_TIME)
        {
            if (MyType == 0)
            {
                Player player = otherCollider.gameObject.GetComponent<Player>();
                player.AddHealth(0);
                //ItemSource.Play();
                GameObject vfx = Instantiate(ExplosionVFXItemHeaithPrepre);
                vfx.transform.position = this.transform.position;
            }
            else if (MyType == 1)
            {
                Debug.Log("���ǵ�");
                PlayerMove playermove = otherCollider.gameObject.GetComponent<PlayerMove>();
                //playermove.SetSpeed(+1);
                //ItemSource.Play();
                playermove.AddSpeed(1);// ĸ��ȭ �̿�
                GameObject vfx = Instantiate(ExplosionVFXItemSpeedPrepre);
                vfx.transform.position = this.transform.position;
            }
            Destroy(this.gameObject);
        }

        //Debug.Log("Ʈ���� ��");
    }
    private void Update()
    {
         transform.position += (Vector3)(_dir * Speed) * Time.deltaTime;
        _target = GameObject.Find("Player");
        _timer += Time.deltaTime;
        

        if (_timer >= 3)
        {
            _dir = _target.transform.position - this.transform.position;
            _dir.Normalize();
        }
    }

    // �ٸ� �ݶ��̴��� ���� Ʈ���Ű� ������ ��
    private void OnTriggerExit2D(Collider2D collision)
    {
        _timer = 0f;
        Debug.Log("Ʈ���� ����");
    }
}
