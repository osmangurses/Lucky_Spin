using UnityEngine;

[CreateAssetMenu(fileName = "RewardSpriteMapping", menuName = "Reward/Sprite Mapping")]
public class RewardSpriteMapping : ScriptableObject
{
    [System.Serializable]
    public struct RewardSprite
    {
        public RewardType rewardType;
        public Sprite sprite;
    }

    public RewardSprite[] rewardSprites;

    public Sprite GetSpriteForRewardType(RewardType type)
    {
        foreach (var rewardSprite in rewardSprites)
        {
            if (rewardSprite.rewardType == type)
                return rewardSprite.sprite;
        }
        return null;
    }
}
