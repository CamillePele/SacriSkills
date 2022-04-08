using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class SkillsManager : MonoBehaviour
{
    [SerializeField] private Skill[] skills;
    [SerializeField] private Button[] buttons;
    [SerializeField] private CompétenceDatas[] skillDatas;
    
    [SerializeField] private SetCompétence[] sacrificeButtons;
    [SerializeField] private InfosPannel sacrificeInfosPanel;
    
    [SerializeField] private List<Skill> sacrificedSkills;

    public void ResetSkills()
    {
        foreach (Skill component in skills)
        {
            component.enabled = false;
        }
    }
    
    public List<Skill> GetMostUsedSkills()
    {
        List<Skill> skills = this.skills.ToList();
        Debug.Log(String.Join(" ", skills.AsEnumerable().Select(x => Array.IndexOf(this.skills, x) +" "+ x.activeTime).Reverse().ToList()));
        List<Skill> mostUsed = skills.AsEnumerable().OrderBy(x => x.activeTime).Reverse().ToList();
        Debug.Log(String.Join(" ", mostUsed.AsEnumerable().Select(x => Array.IndexOf(this.skills, x) +" "+ x.activeTime).ToList()));
        List<Skill> result = mostUsed.AsEnumerable().Where(s => sacrificedSkills.Contains(s) == false).ToList();

        return result;
    }

    public void EnableSkill(int index)
    {
        ResetSkills();
        skills[index].enabled = true;
    }

    private List<(Skill, int)> SkillsToIds(Skill[] skills)
    {
        return skills.AsEnumerable().Select(x => (x, Array.IndexOf(this.skills, x))).ToList();
    }

    public void SetupSacrifice()
    {
        List<Skill> list = GetMostUsedSkills();
        for (int i = 0; i < sacrificeButtons.Length; i++)
        {
            var image = skillDatas[SkillsToIds(list.ToArray())[i].Item2];
            sacrificeButtons[i].SetImage(image);
        }

        sacrificeInfosPanel.SetupInfos(skillDatas[SkillsToIds(list.ToArray())[0].Item2]);
    }
    
    public void Sacrifice(int index)
    {
        int id = SkillsToIds(GetMostUsedSkills().ToArray())[index].Item2;
        sacrificedSkills.Add(skills[id]);

        print("index : " + index);
        print("id : " + id);
        
        buttons[id].interactable = false;
    }
}
