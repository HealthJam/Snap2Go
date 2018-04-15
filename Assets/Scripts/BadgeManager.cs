using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class BadgeManager : MonoBehaviour
{
    private const string UNLOCK_RECORDS = "UNLOCK_RECORDS";

    public Dictionary<int, Badge> globalBadges = new Dictionary<int, Badge>();

    public List<BadgeUnlockRecord> unlockBadgeRecords = new List<BadgeUnlockRecord>();

    private void Awake()
    {
        loadBadgeInfo();
        loadUnlockedBadges();
    }

    //Load badge info into globalBadges
    private void loadBadgeInfo()
    {
        String path = "Assets/Resources/BadgeList.json";
        String json;
        using (FileStream fs = new FileStream(path, FileMode.Open))
        {
            using (StreamReader reader = new StreamReader(fs))
            {
                json = reader.ReadToEnd();
            }
        }

        Badge[] badgeList = JsonHelper.getJsonArray<Badge>(json);
        foreach(Badge badge in badgeList)
        {
            globalBadges[badge.id] = badge;
        }
    }

    private void loadUnlockedBadges()
    {
        string unlockedBadgesJson = PlayerPrefs.GetString(UNLOCK_RECORDS);
        BadgeUnlockRecord[] badgeUnlockRecordArr = JsonHelper.getJsonArray<BadgeUnlockRecord>(unlockedBadgesJson);
        unlockBadgeRecords = new List<BadgeUnlockRecord>(badgeUnlockRecordArr);
    }

    private void saveUnlockedBadges()
    {
        string unlockBadgeJson = JsonHelper.arrayToJson<BadgeUnlockRecord>(unlockBadgeRecords.ToArray());
        PlayerPrefs.SetString(UNLOCK_RECORDS, unlockBadgeJson);
        PlayerPrefs.Save();
    }

    public List<Badge> getUnlockedBadges()
    {
        List<Badge> unlockedBadges = new List<Badge>();
        foreach (BadgeUnlockRecord record in unlockBadgeRecords)
        {
            unlockedBadges.Add(globalBadges[record.badgeId]);
        }
        return unlockedBadges;
    }

    public BadgeUnlockRecord getUnlockedBadgeRecord(int id)
    {
        foreach(BadgeUnlockRecord record in unlockBadgeRecords)
        {
            if(id == record.badgeId)
            {
                return record;
            }
        }
        return null;
    }
    
    public void unlockBadge(int id)
    {
        BadgeUnlockRecord unlockRecord = new BadgeUnlockRecord(id, DateTime.UtcNow.Millisecond);
        unlockBadgeRecords.Add(unlockRecord);
        saveUnlockedBadges();   //TODO optimize
    }

    //Only run this in Unity Editor 
    private void testGenerateBadgeList()
    {
        Badge badge0 = new Badge(0, "Embark on an Adventure", "Start an expedition", 200, "default");
        Badge badge1 = new Badge(1, "Food for Thought", "Collect any 10 ingredients", 200, "default");
        Badge badge2 = new Badge(2, "Tis the Season", "Collect 5 seasonings", 200, "default");
        Badge badge3 = new Badge(3, "Spicy!", "Collect at least 10 spicy ingredients", 200, "default");
        Badge badge4 = new Badge(4, "Sweet Tooth", "Collect at least 10 sweet ingredients", 200, "default");
        Badge badge5 = new Badge(5, "Green Thumb", "Collect 10 vegetables", 200, "default");
        Badge badge6 = new Badge(6, "Big Cheese", "Collect 10 cheese ingredients", 200, "default");
        Badge badge7 = new Badge(7, "Cheese Whizard", "Collect 20 cheese ingredients", 200, "default");
        Badge badge8 = new Badge(8, "Bread and butter", "Collect 10 bread and/or butter ingredients", 200, "default");
        Badge badge9 = new Badge(9, "Forbidden Fruit", "Collect 10 fruit ingredients", 200, "default");
        Badge badge10 = new Badge(10, "Go Bananas", "Collect 5 bananas", 200, "default");

        List<Badge> badgeList = new List<Badge>
        {
            badge0,
            badge1,
            badge2,
            badge3,
            badge4,
            badge5,
            badge6,
            badge7,
            badge8,
            badge9,
            badge10,
        };
        string json = JsonHelper.arrayToJson<Badge>(badgeList.ToArray());
        Debug.Log(json);

        string path = "Assets/Resources/BadgeList.json";
        using (FileStream fs = new FileStream(path, FileMode.Create))
        {
            using (StreamWriter writer = new StreamWriter(fs))
            {
                writer.Write(json);
            }
        }
		#if UNITY_EDITOR
        UnityEditor.AssetDatabase.Refresh();
		#endif
    }
}