using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Image healthPointImage;
    public Image healthPointEffect;

    private character_movement player;
    private float hurtSpeed = 0.0005f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<character_movement>();
    }

    private void Update()
    {
        healthPointImage.fillAmount = player.currentHP / player.maxHP;

        if (healthPointEffect.fillAmount >= healthPointImage.fillAmount)
        {
            healthPointEffect.fillAmount -= hurtSpeed;
        }
        else
        {
            healthPointEffect.fillAmount = healthPointImage.fillAmount;
        }
    }

}