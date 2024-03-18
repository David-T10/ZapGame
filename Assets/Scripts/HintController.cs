using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HintController : MonoBehaviour
{
    [SerializeField] public Text hintText;
    [SerializeField] private float maxWidth = 1000f;

    public void ShowHint(string message, float hintDuration)
    {
        hintText.text = message;
        hintText.enabled = true; 

        float messageLength = message.Length;
        float scaleFactor = Mathf.Clamp(1f + (messageLength * 0.02f), 1f, maxWidth / hintText.preferredWidth);
        hintText.rectTransform.localScale = new Vector3(scaleFactor, scaleFactor, 1f);

        StartCoroutine(HideHintAfterDelay(hintDuration));
    }

    private IEnumerator HideHintAfterDelay(float hintDuration)
    {
        yield return new WaitForSeconds(hintDuration);
        hintText.enabled = false; 
    }
}
