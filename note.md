# Chapter 2

### Singleton 패턴

### Component 패턴

<br>

# Chapter 3

### 변수를 Unity 에디터에서 조정 가능하게 하기

```csharp

// private으로 선언하면 에디터에서 조정할 수 없다
float _speed = 10.0f;

// public으로 선언하면 에디터에서 조정할 수 있다
public float _speed = 10.0f;

// public으로 외부에 노출하고 싶지 않은 변수라면 [SerializeField] Attibute를 달아주면 된다
[SerializedField]
float _speed = 10.0f;

```

### Position

유니티에는 World 좌표와 Local 좌표가 있다. World 좌표는 게임 세계의 절대좌표이고 Local 좌표는 게임 캐릭터가 바라보는 방향을 기준으로 하는 상대 좌표이다.

- Local 좌표를 World 좌표로 변환할 때는 `transform.TransformDirection`를 사용
- World 좌표를 Local 좌표로 변환할 때는 `transform.InverseTransformDirection`를 사용
- `transform.Translate`를 사용해도 Local 좌표를 World 좌표로 변환해준다
- 게임수학을 공부해서 행렬을 이용해서 좌표계산을 할 수도 있음

```csharp

// 캐릭터가 바라보는 Local 좌표를 World 좌표로 변환
// 캐릭터가 바라보는 방향으로 직진하게 된다
transform.position += transform.TransformDirection(Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * _speed)

transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed)

transform.Translate(Vector3.forward * Time.deltaTime * _speed);

// 모두 같은 동작을 하는 코드임
// Time.deltaTime 이전 프레임과 현재 프레임의 시간 간격을 의미. 너무 빠르게 움직이는걸 방지하기 위해 곱해줌

```

### 캐릭터가 너무 빠르게 움직일 때

Update문은 한 Frame당 호출되는 함수이다. 게임이 60 Frame이라면 1/60초 마다 Update 함수가 실행되므로 캐릭터가 너무 빠르게 이동할 수 있다. 그래서 이전 프레임과 현재 프레임의 시간 차이를 구하고 그걸 활요해서 이동속도를 조절해야 한다. 위 코드에서 `Time.deltaTime`은 이전 프레임과 현재 프레임의 시간 간격을 의미한다. 너무 빠르게 움직이는걸 방지하기 위해 `Vector3.forward * Time.deltaTime` 와 같이 곱해주었다.

<br>

## Vector

Vector는 float x, y, z를 들고있는 간단한 구조체이다. 사용하는 방법에 따라 위치벡터, 방향벡터로 나뉘게 된다.

### 위치벡터

### 방향벡터

방향 벡터에는 **거리(크기)**와 실제 **방향**에 대한 정보가 담겨 있다.
magnitude를 사용해서 크기를, normalized를 사용해서 방향은 같고 크기가 1인 벡터를 구할 수 있다. normalized를 이용하면 시간 \* 속력을 곱해서 원하는 방향으로 이동을 쉽게 구현할 수 있다.

### Vector3 구조체(struct)를 이해하기 위한 실습

struct를 사용하면 Value Type을 만든다. Value Type은 상속될 수 없고 데이터를 복사하여 파라미터를 전달하는 특징이 있다.(Reference Type은 Heap 상의 객체에 대한 레퍼런스를 전달한다)

```csharp
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

    // MyVector간의 연산을 위해 operator 정의
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
    [SerializeField]
    float _speed = 10.0f;

    void Start()
    {
        MyVector to = new MyVector(10.0f, 0.0f, 0.0f);  // 목적지
        MyVector from = new MyVector(5.0f, 0.0f, 0.0f);  // 현재위치
        MyVector dir = to - from;  // (5.0f, 0.0f, 0.0f)

        MyVector normalizedDir = dir.normalized;  // (1.0f, 0.0f, 0.0f)

        MyVector newPos = from + normalizedDir * _speed;
    }

    void Update()
    {
        // ...
    }

}

```

## Rotation

## 오일러(Euler)와 쿼터니언(Quaternion)

#### 오일러

오일러 앵글은 설정되어 있는 순서로 해당 축들을 개별적으로 계산한다.
Unity에서는 X, Y, Z 순서로 오일러 앵글이 계산된다.
세 개의 축을 독립적으로 계산하기 때문에 두 축이 겹쳐버리는 현상이 생기기도 하는데 이를 `짐벌락(Gimbal-lock)`이라고 한다. 이렇게 축이 겹쳐버리면 한 축에 대해서는 계산이 불가능해진다.

### 쿼터니언

설명 추가할것

### eulerAngles

절대 회전값을 지정해서 회전시키는 방법

```csharp
_yAngle += Time.deltaTime * 100.0f;
transform.eulerAngles = new Vector(0.0f, _yAngle, 0.0f);
```

- eulerAngles는 3개 요소를 한번에 다 넣어주도록 문서에 명시되어 있음.
- (0.0f, Time.deltaTime \* 100.0f, 0.0f) 처럼 쓰면 increase를 하면 에러날수 있음

### Roatate

+- delta 값을 특정 축을 중심으로 회전시키는 방법

```csharp
// Rotate에 Vector 값을 넣어줌
transform.Rotate(new Vector3(0.0f, Time.deltaTime * 100.0f, 0.0f));

// Quaternion.Euler는 벡터를 입력하면 Quaternion으로 변환해줌
transform.rotation =  Quaternion.Euler(new Vector3(0.0f, _yAngle, 0.0f));

```

### LookRotation

캐릭터가 바라보는 방향을 바꿔줌

```csharp
// 캐릭터가 월드 좌표 기준으로 forward를 바라봄
transform.rotation = Quaternion.LookRotation(Vector3.forward)
```

### Lerp

![](2021-11-14-03-29-50.png)

### Slerp

캐릭터가 바라보는 방향을 부드럽게 전환할때 사용한다. 두 지점 사이의 구면 선형 보간을 t(마지막 파라미터)에 의해서 계산한 후 위치를 반환한다.

![](2021-11-14-03-30-47.png)

```csharp
// Quaternion Slerp(Quaternion a, Quaternion b, float t);
// 마지막 파라미터를 0.0f로 주면 a에서 움직이지 않고, 1.0f로 주면 b로 바로 회전한다. transform.rotation = Quaternion.LookRotation(Vector3.forward) 한것과 같은 동작임
transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.1f);

```
