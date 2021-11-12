using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 1. ��ġ����
// 2. ���⺤��
struct MyVector
{
    public float x;
    public float y;
    public float z;

    // �Ÿ� ���Ҷ� magnitude ���
    public float magnitude
    { 
        get { return  Mathf.Sqrt(x*x + y*y + z*z); }  // ��Ÿ��� ���� Ȱ��
    }

    // magnitude�� ������ ���� ũ�Ⱑ 1�� ����
    // normalized�� �Ÿ���ŭ�� ũ�⸦ �����ָ� �� �������� ũ�⸸ŭ �̵�
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
    // public�� �ٿ� �ָ� �����Ϳ��� �ش� ������ ������ �� ����
    // �ܺο� �����Ű�� ���� �ʴٸ� [SerializeField] Attibute�� �޾��ָ� �ȴ�

    [SerializeField]
    float _speed = 10.0f;

    void Start()
    {
        //MyVector pos = new MyVector(1.0f, 0.0f, 0.0f);
        //pos += new MyVector(0.0f, 2.0f, 0.0f);

        MyVector to = new MyVector(10.0f, 0.0f, 0.0f);  // ������
        MyVector from = new MyVector(5.0f, 0.0f, 0.0f);  // ������ġ
        MyVector dir = to - from;  // (5.0f, 0.0f, 0.0f)

        MyVector normalizedDir = dir.normalized;  // (1.0f, 0.0f, 0.0f)

        MyVector newPos = from + normalizedDir * _speed;

        // ���� ����
        //   1. �Ÿ�(ũ��)
        //   2. ���� ����
    }

    // �ֻ�ܿ� GameObject(Player)
    // Transform
    // PlayerController (*)
    void Update()   
    {
        // �� Frame�� ȣ��Ǵ� �Լ�
        // 60Frame�� �����̶�� 1/60�� ���� Update�Լ��� ����ǹǷ� �ʹ� ������ �̵��ϰ� �ȴ�
        // ���� Frame�� ���� Frame�� �ð� ���̸� ���ϰ� �װ� Ȱ���ؼ� �̵��ӵ��� �����ؾ� �Ѵ�
        
        // Local -> World ��ǥ�� ��ȯ
        // transform.TransformDirection() 
        // World -> Local ��ǥ ��ȯ
        // transform.InverseTransformDirection()
        // transform.Translate() ����ص� ��. �̰� ������ �������� ������ش�

        // ���Ӽ����� �����ؼ� ����� �̿��ؼ� ��ǥ����� �� ���� ���� 


        if (Input.GetKey(KeyCode.W))
            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);   // new Vector3(0.0f, 0.0f, 1.0f) -> Vector3.forward ���� ����ϸ� �������� �� ����
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector3.back * Time.deltaTime * _speed);  // �ð� * �ӷ� = �Ÿ�
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector3.left * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector3.right * Time.deltaTime * _speed);


        // transform.gameObject : �θ��� GameObject�� ����
        // transform. : transform�� ����

    }
}
