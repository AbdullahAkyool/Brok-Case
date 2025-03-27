using UnityEngine;

public class SaveSystem
{
    private const string WalkSpeedKey = "WALK_SPEED";
    private const string RunSpeedKey = "RUN_SPEED";
    private const string JumpPowerKey = "JUMP_POWER";

    public void Save(CharacterDataSO data)
    {
        PlayerPrefs.SetFloat(WalkSpeedKey, data.walkSpeed);
        PlayerPrefs.SetFloat(RunSpeedKey, data.runSpeed);
        PlayerPrefs.SetFloat(JumpPowerKey, data.jumpPower);
        PlayerPrefs.Save();

        Debug.Log("Datas saved.");
    }

    public void Load(CharacterDataSO data)
    {
        if (PlayerPrefs.HasKey(WalkSpeedKey))
        {
            data.walkSpeed = PlayerPrefs.GetFloat(WalkSpeedKey);
            data.runSpeed = PlayerPrefs.GetFloat(RunSpeedKey);
            data.jumpPower = PlayerPrefs.GetFloat(JumpPowerKey);

            Debug.Log("Loading Successful.");
        }
        else
        {
            Debug.LogWarning("Loading Failed. No data found.");
        }
    }

    public void Reset()
    {
        PlayerPrefs.DeleteKey(WalkSpeedKey);
        PlayerPrefs.DeleteKey(RunSpeedKey);
        PlayerPrefs.DeleteKey(JumpPowerKey);
        Debug.Log("Datas deleted.");
    }
}
