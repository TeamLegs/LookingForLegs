using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLegPickupLogic : MonoBehaviour
{

    [SerializeField] private List<GameObject> legInventory;
    [SerializeField] private int selectedLeg;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
           cycleToNextLeg(); 
        }
    }

    public bool hasLegs()
    {
        return legInventory.Count > 0;
    }

    public void cycleToNextLeg()
    {
        // get ref to old leg
        GameObject oldLeg = legInventory[selectedLeg];
        oldLeg.SetActive(false);
        
        // increment leg index
        selectedLeg++;
        if (selectedLeg >= legInventory.Count)
        {
            selectedLeg = 0;
        }

        // get ref to new leg
        GameObject newLeg = legInventory[selectedLeg];
        newLeg.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject legs = col.gameObject;
        if (legs.CompareTag("LegParent"))
        {
            if (!hasLegs() || (hasLegs() && !legs.Equals(legInventory[^1])))
            {
                legInventory.Add(legs);
                legs.transform.parent = transform.GetChild(0);
                legs.transform.localPosition = Vector3.zero;
            }
            if (!hasLegs())
            {
                transform.position += Vector3.up;
            }
        }
    }
}
