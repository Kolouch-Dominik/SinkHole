using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthController : MonoBehaviour
{
    public static PlayerHealthController Instance { get; set; }

    [SerializeField]
    public int CurrentHealth
    {
        get;
        private set;
    }
    [field: SerializeField]
    public int MaxHealth { get; private set; }

    public float InvincLenght { get; set; } = 1f;
    public float InvincCount { get; set; }

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        CurrentHealth = MaxHealth;

        UIController.Instance.HealthSlider.maxValue = MaxHealth;
        UIController.Instance.HealthSlider.value = CurrentHealth;
        UIController.Instance.HealthText.text = CurrentHealth + " / " + MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (InvincCount > 0)
        {
            InvincCount -= Time.deltaTime;

            if (InvincCount <= 0)
            {
                ChangePlayerColorAlpha(1f);
            }
        }
    }

    public void DamagePlayer()
    {
        if (InvincCount <= 0)
        {

            CurrentHealth--;
            AudioManager.Instance.PlaySFX(11);

            MakePlayerInvincible(InvincLenght);

            if (CurrentHealth <= 0)
            {
                PlayerController.Instance.gameObject.SetActive(false);

                UIController.Instance.DeathScreen.SetActive(true);

                AudioManager.Instance.PlayGameOver();
                AudioManager.Instance.PlaySFX(8);
            }


            UIController.Instance.HealthSlider.value = CurrentHealth;
            UIController.Instance.HealthText.text = CurrentHealth + " / " + MaxHealth;
        }
    }

    private void ChangePlayerColorAlpha(float alpha)
    {
        var color = PlayerController.Instance.Body.color;
        PlayerController.Instance.Body.color = new Color(color.r, color.g, color.b, alpha);
    }

    public void MakePlayerInvincible(float lenght)
    {
        InvincCount = lenght;
        ChangePlayerColorAlpha(0.5f);
    }

    public void HealPlayer(int amount)
    {
        if (CurrentHealth + amount > MaxHealth)
            CurrentHealth = MaxHealth;
        else CurrentHealth += amount;

        UIController.Instance.HealthSlider.value = CurrentHealth;
        UIController.Instance.HealthText.text = CurrentHealth + " / " + MaxHealth;
    }
}
