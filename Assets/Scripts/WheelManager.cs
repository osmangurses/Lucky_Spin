using UnityEngine;
using UnityEngine.UI;

public class WheelManager : MonoBehaviour
{
    public Wheel wheelData;
    public Image wheelImage,cursorImage;
    public Sprite bronzeWheelSprite;
    public Sprite silverWheelSprite;
    public Sprite goldWheelSprite;
    public Sprite bronzeCursorSprite;
    public Sprite silverCursorSprite;
    public Sprite goldCursorSprite;
    public int spinCount = 0;

    private void UpdateWheelAppearance()
    {
        if (spinCount % 30 == 0) // Her 30 çevirmede gold
        {
            wheelImage.sprite = goldWheelSprite;
            cursorImage.sprite = goldCursorSprite;
            UpdateRewards(RewardMode.Gold);
        }
        else if (spinCount % 5 == 0) // Her 5 çevirmede silver
        {
            wheelImage.sprite = silverWheelSprite;
            cursorImage.sprite = silverCursorSprite;
            UpdateRewards(RewardMode.Silver);
        }
        else // Normal çark
        {
            wheelImage.sprite = bronzeWheelSprite;
            cursorImage.sprite = bronzeCursorSprite;
            UpdateRewards(RewardMode.Normal);
        }
    }

    private void UpdateRewards(RewardMode mode)
    {
        int[] rewardTypeCounts = new int[System.Enum.GetValues(typeof(RewardType)).Length];
        RewardType forcedRewardType = RewardType.Death;

        for (int i = 0; i < wheelData.rewards.Count; i++)
        {
            RewardType newRewardType;
            do
            {
                newRewardType = (RewardType)Random.Range(0, System.Enum.GetValues(typeof(RewardType)).Length);
                if (mode == RewardMode.Silver || mode == RewardMode.Gold)
                {
                    newRewardType = (RewardType)Random.Range(1, System.Enum.GetValues(typeof(RewardType)).Length); // Death hariç
                }
            } while (rewardTypeCounts[(int)newRewardType] >= 2);

            rewardTypeCounts[(int)newRewardType]++;
            wheelData.rewards[i].rewardType = newRewardType;
            wheelData.rewards[i].amount = (mode == RewardMode.Gold) ? Random.Range(100, 201) : Random.Range(10, 101);
        }

        if (mode == RewardMode.Normal)
        {
            int deathIndex = Random.Range(0, wheelData.rewards.Count);
            wheelData.rewards[deathIndex].rewardType = forcedRewardType; // Death'i garanti et
            wheelData.rewards[deathIndex].amount = 0;
        }
    }

    public void Spin()
    {
        spinCount++;
        UpdateWheelAppearance();
        // Çark döndürme iþlemi burada gerçekleþtirilecek
    }

    private enum RewardMode
    {
        Normal,
        Silver,
        Gold
    }
}
