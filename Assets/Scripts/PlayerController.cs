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
        //MyVector pos = new MyVector(1.0f, 0.0f, 0.0f);
        //pos += new MyVector(0.0f, 2.0f, 0.0f);

        Managers.Input.KeyAction -= OnKeyBorad;  // 혹시라도 다른 부분에서 OnKeyBoard를 구독했다면 OnKeyBoard가 두번 호출되므로 그걸 방지하기 위해 우선 구독 취소
        Managers.Input.KeyAction += OnKeyBorad;  // KeyAction에 OnKeyBoad 구독신청, 어떤 Key가 눌러지면 OnKeyBoard 함수를 실행


    }

    void Update()   
    {


    }

    void OnKeyBorad()
    {
        //transform.rotation

        // 절대 회전값을 지정해서 이동시킴
        // transform.eulerAngles = new Vector3(0.0f, _yAngle, 0.0f);  // eulerAngles는 3개 요소를 한번에 다 넣어주도록 문서에 명시되어 있음.
        // (0.0f, Time.deltaTime * 100.0f, 0.0f) 처럼 쓰면 에러날수 있음 
        // +- delta 값을 특정 축을 중심으로 회전시킴
        //transform.Rotate(new Vector3(0.0f, Time.deltaTime * 100.0f, 0.0f));

        //transform.rotation =  Quaternion.Euler(new Vector3(0.0f, _yAngle, 0.0f));  // Quaternion.Euler는 벡터를 입력하면 Quaternion으로 변환해줌

        if (Input.GetKey(KeyCode.W))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.forward);  // 캐릭터가 월드 좌표 기준의 forward를 바라봄
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.1f);
            //transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);   // new Vector3(0.0f, 0.0f, 1.0f) -> Vector3.forward 예약어를 사용하면 가독성이 더 좋음
            // TransformDirection()은 캐릭터가 바라보는 방향으로 이동하는 것이기 때문에 Quaternion.Slerp와 사용하면 부자연스럽게 곡선을 그리며 움직인다.
            // 이때는 월드 좌표 기준으로 이동하도록 수정해주면 좀 더 자연스럽게 보일 수 있다.
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.back);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.1f);
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed);  // 시간 * 속력 = 거리
            transform.position += Vector3.back * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.left);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.left), 0.1f);
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            transform.position += Vector3.left * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.right);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.right), 0.1f);
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed);
            transform.position += Vector3.right * Time.deltaTime * _speed;
        }
    }
}
