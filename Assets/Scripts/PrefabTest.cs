using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabTest : MonoBehaviour
{
    public GameObject prefab;

    GameObject tank;
    void Start()
    {
        tank = Instantiate(prefab);

        Destroy(tank, 3.0f);
    }


}
