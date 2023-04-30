using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeActive : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToChange;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ChangeObjectActive();
        }
    }

    public void ChangeObjectActive()
    {
        Invoke("Change", 1);
    }

    public void Change()
    {
        foreach (var go in objectsToChange)
        {
            go.SetActive(!go.activeInHierarchy);
        }
    }
}
