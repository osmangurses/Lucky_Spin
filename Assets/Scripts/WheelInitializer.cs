using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WheelInitializer : MonoBehaviour
{
    public static WheelInitializer instance;

    public Wheel wheel;
    public RewardSpriteMapping rewardSpriteMapping;

    public GameObject[] wheelCells;

    void Start()
    {
        instance = this;
        InitializeWheel();
    }

    public void InitializeWheel()
    {
        for (int i = 0; i < wheel.rewards.Count && i < wheelCells.Length; i++)
        {
          
            Image rewardImage = wheelCells[i].GetComponentInChildren<Image>();
            TextMeshProUGUI rewardText = wheelCells[i].GetComponentInChildren<TextMeshProUGUI>();

            if (rewardImage != null && rewardText != null)
            {
               
                Sprite rewardSprite = rewardSpriteMapping.GetSpriteForRewardType(wheel.rewards[i].rewardType);
                if (rewardSprite != null)
                {
                    rewardImage.sprite = rewardSprite;
                    rewardImage.SetNativeSize();
                }

                
                rewardText.text = "X"+wheel.rewards[i].amount.ToString();
            }
        }
    }
}
