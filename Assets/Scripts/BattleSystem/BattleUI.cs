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
    public GameObject SkillTab;
    public Text Description;
    public Image DescriptionBox;

    public void EnableInfo()
    {
        
        Info.gameObject.SetActive(true);
    }

    public void EnableDesc()
    {
        DescriptionBox.gameObject.SetActive(true);
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


    public void EnableSkill()
    {
        if (SelectUI.activeInHierarchy)
            SkillTab.SetActive(true);

    }

    public void DisableDesc()
    {
        DescriptionBox.gameObject.SetActive(false);
    }


    public void DisableSkill()
    {
        SkillTab.SetActive(false);
    }
	// Use this for initialization
	void Start () {
        DisableInfo();
        DisableSelect();
        DisableSkill();
        DisableDesc();
	}
	
	// Update is called once per frame
	void Update () {
        UpdateStats();
	}

    void UpdateStats()
    {
        HPText.text = "HP: " + Player.instance.Stats.Health + "/" + Player.instance.Stats.MaxHealth;
        MPText.text = "MP: " + Player.instance.Stats.Mana + "/" + Player.instance.Stats.MaxMana;
        HP.maxValue = Player.instance.Stats.MaxHealth;
        HP.value = Mathf.Lerp(HP.value, Player.instance.Stats.Health, 1);
        MP.maxValue = Player.instance.Stats.MaxMana;
        MP.value = Mathf.Lerp(MP.value, Player.instance.Stats.Mana, 10);


    }
}
