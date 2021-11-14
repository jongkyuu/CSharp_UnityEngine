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
        //MyVector pos = new MyVector(1.0f, 0.0f, 0.0f);
        //pos += new MyVector(0.0f, 2.0f, 0.0f);

        Managers.Input.KeyAction -= OnKeyBorad;  // Ȥ�ö� �ٸ� �κп��� OnKeyBoard�� �����ߴٸ� OnKeyBoard�� �ι� ȣ��ǹǷ� �װ� �����ϱ� ���� �켱 ���� ���
        Managers.Input.KeyAction += OnKeyBorad;  // KeyAction�� OnKeyBoad ������û, � Key�� �������� OnKeyBoard �Լ��� ����


    }

    void Update()   
    {


    }

    void OnKeyBorad()
    {
        //transform.rotation

        // ���� ȸ������ �����ؼ� �̵���Ŵ
        // transform.eulerAngles = new Vector3(0.0f, _yAngle, 0.0f);  // eulerAngles�� 3�� ��Ҹ� �ѹ��� �� �־��ֵ��� ������ ��õǾ� ����.
        // (0.0f, Time.deltaTime * 100.0f, 0.0f) ó�� ���� �������� ���� 
        // +- delta ���� Ư�� ���� �߽����� ȸ����Ŵ
        //transform.Rotate(new Vector3(0.0f, Time.deltaTime * 100.0f, 0.0f));

        //transform.rotation =  Quaternion.Euler(new Vector3(0.0f, _yAngle, 0.0f));  // Quaternion.Euler�� ���͸� �Է��ϸ� Quaternion���� ��ȯ����

        if (Input.GetKey(KeyCode.W))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.forward);  // ĳ���Ͱ� ���� ��ǥ ������ forward�� �ٶ�
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.forward), 0.1f);
            //transform.position += transform.TransformDirection(Vector3.forward * Time.deltaTime * _speed);   // new Vector3(0.0f, 0.0f, 1.0f) -> Vector3.forward ���� ����ϸ� �������� �� ����
            // TransformDirection()�� ĳ���Ͱ� �ٶ󺸴� �������� �̵��ϴ� ���̱� ������ Quaternion.Slerp�� ����ϸ� ���ڿ������� ��� �׸��� �����δ�.
            // �̶��� ���� ��ǥ �������� �̵��ϵ��� �������ָ� �� �� �ڿ������� ���� �� �ִ�.
            transform.position += Vector3.forward * Time.deltaTime * _speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            //transform.rotation = Quaternion.LookRotation(Vector3.back);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Vector3.back), 0.1f);
            //transform.Translate(Vector3.forward * Time.deltaTime * _speed);  // �ð� * �ӷ� = �Ÿ�
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
