using UnityEngine;
using System.Collections;

public class InputManager : ScriptableObject
{
    public bool UFPS;
    public KeyCode reloadWeapon = KeyCode.R;
    public KeyCode throwGrenade = KeyCode.G;

    public KeyCode SplitItem;
    public KeyCode InventoryKeyCode = KeyCode.E;
    public KeyCode StorageKeyCode;
    public KeyCode CharacterSystemKeyCode = KeyCode.E;
    public KeyCode CraftSystemKeyCode;
}
