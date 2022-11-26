using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventManager : MonoBehaviour
{
    public static Action showGrid;

    public static void showGridAction()
    {
        showGrid?.Invoke();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            showGridAction();
        }
    }
}
