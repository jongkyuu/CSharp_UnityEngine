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

    // Start is called before the first frame update
    void Start()
    {
        // 초기화
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
