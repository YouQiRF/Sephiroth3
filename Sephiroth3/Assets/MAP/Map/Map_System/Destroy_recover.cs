﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_recover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Map_System.Recover_map == false)
        {
            Destroy(gameObject);
            Debug.Log("git test");
        }
    }
}
