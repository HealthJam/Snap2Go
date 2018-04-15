using UnityEngine;
using System;
using System.Collections;

[Serializable]
public class BadgeUnlockRecord
{
    public int badgeId;
    public int unlockTime; //DateTime.UtcNow.Millisecond

    public BadgeUnlockRecord(int badgeId, int unlockTime)
    {
        this.badgeId = badgeId;
        this.unlockTime = unlockTime;
    }
}
