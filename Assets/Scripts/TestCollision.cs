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

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));  // Ŭ���� ������ ���� ��ǥ(Near Clipping Plan�� �ִ� ������ǥ)
        //    Vector3 dir = mousePos - Camera.main.transform.position;  // ī�޶� ��ġ���� Near Clipping Plan�� �ִ� ��ǥ������ ���⺤��
        //    dir = dir.normalized;   // ũ�⸦ 1�� ����

        //    Debug.DrawRay(Camera.main.transform.position, dir * 100.0f, Color.red, 1.0f);

        //    RaycastHit hit;
        //    if (Physics.Raycast(Camera.main.transform.position, dir, out hit, 100.0f)) ;
        //    {
        //        Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
        //        //Debug.Log($"Raycast Camera @ {hit.transform.gameObject.name}");
        //    }
        //}

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            Debug.DrawRay(Camera.main.transform.position, ray.direction * 100.0f, Color.red, 1.0f);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100.0f)) ;
            {
                Debug.Log($"Raycast Camera @ {hit.collider.gameObject.name}");
                //Debug.Log($"Raycast Camera @ {hit.transform.gameObject.name}");
            }

        }

    }
}
