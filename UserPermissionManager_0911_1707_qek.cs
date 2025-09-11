// 代码生成时间: 2025-09-11 17:07:55
using System;
# 扩展功能模块
using System.Collections.Generic;
using System.Linq;

namespace UserPermissionSystem
# 添加错误处理
{
    // Define the possible user roles
# NOTE: 重要实现细节
    public enum UserRole
    {
# TODO: 优化性能
        Admin,
# 改进用户体验
        User,
        Guest
    }

    // Define the permissions that can be granted to users
    public enum Permission
    {
        Read,
        Write,
        Delete
    }

    // User class to represent a user in the system
# 扩展功能模块
    public class User
# 优化算法效率
    {
        public int UserId { get; set; }
        public string Username { get; set; }
# NOTE: 重要实现细节
        public UserRole Role { get; set; }
        public HashSet<Permission> Permissions { get; set; } = new HashSet<Permission>();

        public User(int userId, string username, UserRole role)
        {
# 添加错误处理
            UserId = userId;
            Username = username;
            Role = role;
# NOTE: 重要实现细节
        }
    }
# 扩展功能模块

    // Manages user permissions
# 优化算法效率
    public class PermissionManager
# 优化算法效率
    {
        private Dictionary<int, User> users;

        public PermissionManager()
        {
            users = new Dictionary<int, User>();
        }

        // Adds a new user to the system
        public void AddUser(User user)
# 优化算法效率
        {
            if (user == null)
# 增强安全性
                throw new ArgumentNullException(nameof(user), "User cannot be null.");
            
            users[user.UserId] = user;
        }

        // Grants a permission to a user
# FIXME: 处理边界情况
        public void GrantPermission(int userId, Permission permission)
        {
            if (!users.TryGetValue(userId, out User user))
                throw new KeyNotFoundException($"User with ID {userId} not found.");
            
            user.Permissions.Add(permission);
# 优化算法效率
        }

        // Revokes a permission from a user
# FIXME: 处理边界情况
        public void RevokePermission(int userId, Permission permission)
# NOTE: 重要实现细节
        {
            if (!users.TryGetValue(userId, out User user))
# NOTE: 重要实现细节
                throw new KeyNotFoundException($"User with ID {userId} not found.");
# 优化算法效率
            
            user.Permissions.Remove(permission);
# 扩展功能模块
        }

        // Checks if a user has a specific permission
        public bool HasPermission(int userId, Permission permission)
        {
# 增强安全性
            if (!users.TryGetValue(userId, out User user))
                throw new KeyNotFoundException($"User with ID {userId} not found.");
            
            return user.Permissions.Contains(permission);
        }
    }

    // Program class to demonstrate the usage of PermissionManager
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                PermissionManager permissionManager = new PermissionManager();

                // Adding users
# 添加错误处理
                User admin = new User(1, "AdminUser", UserRole.Admin);
                User guest = new User(2, "GuestUser", UserRole.Guest);
# TODO: 优化性能
                permissionManager.AddUser(admin);
                permissionManager.AddUser(guest);
# 添加错误处理

                // Granting permissions
                permissionManager.GrantPermission(1, Permission.Read);
                permissionManager.GrantPermission(1, Permission.Write);
                permissionManager.GrantPermission(2, Permission.Read);

                // Checking permissions
                Console.WriteLine(\$"Does user 1 have read permission? {permissionManager.HasPermission(1, Permission.Read)}");
                Console.WriteLine(\$"Does user 2 have write permission? {permissionManager.HasPermission(2, Permission.Write)}");

                // Revoking permissions
                permissionManager.RevokePermission(1, Permission.Read);

                // Checking permissions after revocation
                Console.WriteLine(\$"Does user 1 have read permission after revocation? {permissionManager.HasPermission(1, Permission.Read)}");
# 扩展功能模块
            }
            catch (Exception ex)
            {
                Console.WriteLine(\$"An error occurred: {ex.Message}");
            }
        }
# 优化算法效率
    }
}
# 扩展功能模块
