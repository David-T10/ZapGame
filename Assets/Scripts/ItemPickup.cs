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
    private ScoreManager scoreManager;
    private SpriteRenderer playerSprite;
    Color orange = new Color(1f, 0.5f, 0f, 1f);
    Color yellow = new Color(1f, 0.92f, 0.016f, 1f);
    private Color originalSpriteColor;
    private float powerUpDuration = 4.0f;
    private int startingFruitsCount = 0;
    private int appleScore = 5;
    private int bananaScore = 3;
    private float doubleJumpVal;
    private float originalJumpVal;
    private float originalMovementSpeedVal;
    private float doubleMovementSpeedVal;
    [SerializeField] private Text scoreCounterText;
    [SerializeField] private AudioSource itemCollectionSoundEffect;

    private void Awake() {
        scoreManager = GameObject.FindObjectTypeOf<scoreManager>();
        playerMovement = GetComponent<PlayerMovement>();
        originalJumpVal = playerMovement.GetJumpValue();
        originalMovementSpeedVal = playerMovement.GetMovementSpeedValue();
        doubleMovementSpeedVal = originalMovementSpeedVal * 2;
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
            itemCollectionSoundEffect.Play();
            Destroy(collision.gameObject);
            fruitData.count++;
            playerSprite.color = fruitData.color;
            StartCoroutine(RevertColorAfter(powerUpDuration));

            if (collision.gameObject.tag == "Apple")
            {
                scoreManager.IncrementScore(appleScore);
                scoreCounterText.text = "Score: " + fruitData.count * appleScore;
                ApplePowerUp();
            }
            else if (collision.gameObject.tag == "Banana")
            {
                scoreCounterText.text = "Score: " + fruitData.count * bananaScore;
                BananaPowerUp();
            }
            fruitDataMap[collision.gameObject.tag] = fruitData;
        }
    }

    private void ApplePowerUp() {
        playerMovement.UpdateJumpCommand(doubleJumpVal);
        StartCoroutine(RevertJumpValAfter(powerUpDuration));
    }

    private void BananaPowerUp()
    {
        playerMovement.SetMovementSpeedValue(doubleMovementSpeedVal);
        StartCoroutine(RevertSpeedValAfter(powerUpDuration));
    }


    private IEnumerator RevertColorAfter(float timeDelay) {
        yield return new WaitForSeconds(timeDelay);
        playerSprite.color = originalSpriteColor;
    }

    private IEnumerator RevertJumpValAfter(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        playerMovement.UpdateJumpCommand(originalJumpVal);
    }

    private IEnumerator RevertSpeedValAfter(float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);
        playerMovement.SetMovementSpeedValue(originalMovementSpeedVal);
    }

}
