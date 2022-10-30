using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] private List<Sprite> noLegsFrames;
    [SerializeField] private List<Sprite> upperBodyWLegs;
    [SerializeField] private List<Sprite> legAnim;
    [SerializeField] private bool hasLegs;
    [SerializeField] private float animSpeed; // in fps

    private PlayerLegPickupLogic pickupLogic;
    private PlayerMovement pm;
    private SpriteRenderer spriteRenderer;

    private SpriteRenderer legSprite;

    private int _currentAnimIndex = 0;
    private int legAnimIndex = 0;

    private float counter;

    [SerializeField] private bool legsAcquired = false;
    
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

        if (!legsAcquired && hasLegs)
        {
            legSprite = transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
            legsAcquired = true;
        }
        if (!hasLegs)
        {
            // play legless anim when moving
            if (pm.isMoving() && counter >= 1f/animSpeed)
            {
                _currentAnimIndex++;
                if (_currentAnimIndex >= noLegsFrames.Count)
                {
                    _currentAnimIndex = 0;
                }
                spriteRenderer.sprite = noLegsFrames[_currentAnimIndex];
                counter = 0;
            }
        }
        else
        {
            if (pm.isMoving() && counter >= 1f/animSpeed)
            {
                _currentAnimIndex++;
                if (_currentAnimIndex >= upperBodyWLegs.Count)
                {
                    _currentAnimIndex = 0;
                }
                spriteRenderer.sprite = upperBodyWLegs[_currentAnimIndex];

                if (legSprite != null)
                {
                    legAnimIndex++;
                    if (legAnimIndex >= legAnim.Count)
                    {
                        legAnimIndex = 0;
                    }
                    legSprite.sprite = legAnim[legAnimIndex];
                }
                counter = 0;
            }
        }
    }

    public void changeLeg(SpriteRenderer newRenderer)
    {
        legSprite = newRenderer;
    }
}
