using UnityEngine;
using UnityEngine.UI;
using TMPro; // ������Ѻ TextMeshPro

public class SkillNodeUI : MonoBehaviour
{
    // ��ҧ�ԧ�֧ Component UI
    [Header("UI References")]
    public Button button;
    public Image background;
    public TextMeshProUGUI skillNameText; // ���� public Text skillNameText;

    // ��ҧ�ԧ�֧������ Skill
    [HideInInspector] public Skill skillData;

    // ʶҹ��� (��˹�������ҹ��� Inspector)
    [Header("Colors")]
    public Color colorLearned = Color.yellow;
    public Color colorAvailable = Color.green;
    public Color colorLocked = Color.gray;

    public void Initialize(Skill skill)
    {
        this.skillData = skill;
        skillNameText.text = skill.name;

        // ��ҧ Listener ����͡��͹ ���ͻ�ͧ�ѹ��÷ӧҹ��ӫ�͹�������� UI
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(OnNodeClicked);

        UpdateUI();
    }

    public void UpdateUI()
    {
        if (skillData == null) return;

        if (skillData.isUnlocked) // ��� Skill �١���¹������� (Learned)
        {
            background.color = colorLearned;
            button.interactable = false; // ��ԡ�ա�����
        }
        else if (skillData.isAvailable) // ��� Skill �Ŵ��ͤ������¹����� (Available)
        {
            background.color = colorAvailable;
            button.interactable = true; // ��ԡ�������¹���
        }
        else // ��� Skill �ѧ�١��ͤ (Locked)
        {
            background.color = colorLocked;
            button.interactable = false; // ��ԡ�����
        }
    }

    private void OnNodeClicked()
    {
        if (skillData != null && skillData.isAvailable && !skillData.isUnlocked)
        {
            // ���¡���ʹ Unlock() 㹤��� Skill
            skillData.Unlock();

            // ����� UI �ء����ѻവʶҹ�
            if (SkillTreeUI.Instance != null)
            {
                SkillTreeUI.Instance.RefreshAllUI();
            }
        }
    }
}