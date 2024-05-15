using UnityEngine;

[CreateAssetMenu(fileName = "New Reward", menuName = "Reward")]
public class Reward : ScriptableObject
{
    public RewardType rewardType; // Enum kullanýmý
    public int amount;
}
public enum RewardType
{
    Vest_Points,
    SubMachine_Points,
    Sniper_Points,
    SMG_Points,
    Shotgun_Points,
    Rifle_Points,
    Pistol_Points,
    Knife_Points,
    Armor_Points,
    Tier3_Sniper,
    Tier3_SMG,
    Tier3_Shotgun,
    Tier2_Rifle,
    Tier2_MLE,
    Tier1_Shotgun,
    Molotov,
    Healthshot2_Regenerator,
    Healthshot2_Neurostim,
    Grenade_M67,
    Grenade_M26,
    Bayonet_Summer_Vice,
    Bayonet_Easter_Time,
    Helmet_Pumpkin,
    Gold,
    Chest_Super_Nolight,
    Chest_Standart_Nolight,
    Chest_Small_Noligt,
    Chest_Silver_Nolight,
    Chest_Gold_Nolight,
    Chest_Bronze_Nolight,
    Chest_Big_Nolight,
    Cash,
    Baseball_Cap_Easter,
    Aviator_Glasses_Easter,
    Death





}
