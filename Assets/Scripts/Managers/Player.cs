using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Manager를 어디서든 가져오기를 원함
        // Player에서 Manager를 가져오는 방법은?
        // Unity에서 UI를 클릭해서 만드는 기능들은 코드로도 다 만들 수 있음

        Managers mg = Managers.Instance;  // static으로 정의된 유일한 객체를 가져옴
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
