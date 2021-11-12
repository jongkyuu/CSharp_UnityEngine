using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 1. 위치벡터
// 2. 방향벡터
struct MyVector
{
    public float x;
    public float y;
    public float z;

    // 거리 구할때 magnitude 사용
    public float magnitude
    { 
        get { return  Mathf.Sqrt(x*x + y*y + z*z); }  // 피타고라스 정리 활용
    }

    // magnitude와 방향은 같고 크기가 1인 벡터
    // normalized에 거리만큼의 크기를 곱해주면 그 방향으로 크기만큼 이동
    public MyVector normalized
    {
        get { return new MyVector(x / magnitude, y / magnitude, z / magnitude); }
    }
       
    public MyVector(float x, float y, float z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public static MyVector operator +(MyVector a, MyVector b)
    {
        return new MyVector(a.x + b.x, a.y + b.y, a.z + b.z);
    }
    public static MyVector operator -(MyVector a, MyVector b)
    {
        return new MyVector(a.x - b.x, a.y - b.y, a.z - b.z);
    }

    public static MyVector operator *(MyVector a, float d)
    {
        return new MyVector(a.x * d, a.y * d, a.z * d);
    }

}
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

        MyVector to = new MyVector(10.0f, 0.0f, 0.0f);  // 목적지
        MyVector from = new MyVector(5.0f, 0.0f, 0.0f);  // 현재위치
        MyVector dir = to - from;  // (5.0f, 0.0f, 0.0f)

        MyVector normalizedDir = dir.normalized;  // (1.0f, 0.0f, 0.0f)

        MyVector newPos = from + normalizedDir * _speed;

        // 방향 벡터
        //   1. 거리(크기)
        //   2. 실제 방향
    }

    // 최상단에 GameObject(Player)
    // Transform
    // PlayerController (*)
    void Update()   
    {
        // 한 Frame당 호출되는 함수
        // 60Frame의 게임이라면 1/60초 마다 Update함수가 실행되므로 너무 빠르게 이동하게 된다
        // 이전 Frame과 지금 Frame의 시간 차이를 구하고 그걸 활용해서 이동속도를 조절해야 한다
        
        // Local -> World 좌표를 변환
        // transform.TransformDirection() 
        // World -> Local 좌표 변환
        // transform.InverseTransformDirection()
        // transform.Translate() 사용해도 됨. 이건 로컬을 기준으로 계산해준다

        // 게임수학을 공부해서 행렬을 이용해서 좌표계산을 할 수도 있음 


        if (Input.GetKey(KeyCode.W))
            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);   // new Vector3(0.0f, 0.0f, 1.0f) -> Vector3.forward 예약어를 사용하면 가독성이 더 좋음
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * Time.deltaTime * _speed);  // 시간 * 속력 = 거리
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime * _speed);


        // transform.gameObject : 부모인 GameObject에 접근
        // transform. : transform에 접근

    }
}
