using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadgeManager : MonoBehaviour
{
    private const string UNLOCK_KEYS = "UNLOCK_KEYS";

    public Dictionary<int, Badge> globalBadges = new Dictionary<int, Badge>();

    public List<BadgeUnlockRecord> unlockBadgeRecords = new List<BadgeUnlockRecord>();

    private void Awake()
    {
        saveUnlockedBadges();
        loadUnlockedBadges();
    }

    void loadBadgeInfo()
    {
        //Load badge info into globalBadges
    }

    void loadUnlockedBadges()
    {
        string unlockedBadgesJson = PlayerPrefs.GetString(UNLOCK_KEYS);
        BadgeUnlockRecord[] badgeUnlockRecordArr = JsonHelper.getJsonArray<BadgeUnlockRecord>(unlockedBadgesJson);
        unlockBadgeRecords = new List<BadgeUnlockRecord>(badgeUnlockRecordArr);
    }

    void saveUnlockedBadges()
    {
        string unlockBadgeJson = JsonHelper.arrayToJson<BadgeUnlockRecord>(unlockBadgeRecords.ToArray());
        PlayerPrefs.SetString(UNLOCK_KEYS, unlockBadgeJson);
        PlayerPrefs.Save();
    }
}
