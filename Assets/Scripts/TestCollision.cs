using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // 19-1 Collision �߻� ����
    // 1) �ڽ� or ��뿡�� RigidBody �־���� (IsKinematic Off)
    // 2) �ڽſ��� Collider�� �־�� �Ѵ� (IsTrigger Off)
    // 3) ������� Collider�� �־�� �Ѵ� (IsTrigger Off)
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision @ {collision.gameObject.name}");
    }

    // 19-2 ���� �ȿ� �ִ����� �Ǵ��ϴµ� ����ϴ°� Trigger
    // Trigger �߻� ����
    // 1) �Ѵ� Collider�� �־�� �Ѵ�
    // 2) �� �� �ϳ��� IsTrigger : On
    // 3) �� �� �ϳ��� RigidBody�� �־�� �Ѵ�
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger! @ {other.gameObject.name}");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
