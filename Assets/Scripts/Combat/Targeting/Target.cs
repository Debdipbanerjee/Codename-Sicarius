using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public event Action<Target> OnDestroyed;

    private void OnDestroy()
    {
        //when destroye, tell me
        OnDestroyed?.Invoke(this);
    }
}
