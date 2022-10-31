using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private PlayerStateMachine playerStateMachine;
    // Start is called before the first frame update
    void Start()
    {
        playerStateMachine = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
