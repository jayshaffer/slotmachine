using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotRow : MonoBehaviour
{
    public float count;
    public GameObject slotPrefab;
    public List<SlotMachine> slotPool;
    public float buffer;
    void Start()
    {
        float offset = 0;
        BoxCollider2D collider = slotPrefab.GetComponent<BoxCollider2D>();
        Vector3 slotSize = collider.size;
        for(int i = 0; i < count; i++){
            Vector3 pos = new Vector3(transform.position.x + offset, transform.position.y, transform.position.z);
            GameObject slot = Instantiate(slotPrefab, pos, Quaternion.identity);
            offset += slotSize.x + buffer;
        }
    }

    void Update()
    {
        
    }
}
