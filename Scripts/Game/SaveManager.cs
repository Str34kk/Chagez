using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {

    public static SaveManager Instance { set; get; }
    public SaveState state;

    private void Awake()
    {
        Instance = this;
        Load();
    }

    public void Save()
    {
        PlayerPrefs.SetString("save", Helper.Serialize<SaveState>(state));
    }

    public void Load()
    {
        if (PlayerPrefs.HasKey("save"))
        {
            state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("save"));
        }
        else
        {
            state = new SaveState();
            Save();
        }
    }

    public bool IsSkinOwned(int index)
    {
        return (state.SkinOwned & (1 << index)) != 0;
    }

    public void UnlockSkin(int index)
    {
        state.SkinOwned |= 1 << index;
        Save();
    }

    public bool BuySkin(int index, int cost)
    {
        if(state.money >= cost)
        {
            state.money -= cost;
            UnlockSkin(index);
            Save();

            return true;
        }
        else
        {
            return false;
        }
    }

    //public void ResetSave()
    //{
    //    PlayerPrefs.DeleteKey("save");
    //}
}
