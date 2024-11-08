using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Role", menuName = "Role")]
public class Role : ScriptableObject
{
    [SerializeField]
    private List<RoleContainer> roles;

    public List<RoleContainer> GetRoles()
    {
        List<RoleContainer> copy_roles = new List<RoleContainer>();
        for (int i = 0; i < roles.Count; i++)
        {
            copy_roles.Add(roles[i]);
        }

        return copy_roles;
    }
}