using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public�� �ٿ� �ָ� �����Ϳ��� �ش� ������ ������ �� ����
    // �ܺο� �����Ű�� ���� �ʴٸ� [SerializeField] Attibute�� �޾��ָ� �ȴ�

    [SerializeField]
    float _speed = 10.0f;

    void Start()
    {
        
    }

    // �ֻ�ܿ� GameObject(Player)
        // Transform
        // PlayerController (*)
    void Update()   
    {
        // �� Frame�� ȣ��Ǵ� �Լ�
        // 60Frame�� �����̶�� 1/60�� ���� Update�Լ��� ����ǹǷ� �ʹ� ������ �̵��ϰ� �ȴ�
        // ���� Frame�� ���� Frame�� �ð� ���̸� ���ϰ� �װ� Ȱ���ؼ� �̵��ӵ��� �����ؾ� �Ѵ�
        
        // transform.TransformDirection() ����ϸ� ������ǥ���� ������ǥ�� ����� ���ش�
        // ���Ӽ����� �����ؼ� ����� �̿��ؼ� ��ǥ����� �� ���� ���� 
        if (Input.GetKey(KeyCode.W))
            transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);   // new Vector3(0.0f, 0.0f, 1.0f) -> Vector3.forward ���� ����ϸ� �������� �� ����
        if (Input.GetKey(KeyCode.S))
            transform.position += transform.TransformDirection(Vector3.back * Time.deltaTime * _speed);  // �ð� * �ӷ� = �Ÿ�
        if (Input.GetKey(KeyCode.A))
            transform.position += transform.TransformDirection(Vector3.left * Time.deltaTime * _speed);
        if (Input.GetKey(KeyCode.D))
            transform.position += transform.TransformDirection(Vector3.right * Time.deltaTime * _speed);


        // transform.gameObject : �θ��� GameObject�� ����
        // transform. : transform�� ����

    }
}
