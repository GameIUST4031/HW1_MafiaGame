using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TurnManager : MonoBehaviour
{
    [SerializeField] Role role;
    [SerializeField] Text text;
    [SerializeField] Image image;
    [SerializeField] Sprite sprite;

    private int index;
    private bool state;

    private List<RoleContainer> roles;

    // Start is called before the first frame update
    void Start()
    {
        roles = role.GetRoles();
    }

    void AnimateRollCard(Action ss)
    {
        StartCoroutine(AnimateRollCardProcess(ss));
    }

    private IEnumerator AnimateRollCardProcess(Action ss)
    {
        float constant  = 0.2f;
        while (image.transform.rotation.eulerAngles.y < 90)
        {
            image.transform.rotation = Quaternion.Euler(0, image.transform.rotation.eulerAngles.y+constant, 0);
            yield return null;
        }
        image.transform.rotation = Quaternion.Euler(0, 90, 0);
        ss.Invoke();
        while (image.transform.rotation.eulerAngles.y > 0 && image.transform.rotation.eulerAngles.y < 180)
        {
            image.transform.rotation = Quaternion.Euler(0, image.transform.rotation.eulerAngles.y-constant, 0);
            Debug.Log(image.transform.rotation.eulerAngles.y);
            yield return null;
        }
        image.transform.rotation = Quaternion.Euler(0, 0, 0);

    }
    void AnimateRollCard1(Action ss)
    {
        StartCoroutine(AnimateRollCardProcess1(ss));
    }

    private IEnumerator AnimateRollCardProcess1(Action ss)
    {
        float constant  = 0.2f;
        while (image.transform.rotation.eulerAngles.y < 90)
        {
            image.transform.rotation = Quaternion.Euler(0, image.transform.rotation.eulerAngles.y+constant, 0);
            yield return null;
        }

        image.transform.rotation = Quaternion.Euler(0, 90, 0);
        ss.Invoke();
        while (image.transform.rotation.eulerAngles.y > 0 && image.transform.rotation.eulerAngles.y < 180)
        {
            image.transform.rotation = Quaternion.Euler(0, image.transform.rotation.eulerAngles.y-constant, 0);
            Debug.Log(image.transform.rotation.eulerAngles.y);
            yield return null;
        }
        image.transform.rotation = Quaternion.Euler(0, 0, 0);

    }

    void Show_Role()
    {
        text.text = roles[index].roleName;
        image.sprite = roles[index].roleSprite;
        index++;
        state = true;
    }

    void Hide_Role()
    {
        text.text = "Show Role";
        image.sprite = sprite;
        state = false;
    }

    public void SetRole()
    {
        if (index == roles.Count)
        {
            text.text = "Exit";
            image.sprite = sprite;
            index++;
        }
        else if (index == roles.Count + 1)
        {
            SceneManager.LoadSceneAsync("MainMenu");
        }
        else
        {
            if (state)
            {
                AnimateRollCard(Hide_Role);
            }
            else
            {
                AnimateRollCard(Show_Role);
            }
        }
    }
}