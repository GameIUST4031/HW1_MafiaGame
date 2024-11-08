using UnityEngine;
using System.Collections.Generic;

namespace RoleManager_mine
{
    public class RoleManager : MonoBehaviour
    {
        public enum Role
        {
            Doctor,
            Sniper,
            Detective,
            Mayor,
            Freemason,
            Savior,
            Citizen,
            Godfather,
            Mafia,
            MaskedMafia,
            MurdererMafia
        }

        public List<Role> GetRoles(int playerCount)
        {
            List<Role> roles = new List<Role>();

            // Role configuration based on player count
            if (playerCount == 8)
            {
                roles.AddRange(new Role[]
                {
                    Role.Doctor, Role.Sniper, Role.Detective, Role.Citizen, Role.Citizen, Role.Godfather, Role.Mafia,
                    Role.MaskedMafia
                });
            }
            else if (playerCount == 10)
            {
                roles.AddRange(new Role[]
                {
                    Role.Doctor, Role.Sniper, Role.Detective, Role.Mayor, Role.Citizen, Role.Citizen, Role.Citizen,
                    Role.Godfather, Role.Mafia, Role.MaskedMafia
                });
            }
            else if (playerCount == 12)
            {
                roles.AddRange(new Role[]
                {
                    Role.Doctor, Role.Sniper, Role.Detective, Role.Mayor, Role.Freemason, Role.Savior, Role.Citizen,
                    Role.Citizen, Role.Godfather, Role.Mafia, Role.MaskedMafia, Role.MurdererMafia
                });
            }

            // Shuffle roles
            roles = ShuffleList(roles);

            return roles;
        }

        // Simple shuffle function
        private List<Role> ShuffleList(List<Role> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int rand = Random.Range(0, i + 1);
                (list[i], list[rand]) = (list[rand], list[i]);
            }

            return list;
        }
    }
}

