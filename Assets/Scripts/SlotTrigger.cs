using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotTrigger : MonoBehaviour
{
    public GameObject slotMachineObject;
    SlotMachine slotMachine;
    bool playerFacing = false;
    PlayerController playerController;
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        slotMachine = slotMachineObject.GetComponent<SlotMachine>();
    }

    void Update()
    {
        if(Input.GetButtonDown("Spin") && playerFacing && playerController.CanPlay()){
            Debug.Log("test");
            playerController.lastPlay = Time.time;
            slotMachine.StartSpin();            
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
