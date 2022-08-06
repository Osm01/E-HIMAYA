using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public class CaseManager : MonoBehaviour
{
    [SerializeField] GameObject OmarChar;
    [SerializeField] GameObject SaraChar;
    [SerializeField] CinemachineVirtualCamera Cam2;
    private void Start()
    {
        if (UICharacterSelect.IndexSelectCharacter == 0)
        {
            OmarChar.SetActive(true);
            SaraChar.SetActive(false);
            Cam2.Follow = OmarChar.transform;
            Cam2.LookAt= OmarChar.transform;
        }
        else if(UICharacterSelect.IndexSelectCharacter == 1)
        {
            OmarChar.SetActive(false);
            SaraChar.SetActive(true);
            Cam2.Follow = SaraChar.transform;
            Cam2.LookAt = SaraChar.transform;
        }
        else
        {
            LoadSceneByIndex(6);
        }
    }

    public void LoadSceneByIndex( int IndexScene )
    {
        SceneManager.LoadScene(IndexScene);
    }

}
