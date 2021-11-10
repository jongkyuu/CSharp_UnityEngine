using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    // �Ϲ����� C# Ŭ������ ����ϰ� ������ MonoBehaviour�� ����
    // Component�� �� �������� Unity�� Start�� Update�� ȣ���� ��.
    // �Ϲ����� Ŭ������ ����� Start�� Update�� ȣ����� ���� 

    // ������ ���۵Ǵ� �������� �Ŵ����� �ʱ�ȭ �Լ��� �ҷ��� �ʱ�ȭ �۾��� �ؾ���
    // Unity ���������� Main �Լ��� ������ �ִ� ������ ����
    // Scene�� ��ġ�ϴ� ���� Object�� �� ��ü�� ���� �ʿ䰡 ����
    // �� GameObject�� ���� Scene�� ��ġ�ϰ� MonoBehaviour�� ����� Manager�� ���̸� ��

    // �ᱹ���� ��Ʈ��ũ, ����, UI, Scene ���� �� �������� �� ����

    // Singleton ����
    static Managers s_instance; // ���ϼ��� ����ȴ�
    //public static Managers GetInstance() { Init(); return s_instance; }  // ������ �Ŵ����� ������ �´�

    // ������Ƽ�� ����
    public static Managers Instance
    {
        get 
        {
            Init();   // Instance�� ȣ���Ҷ����� Init() �޼��� ȣ�������� s_instance�� null�� �ƴ϶�� �ٷ� ��������
            return s_instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // �ʱ�ȭ
        //Instance = this;   // �̷��� �ϸ� ó�� @Managers ������Ʈ�� ����ɶ� Instance�� Managers �� �Ҵ������
        // @Managers ��ü�� ������ �ִٸ� ��ü���� Managers Script�� ����ֱ� ������ Instance�� ��� ����� ������ ���� 


        //GameObject go = GameObject.Find("@Managers");  // �̷��� �ϸ� ���� @Managers ��ü�� ȣ���ص� ������ ����Ǵ°� @Managers ���� ��ü�� �ȴ�. 
        //Instance = go.GetComponent<Managers>();        // GameObject�� �̸����� ã�°� ���ϰ� ���ϱ� ������ ���� ����ϸ� �ȵ�
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");  // �̷��� �ϸ� ���� @Managers ��ü�� ȣ���ص� ������ ����Ǵ°� @Managers ���� ��ü�� �ȴ�. 
            if(go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            // Manager GameObject�� �߿��ؼ� �����ϰų� �����ϱ⸦ ������ ����. 
            // DontDestroyOnLoad�� ����ϸ� GameObject�� �ظ��ؼ��� �������� ���� 
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();        // GameObject�� �̸����� ã�°� ���ϰ� ���ϱ� ������ ���� ����ϸ� �ȵ�
        }

    }
}
