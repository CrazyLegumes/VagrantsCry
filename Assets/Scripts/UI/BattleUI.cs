using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BattleUI : MonoBehaviour {
    public GameObject SelectUI;
    public Image cursor;
    public Image Info;
    public Slider HP;
    public Slider MP;
    public Text HPText;
    public Text MPText;

    public void EnableInfo()
    {
        
        Info.gameObject.SetActive(true);
    }

    public void EnableSelect()
    {
        SelectUI.SetActive(true);
    }

    public void DisableInfo()
    {
        
        Info.gameObject.SetActive(false);
    }

    public void DisableSelect()
    {
        SelectUI.SetActive(false);
    }
	// Use this for initialization
	void Start () {
        DisableInfo();
        DisableSelect();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateStats();
	}

    void UpdateStats()
    {
        HPText.text = "HP: " + Player.Instance.Stats.Health + "/" + Player.Instance.Stats.MaxHealth;
        MPText.text = "MP: " + Player.Instance.Stats.Mana + "/" + Player.Instance.Stats.MaxMana;
        HP.maxValue = Player.Instance.Stats.MaxHealth;
        HP.value = Mathf.Lerp(HP.value, Player.Instance.Stats.Health, 1);
        MP.maxValue = Player.Instance.Stats.MaxMana;
        MP.value = Mathf.Lerp(MP.value, Player.Instance.Stats.Mana, 10);

        if (Inputs.A_Button())
        {
            Player.Instance.HealMe(200);
        }
    }
}
