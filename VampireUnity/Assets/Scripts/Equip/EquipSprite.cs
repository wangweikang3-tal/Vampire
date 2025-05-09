using System;
using System.Collections.Generic;
using UnityEngine;

public class EquipSprite : XSingleton<EquipSprite>
{
    [NonSerialized] public Dictionary<string, Sprite> equipSpriteDic = new Dictionary<string, Sprite>();
    public Sprite primaryCloak;
    public Sprite primaryCloth;
    public Sprite primaryRing;
    public Sprite primaryNecklace;
    public Sprite primaryShoe;
    public Sprite primaryHelmet;
    protected override void Awake()
    {
        equipSpriteDic.Add("PrimaryCloak", primaryCloak);
        equipSpriteDic.Add("PrimaryCloth", primaryCloth);
        equipSpriteDic.Add("PrimaryRing", primaryRing);
        equipSpriteDic.Add("PrimaryNecklace", primaryNecklace);
        equipSpriteDic.Add("PrimaryShoe", primaryShoe);
        equipSpriteDic.Add("PrimaryHelmet", primaryHelmet);
    }
}
