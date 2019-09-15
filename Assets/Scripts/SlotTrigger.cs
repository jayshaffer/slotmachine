using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotTrigger : MonoBehaviour
{
    public GameObject slotMachineObject;
    SlotMachine slotMachine;
    bool playerFacing = false;
    void Start()
    {
        slotMachine = slotMachineObject.GetComponent<SlotMachine>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Spin")){
            slotMachine.Spin();            
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            playerFacing = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            playerFacing = false;
        }
    }
}
