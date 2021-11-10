using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    // 일반적인 C# 클래스로 사용하고 싶으면 MonoBehaviour를 삭제
    // Component로 들어가 있을때만 Unity가 Start와 Update를 호출해 줌.
    // 일반적인 클래스를 만들면 Start와 Update가 호출되지 않음 

    // 게임이 시작되는 시점에서 매니저의 초기화 함수를 불러서 초기화 작업을 해야함
    // Unity 엔진에서는 Main 함수가 숨겨져 있는 문제가 있음
    // Scene에 배치하는 게임 Object는 꼭 실체가 있을 필요가 없음
    // 빈 GameObject를 만들어서 Scene에 배치하고 MonoBehaviour를 상속한 Manager를 붙이면 됨

    // 결국에는 네트워크, 사운드, UI, Scene 관리 등 많은것이 들어갈 예정

    // Singleton 패턴
    static Managers s_instance; // 유일성이 보장된다
    //public static Managers GetInstance() { Init(); return s_instance; }  // 유일한 매니저를 가지고 온다

    // 프로퍼티로 변경
    public static Managers Instance
    {
        get 
        {
            Init();   // Instance를 호출할때마다 Init() 메서드 호출하지만 s_instance가 null이 아니라면 바로 빠져나옴
            return s_instance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // 초기화
        //Instance = this;   // 이렇게 하면 처음 @Managers 컴포넌트가 실행될때 Instance에 Managers 가 할당되지만
        // @Managers 객체가 여러개 있다면 객체별로 Managers Script를 들고있기 때문에 Instance를 계속 덮어쓰는 문제가 있음 


        //GameObject go = GameObject.Find("@Managers");  // 이렇게 하면 여러 @Managers 객체가 호출해도 전역에 저장되는건 @Managers 원본 객체가 된다. 
        //Instance = go.GetComponent<Managers>();        // GameObject를 이름으로 찾는건 부하가 심하기 때문에 자주 사용하면 안됨
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
            GameObject go = GameObject.Find("@Managers");  // 이렇게 하면 여러 @Managers 객체가 호출해도 전역에 저장되는건 @Managers 원본 객체가 된다. 
            if(go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            // Manager GameObject는 중요해서 삭제하거나 수정하기를 원하지 않음. 
            // DontDestroyOnLoad를 사용하면 GameObject가 왠만해서는 삭제되지 않음 
            DontDestroyOnLoad(go);
            s_instance = go.GetComponent<Managers>();        // GameObject를 이름으로 찾는건 부하가 심하기 때문에 자주 사용하면 안됨
        }

    }
}
