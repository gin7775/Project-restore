using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDeathBehavior : StateMachineBehaviour
{
    private GameManager gameManager;

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        //gameManager.
        Destroy(animator.gameObject);
    }

}
