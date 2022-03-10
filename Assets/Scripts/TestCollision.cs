using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    // 19-1 Collision 발생 조건
    // 1) 자신 or 상대에게 RigidBody 있어야함 (IsKinematic Off)
    // 2) 자신에게 Collider가 있어야 한다 (IsTrigger Off)
    // 3) 상대한테 Collider가 있어야 한다 (IsTrigger Off)
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision @ {collision.gameObject.name}");
    }

    // 19-2 범위 안에 있는지를 판단하는데 사용하는게 Trigger
    // Trigger 발생 조건
    // 1) 둘다 Collider가 있어야 한다
    // 2) 둘 중 하나는 IsTrigger : On
    // 3) 둘 중 하나는 RigidBody가 있어야 한다
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
        //    Vector3 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.nearClipPlane));  // 클릭한 지점의 월드 좌표(Near Clipping Plan에 있는 월드좌표)
        //    Vector3 dir = mousePos - Camera.main.transform.position;  // 카메라 위치에서 Near Clipping Plan에 있는 좌표까지의 방향벡터
        //    dir = dir.normalized;   // 크기를 1로 만듬

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
