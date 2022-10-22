using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class SavePlayerData
{

    public string _name, desc;
    public int maxhp, hp, maxmp, mp, maxattack, attack, maxmagic, magic, maxdefence, defence, maxspeed, speed;

    //�÷��̾� ���� �̹��� (0.face ~ 9.weaponL)
    //�� : 3������
    //���� : 3������
    public string[] armor;
    public string[] weapon;
    public string[] parts;

    //��ų
    public string skillname;
    public string skilldesc;

}



