using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Role", menuName = "Role")]
public class Role : ScriptableObject
{
    [SerializeField]
    private List<RoleContainer> roles;

    
    private List<RoleContainer> ShuffleList(List<RoleContainer> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int rand = Random.Range(0, i + 1);
            (list[i], list[rand]) = (list[rand], list[i]);
        }

        return list;
    }

    public List<RoleContainer> GetRoles()
    {
        List<RoleContainer> copy_roles = new List<RoleContainer>();
        for (int i = 0; i < roles.Count; i++)
        {
            copy_roles.Add(roles[i]);
        }

        copy_roles = ShuffleList(copy_roles);
        return copy_roles;
    }
}