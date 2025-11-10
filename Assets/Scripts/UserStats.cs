using UnityEngine;

public class UserStats
{
    public string playerName;
    public Vector3 playerPosition;
    public int playerHealth;
    public int playerExp;
}

public static class Stats
{
    public static UserStats userStats = new UserStats();
}
