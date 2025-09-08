// 代码生成时间: 2025-09-09 00:43:44
 * It handles user roles and permissions, allowing for easy expansion and maintenance.
 */
using System;
using System.Collections.Generic;

namespace UserPermissionSystem
{
    /// <summary>
    /// Represents a user permission.
    /// </summary>
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    /// <summary>
    /// Represents a user role with associated permissions.
    /// </summary>
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Permission> Permissions { get; set; } = new List<Permission>();
    }

    /// <summary>
    /// Manages user permissions and roles.
    /// </summary>
    public class UserPermissionManager
    {
        private List<Role> roles;
        private List<Permission> permissions;

        public UserPermissionManager()
        {
            roles = new List<Role>();
            permissions = new List<Permission>();
        }

        /// <summary>
        /// Adds a new permission to the system.
        /// </summary>
        /// <param name="permission">The permission to add.</param>
        public void AddPermission(Permission permission)
        {
            if (permission == null)
                throw new ArgumentNullException(nameof(permission));
            
            if (permissions.Exists(p => p.Name == permission.Name))
                throw new InvalidOperationException("Permission already exists.");
            
            permissions.Add(permission);
        }

        /// <summary>
        /// Adds a new role to the system with associated permissions.
        /// </summary>
        /// <param name="role">The role to add.</param>
        public void AddRole(Role role)
        {
            if (role == null)
                throw new ArgumentNullException(nameof(role));
            
            if (roles.Exists(r => r.Name == role.Name))
                throw new InvalidOperationException("Role already exists.");
            
            roles.Add(role);
        }

        /// <summary>
        /// Assigns permissions to a role.
        /// </summary>
        /// <param name="roleId">The ID of the role to update.</param>
        /// <param name="permissions">The permissions to assign.</param>
        public void AssignPermissionsToRole(int roleId, List<Permission> permissions)
        {
            if (permissions == null)
                throw new ArgumentNullException(nameof(permissions));
            
            var role = roles.Find(r => r.Id == roleId);
            if (role == null)
                throw new InvalidOperationException("Role not found.");
            
            role.Permissions.Clear();
            foreach (var permission in permissions)
            {
                if (!permissionExists(permission.Id))
                    throw new InvalidOperationException("Permission not found.");
                role.Permissions.Add(permission);
            }
        }

        /// <summary>
        /// Checks if a permission exists by ID.
        /// </summary>
        /// <param name="permissionId">The ID of the permission to check.</param>
        /// <returns>True if the permission exists, false otherwise.</returns>
        private bool permissionExists(int permissionId)
        {
            return permissions.Exists(p => p.Id == permissionId);
        }
    }
}
