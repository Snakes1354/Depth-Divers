using UnityEngine;
using System.Collections;

public class ChestOpen : Interactable
{
    public static ChestOpen Instance;
    // I used a static so that my ChestOpen can be accessed from other scripts.

    public GameObject chestui;
    public CanvasGroup ChestCanvas;

    private bool isOpen;
    private bool OpenOnce;
    public float initialHealth;
    public float initialSpeed;
    public int initialDamage;

    private void Update()
    {
        if (isOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseChest();
        }
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
        CloseChest();
    }

    public void DamageBuff()
    {
        StartCoroutine(DamageTime());
        CloseChest();
    }

    public void HealthBuff()
    {
        StartCoroutine(HealthTime());
        CloseChest();
    }

    public IEnumerator SpeedTime()
    {
        initialSpeed = StatManager.Instance.MovementSpeed;

        StatManager.Instance.MovementSpeed *= 2f;

        yield return new WaitForSeconds(60f);

        StatManager.Instance.MovementSpeed = initialSpeed;
        StatManager.Instance.MovementSpeed /= 2f;
    }

    public IEnumerator DamageTime()
    {
        initialDamage = StatManager.Instance.damage;
        StatManager.Instance.damage *= 2;

        yield return new WaitForSeconds(60f);

        StatManager.Instance.damage = initialDamage;
        StatManager.Instance.damage /= 2;
    }

    public IEnumerator HealthTime()
    {
        initialHealth = PlayerStats.Instance.maxHealth;

        PlayerStats.Instance.maxHealth *= 2f;
        PlayerStats.Instance.currentHealth = PlayerStats.Instance.maxHealth;
        PlayerStats.Instance.healthBar.SetSliderMax(PlayerStats.Instance.maxHealth); // Updates the slider max to make it so you can have more health
        PlayerStats.Instance.healthBar.SetSlider(PlayerStats.Instance.currentHealth); // Updates the currenthealth variable from the playerstats script
        
        yield return new WaitForSeconds(60f);

        PlayerStats.Instance.maxHealth = initialHealth;
        PlayerStats.Instance.currentHealth = PlayerStats.Instance.maxHealth;
        PlayerStats.Instance.healthBar.SetSliderMax(PlayerStats.Instance.maxHealth); // Updates the slider max to make it so you can have more health
        PlayerStats.Instance.healthBar.SetSlider(PlayerStats.Instance.currentHealth); // Updates the currenthealth variable from the playerstats script
    }

    private void Awake()
    {
        if(Instance == null)
        Instance = this;
        else
        Destroy(gameObject); // Destroys the gameobject
        // Makes it so that there can't be more than one StatManager in my game.
    }
}