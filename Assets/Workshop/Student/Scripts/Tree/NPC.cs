using Solution;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class NPC : Identity
{
    public DialogueUI dialogueUI;
    public DialogueSequen sequen;
    public bool canTalk = true;

    private void Awake()
    {
        // ´Ö§ DialogueSequen ·ÕèµÔ´ÍÂÙèº¹ GameObject à´ÕÂÇ¡Ñ¹ÁÒãªéÍÑµâ¹ÁÑµÔ
        if (sequen == null)
        {
            sequen = GetComponent<DialogueSequen>();
        }
    }

    public override bool Hit()
    {
        // µÃÇ¨ÊÍºÇèÒÊÒÁÒÃ¶¤ØÂä´éËÃ×ÍäÁè
        if (canTalk)
        {
            if (dialogueUI != null && sequen != null)
            {
                dialogueUI.Setup(sequen);
            }
            else
            {
                Debug.LogWarning("DialogueUI ËÃ×Í DialogueSequen ÂÑ§äÁèä´éµÑé§¤èÒã¹ Inspector!");
            }
            return false;
        }
        else
        {
            Debug.Log("I not need to talk to you");
            return false;
        }
    }
}