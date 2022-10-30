using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerLegPickupLogic : MonoBehaviour
{

    [SerializeField] private List<GameObject> legInventory;
    [SerializeField] private int selectedLeg;
    private Animation animScript;

    // Start is called before the first frame update
    void Start()
    {
        animScript = GetComponent<Animation>();
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

    public void cycleToSpecificLeg(int index)
    {
        // get ref to old leg
        GameObject oldLeg = legInventory[selectedLeg];
        oldLeg.SetActive(false);

        selectedLeg = index;
        
        // get ref to new leg
        GameObject newLeg = legInventory[selectedLeg];
        newLeg.SetActive(true);       
        
        PlayerMovement movescript = GetComponent<PlayerMovement>();
        LegValues legvals = newLeg.GetComponent<LegValues>();
        movescript.setSpeedMultiplier(legvals.getSpeedMultiplier());
        movescript.setJumpMultiplier(legvals.getJumpMultiplier());
        animScript.changeLeg(newLeg.GetComponent<SpriteRenderer>());
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
        
        PlayerMovement movescript = GetComponent<PlayerMovement>();
        LegValues legvals = newLeg.GetComponent<LegValues>();
        movescript.setSpeedMultiplier(legvals.getSpeedMultiplier());
        movescript.setJumpMultiplier(legvals.getJumpMultiplier());
        animScript.changeLeg(newLeg.GetComponent<SpriteRenderer>());
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        GameObject legs = col.gameObject;
        if (legs.CompareTag("LegParent"))
        {
            if (!hasLegs() || (hasLegs() && !legs.Equals(legInventory[^1])))
            {
                legInventory.Add(legs);
                cycleToSpecificLeg(legInventory.Count-1);
                legs.transform.parent = transform.GetChild(0);
                legs.transform.localPosition = Vector3.zero;
                
                PlayerMovement movescript = GetComponent<PlayerMovement>();
                LegValues legvals = legs.GetComponent<LegValues>();
                movescript.setSpeedMultiplier(legvals.getSpeedMultiplier());
                movescript.setJumpMultiplier(legvals.getJumpMultiplier());
            }
            if (!hasLegs())
            {
                transform.position += Vector3.up;
                GetComponent<BoxCollider2D>().size = new Vector2(1, 2);  
                GetComponent<BoxCollider2D>().offset = new Vector2(0, -0.5f);  
            }

        }
    }
}
