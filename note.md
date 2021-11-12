# Chapter 2

### Singleton 패턴

### Component 패턴

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

```chsarp

// 캐릭터가 바라보는 Local 좌표를 World 좌표로 변환
// 캐릭터가 바라보는 방향으로 직진하게 된다
transform.position += transform.TransformDirection(Vector3(0.0f, 0.0f, 1.0f) * Time.deltaTime * _speed)

transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed)

transform.Translate(Vector3.forward * Time.deltaTime * _speed);

// 모두 같은 동작을 하는 코드임

```

## Vector

Vector는 float x, y, z를 들고있는 간단한 구조체이다. 사용하는 방법에 따라 위치벡터, 방향벡터로 나뉘게 된다.

### 위치벡터

### 방향벡터

방향 벡터에는 거리(크기)와 실제 방향에 대한 정보가 담겨 있다.
magnitude를 사용해서 크기를, normalized를 사용해서 방향은 같고 크기가 1인 벡터를 구할 수 있다. normalized를 이용하면 시간 \* 속력을 곱해서 원하는 방향으로 이동을 쉽게 구현할 수 있다.
