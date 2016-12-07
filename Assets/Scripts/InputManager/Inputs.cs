using UnityEngine;
using System;
using System.Collections;

public class Inputs{

   

    
   

    public static bool Pause()
    {
        return Input.GetButtonDown("Start");
    }
    public static float HorizontalAxis()
    {
        float r = 0.0f;
        //r += Input.GetAxis("J_Horizontal");
        r += Input.GetAxis("K_Horizontal");
        return Mathf.Clamp(r, -1f, 1f);
    }
    public static float VerticalAxis()
    {
        float r = 0.0f;
        //r += Input.GetAxis("J_Vertical");
        r += Input.GetAxis("K_Vertical");
        return Mathf.Clamp(r, -1f, 1f);
    }


    public static bool MenuUp()
    {
        return Input.GetButtonDown("MenuUp");
    }

    public static bool MenuDown()
    {
        return Input.GetButtonDown("MenuDown");
    }

    public static bool MenuRight()
    {
        return Input.GetButtonDown("MenuRight");
    }

    public static bool MenuLeft()
    {
        return Input.GetButtonDown("MenuLeft");
    }


    public static bool A_Button()
    {
        return Input.GetButtonDown("A_Button");
    }

    public static bool B_Button()
    {
        return Input.GetButtonDown("B_Button");
    }


}
