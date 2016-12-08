using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum InputPhase
{
    ButtonDown,
    ButtonUp
}

public delegate void InputDelegate();

public class InputEvent
{
    public InputPhase phase;
}


public class KeyEvent: InputEvent
{
    public KeyCode key;
    public event InputDelegate method;

    public void ExecutMethod()
    {
        method();
    }
}



public class InputEvents : MonoBehaviour {

    public static List<KeyEvent> keyEventList;

    public static void RegisterKeyEvent(InputPhase phase, KeyCode key, InputDelegate method)
    {
        if(keyEventList == null)
        {
            keyEventList = new List<KeyEvent>();
        }

        KeyEvent existing = GetKeyEventFromList(phase, key);

        if(existing == null)
        {
            existing = CreateKeyEvent(phase, key);
            keyEventList.Add(existing);
        }

        existing.method += method;
    }

    public static void RemoveKeyEvent(InputPhase phase, KeyCode key)
    {
        keyEventList.Remove(GetKeyEventFromList(phase, key));
       

    }

    public static void ClearList()
    {
        keyEventList.Clear();
        
    }


    private static KeyEvent GetKeyEventFromList(InputPhase phase, KeyCode key)
    {
        if(keyEventList != null)
        {
            foreach(KeyEvent e in keyEventList.ToArray())
            {
                if (e.phase == phase && e.key == key)
                    return e;
            }
        }
        return null;
    }


    private static KeyEvent CreateKeyEvent(InputPhase phase, KeyCode key)
    {

        KeyEvent newEvent = new KeyEvent();
        newEvent.phase = phase;
        newEvent.key = key;

        return newEvent;
        
    }


    void Update()
    {
        CheckKeyboardInput();
    }


    void CheckKeyboardInput()
    {
        if (keyEventList != null)
        {
            foreach (KeyEvent e in keyEventList.ToArray())
            {
                bool shouldcall = false;

                switch (e.phase)
                {
                    case InputPhase.ButtonDown: shouldcall = (InputTracker.HasPressedKey(e.key)); break;

                    case InputPhase.ButtonUp: shouldcall = (InputTracker.HasReleasedKey(e.key)); break;
                }
                if (shouldcall)
                    e.ExecutMethod();
            }
            

        }
    }

}

public class InputTracker
{
    public static bool HasPressedKey(KeyCode key)
    {
        return Input.GetKeyDown(key);

    }

    public static bool HasReleasedKey(KeyCode key)
    {
        return Input.GetKeyUp(key);
    }

}
