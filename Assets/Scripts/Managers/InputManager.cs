using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager
{
    public Action KeyAction = null;

    public void OnUpdate()
    {
        // 리스터 패턴
        if (Input.anyKey == false)
            return;
        if (KeyAction != null)
            KeyAction.Invoke();  // 이벤트를 구독신청한 곳에서 전달받음
    }
}
