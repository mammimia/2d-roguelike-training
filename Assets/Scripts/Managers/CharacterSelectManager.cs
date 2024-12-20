using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectManager : MonoBehaviour
{
    public static CharacterSelectManager instance;

    public PlayerController activePlayer;

    public CharacterSelector activeCharSelector;

    private void Awake()
    {
        instance = this;
    }
}
