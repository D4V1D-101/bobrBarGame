using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField]
    private UnityEngine.UI.Image hpImage;

    public void UpdateHealthBar(HealthController healthController)
    {
        hpImage.fillAmount = healthController.remainingHealthPercentage;
    }
}
