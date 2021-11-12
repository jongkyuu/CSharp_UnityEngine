using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public을 붙여 주면 에디터에서 해당 변수를 조절할 수 있음
    // 외부에 노출시키고 싶지 않다면 [SerializeField] Attibute를 달아주면 된다

    [SerializeField]
    float _speed = 10.0f;

    void Start()
    {
        
    }

    // 최상단에 GameObject(Player)
        // Transform
        // PlayerController (*)
    void Update()   
    {
        // 한 Frame당 호출되는 함수
        // 60Frame의 게임이라면 1/60초 마다 Update함수가 실행되므로 너무 빠르게 이동하게 된다
        // 이전 Frame과 지금 Frame의 시간 차이를 구하고 그걸 활용해서 이동속도를 조절해야 한다
        
        // transform.TransformDirection() 사용하면 로컬좌표에서 월드좌표로 계산을 해준다
        // 게임수학을 공부해서 행렬을 이용해서 좌표계산을 할 수도 있음 
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);   // new Vector3(0.0f, 0.0f, 1.0f) -> Vector3.forward 예약어를 사용하면 가독성이 더 좋음
        if (Input.GetKey(KeyCode.S))
            transform.position += transform.TransformDirection(Vector3.back * Time.deltaTime * _speed);  // 시간 * 속력 = 거리
        if (Input.GetKey(KeyCode.A))
            transform.position += transform.TransformDirection(Vector3.left * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.D))
            transform.position += transform.TransformDirection(Vector3.right * Time.deltaTime * _speed);


        // transform.gameObject : 부모인 GameObject에 접근
        // transform. : transform에 접근

    }
}
