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
        // 20-1
        // Ư�� �������� �������� ��. Raycast�� �⺻������ �տ��ִ� �ϳ��� ��ü�� Ÿ���� �Ѵ�
        // DrawRay�� ���� Raycasting�� �� �� ����.
        //Debug.DrawRay(transform.position + Vector3.up, Vector3.forward * 10, Color.red);  // 20-3 ��ġ�� Vector3.up�� ���� ��ü���� �������� �������� ����

        // 20-5
        // ĳ���Ͱ� �����̴� ���⿡ ���� Raycast�� �����̵��� forward�� ���� ��ǥ�� �ν��ϰ� �ű⿡ �ش��ϴ� ���� ��ǥ�� ã���� �ȴ�
        Vector3 look = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position + Vector3.up, look * 10, Color.red);

        // 20-2
        // Vector3�� ��ġ�� ������ ��Ÿ���µ� ���
        // Physics.Raycast(transform.position, Vector3.forward) ���� Vector3.forward�� ���������ε� �� �Լ������� �ش� �������� ������ ���
        // Debug.DrawRay�� start �������� start + dir �������� ���� �׾��ֹǷ� �ι�° ���ڿ� ���� �Ӹ� �ƴ϶� ũ�⵵ �־�� �Ѵ�


        //if (Physics.Raycast(transform.position + Vector3.up, Vector3.forward, 10))   // ������ ���ڴ� maxDistance
        // 20-4
        // Raycasting ����� �˱� ���ؼ� RaycastHit �߰�
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.forward, out hit, 10))
            if (Physics.Raycast(transform.position + Vector3.up, look, out hit, 10))  // 20-5 �ݿ��ؼ� forword�� look���� �ٲ�
            {
                Debug.Log($"Raycast {hit.collider.gameObject.name}!");
            }

        // 20-6 Raycasting�� �������� �ִ�(�����ϴ�) ��� ��ü�� �˰������ RaycastAll() ���
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position + Vector3.up, look, 10);

        foreach(var hitone in hits)
        {
            Debug.Log($"RaycastAll {hitone.collider.gameObject.name}");
        }
    }
}
