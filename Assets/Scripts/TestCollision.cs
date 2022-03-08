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
        // 20-1
        // 특정 방향으로 레이저를 쏨. Raycast는 기본적으로 앞에있는 하나의 물체만 타겟팅 한다
        // DrawRay를 통해 Raycasting을 쏠 수 있음.
        //Debug.DrawRay(transform.position + Vector3.up, Vector3.forward * 10, Color.red);  // 20-3 위치에 Vector3.up을 더해 상체에서 레이저가 나가도록 수정

        // 20-5
        // 캐릭터가 움직이는 방향에 따라 Raycast도 움직이도록 forward를 로컬 좌표로 인식하고 거기에 해당하는 월드 좌표를 찾으면 된다
        Vector3 look = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position + Vector3.up, look * 10, Color.red);

        // 20-2
        // Vector3는 위치와 방향을 나타내는데 사용
        // Physics.Raycast(transform.position, Vector3.forward) 에서 Vector3.forward는 단위벡터인데 이 함수에서는 해당 방향으로 끝까지 뻗어감
        // Debug.DrawRay는 start 지점부터 start + dir 지점까지 선을 그어주므로 두번째 인자에 방향 뿐만 아니라 크기도 있어야 한다


        //if (Physics.Raycast(transform.position + Vector3.up, Vector3.forward, 10))   // 마지막 인자는 maxDistance
        // 20-4
        // Raycasting 대상을 알기 위해서 RaycastHit 추가
        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up, Vector3.forward, out hit, 10))
            if (Physics.Raycast(transform.position + Vector3.up, look, out hit, 10))  // 20-5 반영해서 forword를 look으로 바꿈
            {
                Debug.Log($"Raycast {hit.collider.gameObject.name}!");
            }

        // 20-6 Raycasting의 일직선상에 있는(관통하는) 모든 물체를 알고싶으면 RaycastAll() 사용
        RaycastHit[] hits;
        hits = Physics.RaycastAll(transform.position + Vector3.up, look, 10);

        foreach(var hitone in hits)
        {
            Debug.Log($"RaycastAll {hitone.collider.gameObject.name}");
        }
    }
}
