using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float Health = 3f;// ���� 35�� ĸ��ȭ�� public���� private���� ����
    public AudioSource AudioSource;

    public void AddHealth(int healthAmount)// ĸ��ȭ
    {
        if  (healthAmount <= 0) 
        {
            return;
        }

        Health += healthAmount;
    }

    public void DecreaseHealth(int healthAmount)// ĸ��ȭ
    {
        if (healthAmount <= 0)
        {
            return;
        }

        Health -= healthAmount;

        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }



    private void Start()
    {
        //GetComponent<������Ʈ Ÿ��>(); -> ���� ������Ʈ�� ������Ʈ�� �������� �޼ҵ�
        //SpriteRenderer sr = GetComponent<SpriteRenderer>();
        //sr.color = Color.white;
        //  Transform tr = GetComponent <Transform>();
        // tr.position = new Vector2(0f, -2.7f);
        //transform.position = new Vector2(0f, -2.7f);

        //PlayerMove playerMove = GetComponent <PlayerMove>();
        //Debug.Log(playerMove.Speed);
        //playerMove.Speed = 5f;
        //Debug.Log(playerMove.Speed);
        // �ڵ�� ����Ƽ�� �ִ� ������ ���� �����ϴ�
    }

    public float GetHealth()// ĸ��ȭ
    {
        return Health;
    }

    public void SetHealth(float health)// ĸ��ȭ
    {
        Health = health;
    }

    public void AddHealth()
    {
    
    }
  
}
