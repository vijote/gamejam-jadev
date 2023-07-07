using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LizardPlayer : FishPlayer
{

    void Update()
    {
        //override original Update
        HandlePlayerInput();
    }

    protected new void PlayAnimation()
    {
        if (this.verticalInput != 0)
        {
            this.playerAnimator.Play("Walk");
        }
        else
        {
            this.playerAnimator.Play("Idle_A");
        }
    }


}
