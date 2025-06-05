using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPanel : MonoBehaviour
{
    public GameObject DeathScreen;

    // Start is called before the first frame update
    void PlayerDied()
    {
        DeathScreen.SetActive(true);
    }
}
