using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] private List<Sprite> noLegsFrames;
    [SerializeField] private List<Sprite> upperBodyWLegs;
    [SerializeField] private bool hasLegs;
    [SerializeField] private float animSpeed; // in fps

    private PlayerLegPickupLogic pickupLogic;
    private PlayerMovement pm;
    private SpriteRenderer spriteRenderer;

    private int currentAnimIndex = 0;

    private float counter;
    
    // Start is called before the first frame update
    void Start()
    {
        pickupLogic = GetComponent<PlayerLegPickupLogic>();
        pm = GetComponent<PlayerMovement>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        hasLegs = pickupLogic.hasLegs();
        
        if (!hasLegs)
        {
            // play legless anim when moving
            if (pm.isMoving() && counter >= 1f/animSpeed)
            {
                currentAnimIndex++;
                if (currentAnimIndex >= noLegsFrames.Count)
                {
                    currentAnimIndex = 0;
                }
                spriteRenderer.sprite = noLegsFrames[currentAnimIndex];
                counter = 0;
            }
        }
        else
        {
            if (pm.isMoving() && counter >= 1f/animSpeed)
            {
                currentAnimIndex++;
                if (currentAnimIndex >= noLegsFrames.Count)
                {
                    currentAnimIndex = 0;
                }
                spriteRenderer.sprite = upperBodyWLegs[currentAnimIndex];
                counter = 0;
            }
        }
    }
}
