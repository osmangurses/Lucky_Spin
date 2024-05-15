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

    // T�r bilgisine g�re Sprite d�nd�rme
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
