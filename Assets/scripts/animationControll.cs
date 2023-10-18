using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class animationControll : MonoBehaviour
{


    Animator anim;

    //low = 0 ; middle = 1; high = 2
    int currentState = 1;

    private const string ADDITION_CONST = "add";
    private const string SUBTRACTION_CONST = "subtract";

    private const string LOWSTANCE_CONST = "lowStance";
    private const string MIDDLESTANCE_CONST = "middleStance";
    private const string HIGHSTANCE_CONST = "highStance";
    private const string LOWSTAB_CONST = "lowStab";
    private const string MIDDLESTAB_CONST = "middleStab";
    private const string HIGHSTAB_CONST = "highStab";

    private const string LOWIDLE_CONST = "lowIdle";
    private const string MIDDLEIDLE_CONST = "middleIdle";
    private const string HIGHIDLE_CONST = "highIdle";


    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            updateAnimationState(ADDITION_CONST);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            updateAnimationState(SUBTRACTION_CONST);
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            updateAnimationStab();
        }
    }

    void updateAnimationStab()
    {

        setAllAnimStates(false); 

        switch (currentState)
        {
            case 0:
                anim.SetBool(LOWSTAB_CONST, true);
                break;
            case 1:
                anim.SetBool(MIDDLESTAB_CONST, true);
                break;
            case 2:
                anim.SetBool(HIGHSTAB_CONST, true);
                break;
        }
    }

    void updateAnimationState(string pAction)
    {
        setAllAnimStates(false);

        if (pAction.Equals("add"))
        {
            currentState++;
        }
        else if (pAction.Equals("subtract"))
        {
            currentState--;
        }

        if (currentState >= 2)
        {
            currentState = 2;
        }
        else if (currentState <= 0)
        {
            currentState = 0;
        }

        switch (currentState)
        {
            case 0:
                anim.SetBool(LOWSTANCE_CONST, true);
                break;
            case 1:
                anim.SetBool(MIDDLESTANCE_CONST, true);
                break;
            case 2:
                anim.SetBool(HIGHSTANCE_CONST, true);
                break;
        }

    }

    void setAllAnimStates(bool pState)
    {
        anim.SetBool(LOWSTANCE_CONST, pState);
        anim.SetBool(MIDDLESTANCE_CONST, pState);
        anim.SetBool(HIGHSTANCE_CONST, pState);

        anim.SetBool(LOWSTAB_CONST, pState);
        anim.SetBool(MIDDLESTAB_CONST, pState);
        anim.SetBool(HIGHSTAB_CONST, pState);

        anim.SetBool(LOWIDLE_CONST, pState);
        anim.SetBool(MIDDLEIDLE_CONST, pState);
        anim.SetBool(HIGHIDLE_CONST, pState);
    }
}
