using UnityEngine;
using UnityEngine.UI;
public class GameManger : MonoBehaviour
{
    private int currentEnergy;
    [SerializeField] private int energyThreshHold = 3;
    [SerializeField] private GameObject boss;
    private bool bossCalled = false;
    [SerializeField] private Image energyBar;
    [SerializeField] private GameObject gameUI;
    void Start()
    {
        currentEnergy = 0;
        UpdateEnergyBar();
        boss.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddEnergy()
    {
        if (bossCalled)
        {
            return;
        }
        currentEnergy += 1;
        UpdateEnergyBar();
        if (currentEnergy == energyThreshHold)
        {
            CallBoss();
        }
    }

    private void CallBoss()
    {
        bossCalled = true;
        boss.SetActive(true);
        gameUI.SetActive(false);
    }
    private void UpdateEnergyBar()
    {
        if (energyBar != null)
        {
            float fillAmount = Mathf.Clamp01((float)currentEnergy / (float)energyThreshHold);
            energyBar.fillAmount = fillAmount;
        }
    }
}
