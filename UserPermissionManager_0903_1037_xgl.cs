// 代码生成时间: 2025-09-03 10:37:27
using System;
using System.Collections.Generic;

namespace UserPermissionSystem
{
    // Define an enum for different user roles
    public enum UserRole {
        Administrator,
        Moderator,
        StandardUser
    }

    // Define a class to represent user permissions
    public class UserPermission
    {
        public string UserId { get; set; }
        public UserRole Role { get; set; }
    }

    // Define a class to manage user permissions
    public class UserPermissionManager
    {
        private Dictionary<string, UserPermission> _userPermissions;

        public UserPermissionManager()
        {
            _userPermissions = new Dictionary<string, UserPermission>();
        }

        // Add a new user with a specific role
        public void AddUser(string userId, UserRole role)
        {
            if (string.IsNullOrEmpty(userId))
            {
                throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));
            }

            if (_userPermissions.ContainsKey(userId))
            {
                throw new InvalidOperationException("User already exists.");
            }

            _userPermissions[userId] = new UserPermission { UserId = userId, Role = role };
        }

        // Remove a user from the system
        public void RemoveUser(string userId)
        {
            if (!_userPermissions.ContainsKey(userId))
            {
                throw new KeyNotFoundException("User not found.");
            }

            _userPermissions.Remove(userId);
        }

        // Update a user's role
        public void UpdateUserRole(string userId, UserRole newRole)
        {
            if (!_userPermissions.ContainsKey(userId))
            {
                throw new KeyNotFoundException("User not found.");
            }

            _userPermissions[userId].Role = newRole;
        }

        // Check if a user has a specific role
        public bool CheckUserRole(string userId, UserRole role)
        {
            if (!_userPermissions.ContainsKey(userId))
            {
                throw new KeyNotFoundException("User not found.");
            }

            return _userPermissions[userId].Role == role;
        }

        // Get a user's role
        public UserRole? GetUserRole(string userId)
        {
            if (!_userPermissions.ContainsKey(userId))
            {
                throw new KeyNotFoundException("User not found.");
            }

            return _userPermissions[userId].Role;
        }
    }
}
