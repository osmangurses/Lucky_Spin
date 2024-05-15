using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using TMPro;
using UnityEngine.UI;
using System.Collections.Generic;

public class WheelSpinner : MonoBehaviour, IPointerClickHandler
{
    public GameObject wheel;
    public Wheel wheelData;
    public WheelManager wheelManager;
    public RewardSpriteMapping rewardSpriteMapping; // RewardSpriteMapping scriptine referans
    public GameObject deathPanel; // Death panel için referans
    public GameObject collectedRewardPanel; // CollectedReward panel için referans
    public Image rewardImage; // CollectedReward panelindeki Image için referans
    public TextMeshProUGUI rewardText; // CollectedReward panelindeki TextMeshProUGUI için referans
    private bool isSpinning = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        Spin();
    }

    public void Spin()
    {
        if (!isSpinning)
        {
            isSpinning = true;
            int totalRotation = Random.Range(5, 10) * 360 + Random.Range(1, 8) * 45; // Rastgele tam dönüþler + bir kýsmi dönüþ
            wheel.transform.DORotate(new Vector3(0, 0, -totalRotation), 3.0f, RotateMode.FastBeyond360)
                .SetEase(Ease.OutQuad)
                .OnComplete(() =>
                {
                    DetectStoppedCell();
                });
        }
    }

    void DetectStoppedCell()
    {
        float finalZ = wheel.transform.eulerAngles.z;
        finalZ = (360 - finalZ) % 360;
        int cellIndex = Mathf.RoundToInt(finalZ / 45.0f);
        cellIndex = 7 - cellIndex;
        if (cellIndex == 8) cellIndex = 0;

        Reward currentReward = wheelData.rewards[cellIndex]; 

        if (currentReward.rewardType == RewardType.Death)
        {
            deathPanel.SetActive(true);
            collectedRewardPanel.SetActive(false);
        }
        else
        {
            deathPanel.SetActive(false);
            collectedRewardPanel.SetActive(true);
            rewardImage.sprite = rewardSpriteMapping.GetSpriteForRewardType(currentReward.rewardType); // Ödül ikonunu RewardSpriteMapping'den al
            rewardImage.SetNativeSize();
            rewardText.text = "X "+currentReward.amount.ToString(); // Ödül miktarýný güncelle
        }
        wheelManager.Spin(); // Çark döndürülmeden önce ödülleri rastgele güncelle
        WheelInitializer.instance.InitializeWheel();
        isSpinning = false;
    }

}
