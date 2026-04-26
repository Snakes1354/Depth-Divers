using UnityEngine;
using System.Collections;

public class ChestOpen : Interactable
{

    public GameObject chestui;
    [SerializeField] private CanvasGroup ChestCanvas;

    private bool isOpen;
    private bool OpenOnce;
    public float initialHealth;
    public float initialSpeed;
    public int initialDamage;

    public void Awake()
    {
        if (ChestCanvas == null)
        {
            ChestCanvas = GetComponentInChildren<CanvasGroup>();
        }

        chestui.SetActive(false);
        ChestCanvas.alpha = 0;
    }

    protected override void Interact()
    {
        if (OpenOnce) return;

        chestui.SetActive(true);
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None;
        promptMessage = "";
        Time.timeScale = 0f;
        ChestCanvas.alpha = 1;

        isOpen = true;
        OpenOnce = true;
    }

    private void CloseChest()
    {
        chestui.SetActive(false);

        Cursor.visible = false; 
        Cursor.lockState = CursorLockMode.Locked;

        Time.timeScale = 1f;
        ChestCanvas.alpha = 0;

        isOpen = false;
    }

    public void SpeedBuff()
    {
        StartCoroutine(SpeedTime());
        StartCoroutine(DelayChestClose());
    }

    public void DamageBuff()
    {
        StartCoroutine(DamageTime());
        StartCoroutine(DelayChestClose());
    }

    public void HealthBuff()
    {
        StartCoroutine(HealthTime());
        StartCoroutine(DelayChestClose());
    }

    private IEnumerator SpeedTime()
    {
        initialSpeed = StatManager.Instance.MovementSpeed;

        StatManager.Instance.MovementSpeed *= 2f;

        yield return new WaitForSecondsRealtime(60f);

        StatManager.Instance.MovementSpeed = initialSpeed;
    }

    private IEnumerator DamageTime()
    {
        initialDamage = StatManager.Instance.damage;
        StatManager.Instance.damage *= 2;

        yield return new WaitForSecondsRealtime(60f);

        StatManager.Instance.damage = initialDamage;
    }

    private IEnumerator HealthTime()
    {
        initialHealth = PlayerStats.Instance.maxHealth;

        PlayerStats.Instance.maxHealth *= 2f;
        PlayerStats.Instance.currentHealth = PlayerStats.Instance.maxHealth;
        PlayerStats.Instance.healthBar.SetSliderMax(PlayerStats.Instance.maxHealth); // Updates the slider max to make it so you can have more health
        PlayerStats.Instance.healthBar.SetSlider(PlayerStats.Instance.currentHealth); // Updates the currenthealth variable from the playerstats script
        
        yield return new WaitForSecondsRealtime(60f);

        PlayerStats.Instance.maxHealth = initialHealth;
        PlayerStats.Instance.currentHealth = PlayerStats.Instance.maxHealth;
        PlayerStats.Instance.healthBar.SetSliderMax(PlayerStats.Instance.maxHealth); // Updates the slider max to make it so you can have more health
        PlayerStats.Instance.healthBar.SetSlider(PlayerStats.Instance.currentHealth); // Updates the currenthealth variable from the playerstats script
    }

    private IEnumerator DelayChestClose()
    {
        yield return null;
        CloseChest();
    }
    
}