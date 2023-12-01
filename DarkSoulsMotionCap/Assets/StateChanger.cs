using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateChanger : MonoBehaviour
{
    public Animator characterAnim;
    float animationBlendVal;
    public float lerpTime;
    bool lerpRun;
    bool lerpAttack;
    bool lerpGrab;
    bool lerpWalk;

    // Start is called before the first frame update
    void Start()
    {
        characterAnim.SetFloat("Blend", 0.0f); //this just sets the 
    }

    // Update is called once per frame
    void Update()
    {
        LeanTween.init();
        PlayerInput();
        AnimationBlend();
    }

    /// <summary>
    /// This method just controls the player input to switch out the animations for the scene
    /// </summary>
    void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            print("this is running");
            lerpRun = true;

        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            lerpAttack = true;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            lerpGrab = true;
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            lerpWalk = true;
        }
    }

    /// <summary>
    /// This method controls the animation blend while also lerping the animation blendvalue
    /// </summary>
    void AnimationBlend()
    {
        if (lerpRun)
        {

            LeanTween.value(gameObject, animationBlendVal, 0.34f, lerpTime).setOnUpdate(ChangeBlendState);
            characterAnim.SetFloat("Blend", animationBlendVal);

            if (animationBlendVal == 0.34f)
            {
                print(animationBlendVal);
                lerpRun = false;
            }
        }
        else if(lerpAttack)
        {
            LeanTween.value(gameObject, animationBlendVal, 0.67f, lerpTime).setOnUpdate(ChangeBlendState);
            characterAnim.SetFloat("Blend", animationBlendVal);

            if (animationBlendVal == 0.67f)
            {
                print(animationBlendVal);
                lerpAttack = false;
            }
        }
        else if (lerpGrab)
        {
            LeanTween.value(gameObject, animationBlendVal, 1, lerpTime).setOnUpdate(ChangeBlendState);
            characterAnim.SetFloat("Blend", animationBlendVal);

            if (animationBlendVal == 1)
            {
                print(animationBlendVal);
                lerpAttack = false;
            }
        }

        else if(lerpWalk)
        {
            LeanTween.value(gameObject, animationBlendVal, 0.0f, lerpTime).setOnUpdate(ChangeBlendState);
            characterAnim.SetFloat("Blend", animationBlendVal);

            if (animationBlendVal == 0.0f)
            {
                print(animationBlendVal);
                lerpWalk = false;
            }
        }
    }

    /// <summary>
    /// This is a update funtion for LeanTween to smoothly lerp the animationblendval to get a smooth transitions between animations
    /// </summary>
    /// <param name="a"></param>
    void ChangeBlendState(float a)
    {
        var blendChange = a;

        animationBlendVal = blendChange;

    }
}
