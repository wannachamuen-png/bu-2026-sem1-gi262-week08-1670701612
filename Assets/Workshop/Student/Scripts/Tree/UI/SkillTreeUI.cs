using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTreeUI : MonoBehaviour
{
    public static SkillTreeUI Instance;

    [Header("Required References")]
    public SkillBook skillBook;
    public SkillNodeUI skillNodePrefab;
    public Transform skillNodeContainer; // ���˹觷����ҧ Node UI

    // **��ǹ����������������Ѻ��èѴ��� Scroll View Content**
    public RectTransform contentSkill; // �ҡ Content RectTransform �ͧ Scroll View �����

    // ���������Ѻ�Դ����ͺࢵ�ͧ Skill Node ���١���ҧ
    private float minX = 0f;
    private float maxX = 0f;
    private float minY = 0f;
    private float maxY = 0f; // ���ͧ�ҡ Y ���繤��ź

    // ��˹���Ҵ Node ���������ҧ�������ӹǳ���¢��
    private readonly float NODE_WIDTH = 150f;
    private readonly float NODE_HEIGHT = 150f;
    private readonly float X_SPACING = 300f; // ������ҧ��������ҧ Node
    private readonly float Y_SPACING = 200f; // ������ҧ��������ҧ���

    private Dictionary<Skill, SkillNodeUI> skillUIMap = new Dictionary<Skill, SkillNodeUI>();

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        if (skillBook == null || contentSkill == null)
        {
            Debug.LogError("SkillBook ���� ContentSkill reference is missing!");
            return;
        }

        StartCoroutine(DelayShowTree());
    }

    private void OnEnable()
    {
        // �ѻവ UI ������Դ˹�ҵ�ҧ���������
        RefreshAllUI();
    }

    IEnumerator DelayShowTree()
    {
        yield return new WaitForSeconds(0.1f);

        // �硤�����ʹ��¢ͧ Root Skill
        if (skillBook == null || skillBook.attackSkillTree == null || skillBook.attackSkillTree.rootSkill == null)
        {
            Debug.LogError("attackSkillTree ���� rootSkill �� null!");
            yield break;
        }

        // ��ҧ Node ��ҡ�͹���ҧ����
        ClearAllNodes();

        // ���絢ͺࢵ�������
        minX = 0f;
        maxX = 0f;
        minY = 0f;
        maxY = 0f;

        // ��������ҧ UI Nodes �������ҡ Skill Tree (�����˹�������� 0, 0)
        CreateAllSkillNodes(skillBook.attackSkillTree.rootSkill, Vector2.zero);

        // **�ӹǳ��С�˹���Ҵ Content �ͧ Scroll View**
        CalculateAndSetContentSize();

        // �ѻവ UI �����á
        RefreshAllUI();
    }

    /// <summary>
    /// ��ҧ Node UI ��������ҧ����͡������
    /// </summary>
    private void ClearAllNodes()
    {
        foreach (Transform child in skillNodeContainer)
        {
            Destroy(child.gameObject);
        }
        skillUIMap.Clear();
    }

    private void CalculateAndSetContentSize()
    {
        if (skillUIMap.Count == 0) return;

        // �ӹǳ�������ҧ: �ҡ�����ش�֧����ش (�ǡ�ͺ��硹���)
        float contentWidth = (maxX - minX) + NODE_WIDTH + 50f; // +50f ��� Margin

        // �ӹǳ�����٧: �ҡ�ش�٧�ش (0) �֧�ش����ش (minY) (�ǡ�ͺ��硹���)
        float contentHeight = Mathf.Abs(minY) + NODE_HEIGHT + 50f; // +50f ��� Margin

        // ��˹���Ҵ���Ѻ RectTransform �ͧ Content
        contentSkill.sizeDelta = new Vector2(contentWidth, contentHeight);
    }

    /// <summary>
    /// ǹ����������ҧ Skill Node UI ����ӴѺ���
    /// </summary>
    private void CreateAllSkillNodes(Skill currentSkill, Vector2 position)
    {
        if (currentSkill == null || skillUIMap.ContainsKey(currentSkill)) return;

        // 1. ���ҧ Node UI
        SkillNodeUI newNode = Instantiate(skillNodePrefab, skillNodeContainer);
        newNode.Initialize(currentSkill);
        skillUIMap.Add(currentSkill, newNode);

        // ��˹����˹�
        RectTransform rt = newNode.GetComponent<RectTransform>();
        rt.localPosition = position;

        // 2. �Դ����ͺࢵ�ͧ Node ���١���ҧ���
        float nodeHalfWidth = NODE_WIDTH / 2f;
        float nodeHalfHeight = NODE_HEIGHT / 2f;

        minX = Mathf.Min(minX, position.x - nodeHalfWidth);
        maxX = Mathf.Max(maxX, position.x + nodeHalfWidth);
        minY = Mathf.Min(minY, position.y - nodeHalfHeight);
        maxY = Mathf.Max(maxY, position.y + nodeHalfHeight);

        // 3. ���ҧ Node ����Ѻ Skill �Ѵ���ӴѺ��� (�١)
        int numChildren = currentSkill.nextSkills.Count;

        // �ӹǳ���˹�������鹢ͧ�١���á ������� Node �����������觡�ҧ
        float totalWidth = (numChildren - 1) * X_SPACING;
        float startX = position.x - (totalWidth / 2f);

        for (int i = 0; i < numChildren; i++)
        {
            Skill nextSkill = currentSkill.nextSkills[i];

            // ���˹��١�Ѵ仨������ҡ startX ��������
            Vector2 nextPos = new Vector2(
                startX + (i * X_SPACING),
                position.y - Y_SPACING // ŧ�˹�觪��
            );

            CreateAllSkillNodes(nextSkill, nextPos);
        }
    }

    public void RefreshAllUI()
    {
        foreach (var uiNode in skillUIMap.Values)
        {
            if (uiNode != null)
            {
                uiNode.UpdateUI();
            }
        }
    }

    public void CloseUI()
    {
        gameObject.SetActive(false);
    }
}