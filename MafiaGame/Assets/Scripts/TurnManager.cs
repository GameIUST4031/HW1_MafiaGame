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
                Hide_Role();
            }
            else
            {
                Show_Role();
            }
        }
    }
}