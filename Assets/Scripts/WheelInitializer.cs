using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheelInitializer : MonoBehaviour
{
    public static WheelInitializer instance;

    public Wheel wheel; // Wheel scriptine referans
    public RewardSpriteMapping rewardSpriteMapping; // Sprite mapping scriptable object'e referans

    public GameObject[] wheelCells; // �ark�n h�cre objeleri

    void Start()
    {
        instance = this;
        InitializeWheel();
    }

    public void InitializeWheel()
    {
        for (int i = 0; i < wheel.rewards.Count && i < wheelCells.Length; i++)
        {
            // Her cell objesinden Image ve Text componentlerini al
            Image rewardImage = wheelCells[i].GetComponentInChildren<Image>();
            TextMeshProUGUI rewardText = wheelCells[i].GetComponentInChildren<TextMeshProUGUI>();

            if (rewardImage != null && rewardText != null)
            {
                // Sprite'� atay�n
                Sprite rewardSprite = rewardSpriteMapping.GetSpriteForRewardType(wheel.rewards[i].rewardType);
                if (rewardSprite != null)
                {
                    rewardImage.sprite = rewardSprite;
                    rewardImage.SetNativeSize();
                }

                // Miktar� metin olarak ayarlay�n
                rewardText.text = "X"+wheel.rewards[i].amount.ToString();
            }
        }
    }
}
