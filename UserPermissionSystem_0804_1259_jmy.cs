// 代码生成时间: 2025-08-04 12:59:58
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

// Define a class to represent a Role
public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Permission> Permissions { get; set; } = new List<Permission>();

    public Role(string name)
    {
        Name = name;
    }
}

// Define a class to represent a Permission
public class Permission
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }

    public Permission(string name, string description)
    {
        Name = name;
        Description = description;
    }
}

// Define a class to represent a User
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public List<Role> Roles { get; set; } = new List<Role>();

    public User(string username)
    {
        Username = username;
    }
}

// Define a class to manage permissions
public class PermissionManager
{
    private List<User> users = new List<User>();
    private List<Role> roles = new List<Role>();
    private List<Permission> permissions = new List<Permission>();

    // Add a new user
    public void AddUser(User user)
    {
        users.Add(user);
    }

    // Add a new role
    public void AddRole(Role role)
    {
        roles.Add(role);
    }

    // Add a new permission
    public void AddPermission(Permission permission)
    {
        permissions.Add(permission);
    }

    // Assign a role to a user
    public void AssignRoleToUser(User user, Role role)
    {
        user.Roles.Add(role);
    }

    // Grant a permission to a role
    public void GrantPermissionToRole(Role role, Permission permission)
    {
        role.Permissions.Add(permission);
    }

    // Check if a user has a specific permission
    public bool HasPermission(User user, Permission permission)
    {
        foreach (Role role in user.Roles)
        {
            if (role.Permissions.Any(p => p.Id == permission.Id))
            {
                return true;
            }
        }
        return false;
    }
}

// Main entry point of the application
class Program
{
    static void Main(string[] args)
    {
        PermissionManager manager = new PermissionManager();

        // Create roles
        Role adminRole = new Role("Admin");
        Role userRole = new Role("User");

        // Create permissions
        Permission viewPermission = new Permission("View", "Permission to view data");
        Permission editPermission = new Permission("Edit", "Permission to edit data");

        // Create users
        User alice = new User("Alice");
        User bob = new User("Bob");

        // Add roles and permissions to the manager
        manager.AddRole(adminRole);
        manager.AddRole(userRole);
        manager.AddPermission(viewPermission);
        manager.AddPermission(editPermission);

        // Assign roles and permissions
        manager.AssignRoleToUser(alice, adminRole);
        manager.GrantPermissionToRole(adminRole, viewPermission);
        manager.GrantPermissionToRole(adminRole, editPermission);
        manager.AssignRoleToUser(bob, userRole);
        manager.GrantPermissionToRole(userRole, viewPermission);

        // Check permissions
        Console.WriteLine($"Alice has view permission: {manager.HasPermission(alice, viewPermission)}
        Console.WriteLine($"Bob has edit permission: {manager.HasPermission(bob, editPermission)}
    }
}