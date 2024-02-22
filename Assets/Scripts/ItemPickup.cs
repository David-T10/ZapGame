using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ItemPickup;

public class ItemPickup : MonoBehaviour
{
    private PlayerMovement playerMovement;

    public struct FruitData
    {
        public Color color;
        public int count;

        public FruitData(Color color, int count)
        {
            this.color = color;
            this.count = count;
        }
    }

    private Dictionary<string, FruitData> fruitDataMap = new Dictionary<string, FruitData>();

    private SpriteRenderer playerSprite;
    Color orange = new Color(1f, 0.5f, 0f, 1f);
    Color yellow = new Color(1f, 0.92f, 0.016f, 1f);
    private Color originalSpriteColor;
    private float powerUpDuration = 10.0f;
    private int startingFruitsCount = 0;
    private float doubleJumpVal;
    private float originalJumpVal;
    [SerializeField] private Text appleCounterText;
    [SerializeField] private Text bananaCounterText;

    private void Awake() {
        playerMovement = GetComponent<PlayerMovement>();
        originalJumpVal = playerMovement.GetJumpValue();
        doubleJumpVal = originalJumpVal * 2;
        playerSprite = GetComponent<SpriteRenderer>();
        originalSpriteColor = playerSprite.color;
        fruitDataMap.Add("Apple", new FruitData(orange, startingFruitsCount));
        fruitDataMap.Add("Banana", new FruitData(yellow, startingFruitsCount));

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (fruitDataMap.ContainsKey(collision.gameObject.tag))
        {
            
            FruitData fruitData = fruitDataMap[collision.gameObject.tag];
            Destroy(collision.gameObject);
            fruitData.count++;
            playerSprite.color = fruitData.color;
            StartCoroutine(RevertColorAfter(powerUpDuration));

            if (collision.gameObject.tag == "Apple")
            {
                appleCounterText.text = "Apples: " + fruitData.count;
                ApplePowerUp();
                StartCoroutine(RevertJumpValAfter(powerUpDuration));
            }
            else if (collision.gameObject.tag == "Banana")
            {
                bananaCounterText.text = "Bananas: " + fruitData.count;
                BananaPowerUp();
            }
            fruitDataMap[collision.gameObject.tag] = fruitData;
        }
    }

    private void ApplePowerUp() {
        playerMovement.SetJumpValue(doubleJumpVal);
    }

    private void BananaPowerUp()
    {
    }


    private IEnumerator RevertColorAfter(float timeDelay) {
        yield return new WaitForSeconds(timeDelay);
        playerSprite.color = originalSpriteColor;
        playerMovement.SetJumpValue(originalJumpVal);
    }

    private IEnumerator RevertJumpValAfter(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        playerMovement.SetJumpValue(originalJumpVal);
    }

}
