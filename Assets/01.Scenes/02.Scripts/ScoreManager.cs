using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine. UI;




/*������ ����: �������� ����Ʈ���� ���� �������� �߰ߵ� ���� ���Ͽ쿡
               �̸��� �ٿ� ���� �ϱ� ���� ���·� ���� ������ ��

 ���� 
-���� ���� ������ �˰� ���� �� �ǻ������ �ߵȴ�.(���� ���� ��Ģ Ư�� ����)
-��� ����̹Ƿ� ������/ ��������/Ȯ�强/ �ŷڼ� /���

 ����
-����� ���� (�Ẹ�� ���� ������ ������ ����)
-�ʱ⿡ �н���� �ִ� (ó�� ���뿡 �ð��� ���)

-�˸� ���� ���� 5�� / �̱���/ ������Ʈ Ǯ /���� /������/ ���丮
 


 */




public class ScoreManager : MonoBehaviour
{
    // ��ǥ ���� ���� �� ���� ������ �ø���, ���������� UI�� ǥ���ϰ� �ʹ�
    // �ʿ� �Ӽ� 
    // ���������� ǥ���� UI
    public Text ScoreTesxtUI;
    // ���� ������ ����� ����
    private int _score = 0;
    // ���������� ǥ���� UI
    public Text BastScoreTesxtUI;
    // ���� ������ ����� ����
    public int BastScore = 0;

    public int Score
    {
        get
        {

            return _score;
        }
        set
        {
            if (value < 0)
            {
                return;

            }
            _score = value;


            // ��ǥ ���ھ ȭ�鿡 ǥ���Ѵ�
            ScoreTesxtUI.text = $"����: {_score}";

            // ��ǥ �ְ� ������ �����ϰ� UI�� ǥ���Ѵ�
            GameObject.Find("ScoreManager1");
            ScoreManager scoreManager1 = GetComponent<ScoreManager>();


            //��ǥ �ְ� ������ �����ϰ� UI�� ǥ��

            //���� ���������� �ְ� �������� ���ٸ�
            if (_score > BastScore)
            {
                //�ְ������� �����ϰ�
                BastScore = _score;

                // ��ǥ: �ְ������� ����
                //'PlayerPrefs'Ŭ������ ��� ȯ�漳���̶�� ��
                //-> ���� Ű(Key)�� '��'(Value) ���·� �����ϴ� Ŭ�����Դϴ�
                // ������ �� �ִ� ������ Ÿ��: int, float, string
                // Ÿ�Ժ��� ����/�αװ� ������ Set/Get �޼��尡 �ִ�.

                PlayerPrefs.SetInt("BastScore", BastScore);
                //���� �����Ͱ� ���� �� �������� ������ �Ұ���

                //UI�� ǥ���Ѵ�
                BastScoreTesxtUI.text = $"�ְ� ����: {_score}";
            }
        }
    }

    // ScoreManager�� ������ �����ϴ� ������ �Ŵ��� (������)�̹Ƿ� �̱����� �����ϴ°� ����
    public static ScoreManager Instance { get; set; }// ScoreManager ��ü / get; private set���ε� ��°���

    private void Awake()
    {

        Debug.Log("ScoreManager ��ü�� Awakeȣ��");
        // �̱��� ����: ���� �Ѱ��� Ŭ���� �ν��Ͻ��� ������ �����ϰ�, 
        // �������� �������� �����Ѵ�(�ƹ������� ���� �� �ϳ��� ��ü�� ���� ����)

        // �������
        // ���� ���߿��� �Ŵ���/ ������ Ŭ������ �̱��� ������ �ۿ��ϴ� ���� �Ϲ����� ����
        //- ��������, �ڵ� �ܼ�ȭ (�ش� �����ڸ� ã������ ������ ������ �ʿ� ����.)
        //- �ߺ� �������� (�޸� �� ���ҽ� �����ɷ� ���)

        if (Instance == null)
        {

            Debug.Log("���� ������ ���̴�!");
            Instance = this;
        }
        else
        {
            Debug.Log("�̹� �ִ�");
            Destroy(gameObject);
        }
    }
    // ������Ʈ�� �ø� �� �̹� �־� ������Ʈ�� �����ȴ�



    // ��ǥ: ������ ������ �� �ְ� ������ �ҷ����� UI�� �i���ϰ� �ʹ�
    // ��������
    // ������ ������ ��
    private void Start()
    {
        // �ְ� ������ �ҷ��´�
        BastScore = PlayerPrefs.GetInt("BastScore", 0);
        // UI�� ǥ���Ѵ�
        BastScoreTesxtUI.text = $"�ְ� ����:{BastScore}";

    }









    // ��ǥ ���� ���� �� ���� ������ �ø���, ���������� UI�� ǥ���ϰ� �ʹ�
    // �������� 
    // ���࿡ ���� ������?
    // ���ھ ������Ų��
    // ���ھ ȭ�鿡 ǥ���Ѵ�
    // ��ǥ ���� ���� �� ���� ������ �ø���, ���������� UI�� ǥ���ϰ� �ʹ�
    // �������� 
    // ���࿡ ���� ������?
    // ���ھ ������Ų��
    // ������ SocoeManager ���� ������Ʈ�� ã�ƿ´�
    //GameObject smgameObject = GameObject.Find("ScoreManager");
    //// SocorManager ���ӿ�����Ʈ���� SocoeManager ��ũ��Ʈ ������Ʈ�� ���´�
    //ScoreManager scoreManager = smgameObject.GetComponent<ScoreManager>();
    //// ������Ʈ��Socoe �Ӽ��� ������Ų��
    //scoreManager.Score += 1;
    //    Debug.Log(scoreManager.Score);

    //    // ��ǥ ���ھ ȭ�鿡 ǥ���Ѵ�
    //    scoreManager.ScoreTesxtUI.text = $"����: {scoreManager.Score}";


    // ��ǥ score �Ӽ��� ���� ĸ��ȭ (get/set)

    public int GetScore()
    {
        return _score;
    }

    public void AddScore()
    {
        SetScore(_score + 1);
    }

    public void SetScore(int score)
    {
        // ��ȿ�� �˻�
        if (score < 0)
        {
            return;
        }

        _score = score;

        //// ��ǥ ���ھ ȭ�鿡 ǥ���Ѵ�
        //ScoreTesxtUI.text = $"����: {_score}";

        //// ��ǥ �ְ� ������ �����ϰ� UI�� ǥ���Ѵ�
        //GameObject.Find("ScoreManager1");
        //ScoreManager scoreManager1 = GetComponent<ScoreManager>();


        ////��ǥ �ְ� ������ �����ϰ� UI�� ǥ��

        ////���� ���������� �ְ� �������� ���ٸ�
        //if (_score > BastScore)
        //{
        //    //�ְ������� �����ϰ�
        //    BastScore = _score;

        //    // ��ǥ: �ְ������� ����
        //    //'PlayerPrefs'Ŭ������ ��� ȯ�漳���̶�� ��
        //    //-> ���� Ű(Key)�� '��'(Value) ���·� �����ϴ� Ŭ�����Դϴ�
        //    // ������ �� �ִ� ������ Ÿ��: int, float, string
        //    // Ÿ�Ժ��� ����/�αװ� ������ Set/Get �޼��尡 �ִ�.

        //    PlayerPrefs.SetInt("BastScore", BastScore);
        //    //���� �����Ͱ� ���� �� �������� ������ �Ұ���

        //    //UI�� ǥ���Ѵ�
        //    BastScoreTesxtUI.text = $"�ְ� ����: {_score}";
        //}

    }
}
