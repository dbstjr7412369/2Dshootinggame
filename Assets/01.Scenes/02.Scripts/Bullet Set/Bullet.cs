using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum BulletType//�Ѿ� Ÿ�Կ� ���� ������(����� ����ϱ� ���� �ϳ��� �̸����� �׷�ȭ�ϴ� ��)
{
    Main = 0,  //�����ص� 0���� ���
    Sub,
    Pet 
}

public class Bullet : MonoBehaviour
{
    public int BTye = 0; //0�̸� ���Ѿ�, 1�̸� �����Ѿ� 2�� ���� ��� �Ѿ�
    //public BulletType BType = BulletType.Main;
    // ��ǥ: �Ѿ��� ���� ��� �̵��ϰ� �ʹ�.
    // �Ӽ�: �ӷ�
    // ���� ����
    //1. �̵��� ������ ���Ѵ�
    //2. �̵��Ѵ�

    public float Speed;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        
        transform.Translate (Vector2.up * Speed * Time.deltaTime);//Translate�� �� ������� �ʴ� ���� ����
        
        //1. �̵��� ������ ���Ѵ�

        //Vector2 dir = Vector2.up;

        //2. �̵��Ѵ�
        //transform.Translate(Vector2.up * Speed * Time.deltaTime);

        //���ο� ��ġ = ������ġ * �ӵ� * �ð�
        //transform.position += 
    }

}
    
        


