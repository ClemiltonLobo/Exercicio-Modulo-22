using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorManager : MonoBehaviour
{
    public Animator animator;
    public List<AnimatorSetup> animatorSetups;
    public enum AnimationType
    {
        IDLE,
        RUN,
        DEAD,
        VICTORY,
        LocomotionPose,
        CRY
    }

    public void Start()
    {
        Play(AnimationType.CRY);
    }

    public void Play(AnimationType type, float currentSpeedFactor = 1)
    {
        foreach(var animation  in animatorSetups)
        {
            if (animation.type == type)
            {
                animator.SetTrigger(animation.trigger);
                animator.speed = animation.speed * currentSpeedFactor;
                break;
            }
        }
    }
    public void Update()
    {
     if(Input.GetKeyUp(KeyCode.Alpha1))
        {
            Play(AnimationType.RUN);
        }
     else if(Input.GetKeyUp(KeyCode.Alpha2))
        {
            Play(AnimationType.DEAD);
        }
     else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            Play(AnimationType.IDLE);
        }
     else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            Play(AnimationType.VICTORY);
        }
     else if(Input.GetKeyUp(KeyCode.Alpha5))
        {
            Play(AnimationType.LocomotionPose);
        }
    }

    public float GetAnimationLength(AnimationType type)
    {
        foreach (var animation in animatorSetups)
        {
            if (animation.type == type)
            {
                return animator.GetCurrentAnimatorStateInfo(0).length / animation.speed;
            }
        }

        return 0f;
    }
}
[System.Serializable]

public class AnimatorSetup
{
    public AnimatorManager.AnimationType type;
    public string trigger;
    public float speed = 1f;
}
