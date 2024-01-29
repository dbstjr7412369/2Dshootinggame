using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class PlayerMove : MonoBehaviour
{
    /*
     ��ǥ �÷��̾ �̵��ϰ� �ʹ�
      �ʿ� �Ӽ�:�ӵ�
    -�̵� �ӵ� 
    ����:
    //1. Ű���� �Է��� �޴´�
    //2. Ű���� �Է¿� ���� �̵��� ������ ����Ѵ�.
    //3. �̵��� ����� �̵��ӵ��� ���� �÷��̾ �̵���Ų��.
     */

    private float Speed = 3f;// �̵��ӵ� : �ʴ� 3��ŭ �̵��ϰڴ�. // ĸ��ȭ�� ����  pubilic���� private���� ����

    public const float MinX = -3f;// �̵��ӵ� : �ʴ� 3��ŭ �̵��ϰڴ�.
    public const float MaxX = 3f;// �̵��ӵ� : �ʴ� 3��ŭ �̵��ϰڴ�.
    public const float MinY = -6f;// �̵��ӵ� : �ʴ� 3��ŭ �̵��ϰڴ�.
    public const float MaxY = 0f;// �̵��ӵ� : �ʴ� 3��ŭ �̵��ϰڴ�.

    public Animator MyAnimator;

    private void Awake()
    {


        MyAnimator = GetComponent<Animator>();//this.gameObject.�� ��������
    }

    //void Start()
    //{

    //}

    // Update is called once per frame
    void Update()//�� �����Ӹ��� ��µǴ� �Լ�
    {
        Move();
        SpeedDown();
    }


    private void Move()
    {
        //transform.Translate/*Ʈ��������. �̵���Ų��*/(Vector2.up * Speed * Time.deltaTime);
        //(0.1)*3 - (0,3)*Time.deltaTime
        //deltaTime�� ������ �� �ð������� ��ȯ�Ѵ�.
        //30fps: d -> 0.03��
        //60fps d -> 0.016ch
        //deltaTime�� ��ǻ�� ��翡 ������� ���� �ӵ��� ����ϱ� ������ �Ź� ����ؾ��Ѵ�.
        // 1 ������ 1m �̴�
        //1. Ű���� �Է��� �޴´�
        //float h = Input.GetAxis("Horizontal");// -1.0f ~ 0f ~ +1.0f ����ϰ� ����Ű �¿츦 ������ ������ -1.0f �������� +1.0f���
        float h = Input.GetAxisRaw("Horizontal");// �����Է°� - -1.0f ~ 0f ~ +1.0f
        //Input.GetAxis = ����ڰ� Ű���峪 ���̽�ƽ ���� �Է� ��ġ���� �Է� ���� �ָ� �ش� �Է� ���� �״�� ��ȯ�մϴ�. �̴� �Է� ���� �ε巴�� �������� �ʰ�, ����ڰ� ���� Ű�� �ﰢ���� ���¸� �ݿ��ϰ��� �� �� ����

        //Debug.Log (h);
        //float v = Input.GetAxis("Vertical");// �����Է°��� �޾ƿ´�(��ǲ�Ŵ��� ����)
        float v = Input.GetAxisRaw("Vertical");// �����Է°� - -1.0f ~ 0f ~ +1.0f
                                               //Debug.Log($"h: {h}, v: {v}");
                                               //2. Ű���� �Է¿� ���� �̵��� ������ ����Ѵ�.
                                               //Vector2 dir = Vector2.right * h + Vector2.up * v;
                                               //(1.0)*h+(0.1)*v = (h, v)
                                               //������ �� �������� ����

        // �ִϸ����Ϳ��� �Ķ���� ���� �Ѱ��ش�
        MyAnimator.SetInteger("h", (int)h);// int ����ȯ


        Vector2 dir = new Vector2(h, v);
       // Debug.Log($"����ȭ �� :{dir.magnitude}");

        //�̵������� ����ȭ(������ ������ ���̸� 1�� �������)
        dir = dir.normalized;
       // Debug.Log($"����ȭ ��:{dir.magnitude}");

        //3. �̵��� ����� �̵��ӵ��� ���� �÷��̾ �̵���Ų��.
        //Debug.Log(Time.deltaTime);
        //transform .Translate (dir * Speed * Time.deltaTime);

        //������ �̿��� �̵�
        //���ο� ��ġ = ���� ��ġ + �ӵ� * �ð� 
        Vector2 newPosition = transform.position + (Vector3)/*����ȯ���� 2���� 3�� �ٲ�*/ (dir * Speed * Time.deltaTime);
        //���ο� ��ġ�� �� �����غ���



      //  Debug.Log($"x:{newPosition.x}, y:{newPosition.y}");
        //newPosition.x = 3;

        //if (newPosition.x < MinX)
        //{
        //    newPosition.x = MinX;
        //}
        //else if (newPosition.x > MaxX)
        //{
        //    newPosition.x = MaxX;
        //}

        if (newPosition.x < MinX)
        {
            newPosition.x = MaxX;
        }
        else if (newPosition.x > MaxX)
        {
            newPosition.x = MinX;
        }

        //newPosition.y = Mathf.Max(MinY, newPosition.y);
        //newPosition.y = Mathf.Min(newPosition.y, MaxY);

        newPosition.y = Mathf.Clamp(newPosition.y, MinY, MaxY);



        //if(newPosition.y < MinY)
        //{
        //    newPosition.y = MinY;
        //}
        //else if(newPosition.y > MaxY)
        //{
        //    newPosition.y = MaxY;
        //}

        transform.position = newPosition;// �÷��̾� ��ġ = ���ο� ��ġ 


        // ������ġ ���
      //  Debug.Log(transform.position);
        //transform.position = new Vector2(0, 1);

        //float h = Input.GetAxisRaw("Horizontal");
        //float v = Input.GetAxisRaw("Vertical");

        //Vector2 dir = new Vector2(h, v);
        //Debug.Log($"����ȭ �� :{dir.magnitude}");

        //dir = dir.normalized;
        //Debug.Log($"����ȭ ��:{dir.magnitude}");

        //Vector2 newPosition = transform.position + (Vector3)/*����ȯ���� 2���� 3�� �ٲ�*/ (dir * Speed * Time.deltaTime);
        //transform.position = newPosition;

        //Debug.Log(transform.position);
    }

    private void SpeedDown()
    {
        //bool q = Input.GetKeyUp("q");
        //bool e = Input.GetKeyDown("e");

        //if (q)
        //{
        //    Speed += 1;
        //    Debug.Log(Speed);
        //}
        //else if (e) 
        //{
        //    Speed -= 1;
        //    Debug.Log(Speed);
        //}

        // ��ǥ: Q/E ��ư�� ������ �ӷ��� �ٲٰ� �ʹ�.
        //�Ӽ�
        // - �ӷ�(Speed)
        // ����:

        // 1. Q/E��ư �Է��� �Ǵ��Ѵ�.
        if (Input.GetKeyDown(KeyCode.Q))
        //2. Q��ư�� ���ȴٸ� ���ǵ� 1 �ٿ�
        {
            Speed++;
        }
        //3. E��ư�� ���ȴٸ� ���ǵ� 1 ��
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Speed--;
        }
    }

    public float GetSpeed()// ĸ��ȭ
    {
        return Speed;
    }

    public void SetSpeed(float speed)// ĸ��ȭ
    {
        Speed = speed;
    }

    public void AddSpeed(float speed)// ĸ��ȭ
    {
        Speed += speed;
    }
}
