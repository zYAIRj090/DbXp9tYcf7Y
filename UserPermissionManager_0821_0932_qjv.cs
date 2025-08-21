// 代码生成时间: 2025-08-21 09:32:18
 * Features:
 * - Manage user roles and permissions
 * - Handle errors and exceptions
 * - Follow C# best practices
 * - Ensure maintainability and extensibility
 */

using System;
using System.Collections.Generic;
using System.Linq;

namespace UserPermissionSystem
{
    /// <summary>
    /// Represents a user role with associated permissions.
    /// </summary>
    public class Role
    {
        public string Name { get; set; }
        public List<string> Permissions { get; set; } = new List<string>();
    }

    /// <summary>
    /// Represents a user with their assigned roles.
    /// </summary>
    public class User
    {
        public string Username { get; set; }
        public List<Role> Roles { get; set; } = new List<Role>();

        /// <summary>
        /// Checks if the user has a specific permission.
        /// </summary>
        /// <param name="permission">The permission to check.</param>
        /// <returns>True if the user has the permission, otherwise false.</returns>
        public bool HasPermission(string permission)
        {
            return Roles.Any(role => role.Permissions.Contains(permission));
        }
    }

    public class UserPermissionManager
    {
        private List<User> users;
        private List<Role> roles;

        public UserPermissionManager()
        {
            users = new List<User>();
            roles = new List<Role>();
        }

        /// <summary>
        /// Adds a new user with the specified username.
        /// </summary>
        /// <param name="username">The username of the user to add.</param>
        public void AddUser(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                throw new ArgumentException("Username cannot be null or whitespace.");
            }

            if (users.Any(user => user.Username == username))
            {
                throw new InvalidOperationException("User already exists.");
            }

            users.Add(new User { Username = username });
        }

        /// <summary>
        /// Adds a new role with the specified name and permissions.
        /// </summary>
        /// <param name="name">The name of the role to add.</param>
        /// <param name="permissions">The permissions associated with the role.</param>
        public void AddRole(string name, List<string> permissions)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Role name cannot be null or whitespace.");
            }

            if (permissions == null || !permissions.Any())
            {
                throw new ArgumentException("Role must have at least one permission.");
            }

            if (roles.Any(role => role.Name == name))
            {
                throw new InvalidOperationException("Role already exists.");
            }

            roles.Add(new Role { Name = name, Permissions = permissions });
        }

        /// <summary>
        /// Assigns a role to a user.
        /// </summary>
        /// <param name="username">The username of the user to assign the role to.</param>
        /// <param name="roleName">The name of the role to assign.</param>
        public void AssignRole(string username, string roleName)
        {
            var user = users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            var role = roles.FirstOrDefault(r => r.Name == roleName);
            if (role == null)
            {
                throw new InvalidOperationException("Role not found.");
            }

            if (!user.Roles.Any(r => r.Name == roleName))
            {
                user.Roles.Add(role);
            }
        }

        /// <summary>
        /// Revokes a role from a user.
        /// </summary>
        /// <param name="username">The username of the user to revoke the role from.</param>
        /// <param name="roleName">The name of the role to revoke.</param>
        public void RevokeRole(string username, string roleName)
        {
            var user = users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            var role = user.Roles.FirstOrDefault(r => r.Name == roleName);
            if (role != null)
            {
                user.Roles.Remove(role);
            }
        }

        /// <summary>
        /// Checks if a user has a specific permission.
        /// </summary>
        /// <param name="username">The username of the user to check.</param>
        /// <param name="permission">The permission to check.</param>
        /// <returns>True if the user has the permission, otherwise false.</returns>
        public bool CheckPermission(string username, string permission)
        {
            var user = users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                throw new InvalidOperationException("User not found.");
            }

            return user.HasPermission(permission);
        }
    }
}
