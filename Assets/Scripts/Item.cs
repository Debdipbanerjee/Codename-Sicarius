using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool UnlockBlock;
    public bool UnlockDodge;
    public bool UnlockClimb;

    protected PlayerStateMachine PlayerstateMachine;

    // Start is called before the first frame update
    void Start()
    {
        PlayerstateMachine = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStateMachine>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation = Quaternion.Euler(0, Time.time * 100f, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (UnlockBlock)
            {
                PlayerstateMachine.canBlock = true;
            }

            if (UnlockDodge)
            {
                PlayerstateMachine.canDodge = true;
            }

            if(UnlockClimb)
            {
                PlayerstateMachine.canClimb = true;
            }

            Destroy(gameObject);
        }
    }
}
