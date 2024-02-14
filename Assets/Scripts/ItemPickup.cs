using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    private int apples = 0;
    Color orange = new Color(1f, 0.5f, 0f, 1f);
    [SerializeField] private Text ItemCounterText;

    private void Awake() {
        playerSprite = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Apple")) {
            Destroy(collision.gameObject);
            apples++;
            ItemCounterText.text = "Apples: " + apples;
            playerSprite.color = orange;
        }
    }
}
