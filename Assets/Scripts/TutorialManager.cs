using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public HintController hintController;
    public List<string> hints = new List<string>();

    void Start()
    {
        hints.Add("Use WASD to move");
        hints.Add("Traps damage your health!");
        hints.Add("Collect apples for a \njump boost and +5 score!");
        hints.Add("Collect bananas for a \nspeed boost and +3 score!");
        hints.Add("Beware of frogs!");
        hints.Add("You can use moving platforms \nto get across!");
        hints.Add("Trampolines give you \na jump boost!");
        hints.Add("Collect bananas for a \nspeed boost and +3 score!");
        hints.Add("Falling or losing all\nyour health means death, score resets to 0!");
        hints.Add("Finishing the level \ngives you extra points!");

        StartCoroutine(ShowHints());
    }

    IEnumerator ShowHints()
    {
        for (int i = 0; i < hints.Count; i++)
        {
            hintController.ShowHint(hints[i], 6f);
            yield return new WaitForSeconds(4f);
        }
    }
}
