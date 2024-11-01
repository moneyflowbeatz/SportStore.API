using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportStore.Tests
{
    public class RoleLocalRepositoryTests
{
    private readonly RoleLocalRepository _RoleLocalRepository;
    public RoleLocalRepositoryTests()
    {
        _RoleLocalRepository = new RoleLocalRepository();
    }

    [Fact]
    public void CreateRole_ShouldReturnNewRoleWithGeneratedId()
    {
        // Arrange
        var newRole = new Role { Name = "Test Role" };
        // Act
        var createdRole = _RoleLocalRepository.CreateRole(newRole);
        // Assert
        Assert.NotNull(createdRole);
        Assert.NotEqual(Guid.Empty, createdRole.Id);
        Assert.Equal(newRole.Name, createdRole.Name);
    }

    [Fact]
    public void DeleteRole_ShouldReturnTrueAndRemoveRole()
    {
        // Arrange
        var RoleLocalRepository = new RoleLocalRepository();
        var testRole = new Role { Id = Guid.NewGuid(), Name = "Test Role" };
        RoleLocalRepository.Roles.Add(testRole);

        // Act
        bool result = RoleLocalRepository.DeleteRole(testRole.Id);

        // Assert
        Assert.True(result);
        Assert.Empty(RoleLocalRepository.Roles);
    }

    [Fact]
    public void EditRole_ShouldUpdateExistingRole()
    {
        // Arrange
        var RoleLocalRepository = new RoleLocalRepository();
        var originalRole = new Role { Id = Guid.NewGuid(), Name = "Original Role" };
        RoleLocalRepository.Roles.Add(originalRole);

        // Act
        var editedRole = new Role { Id = originalRole.Id, Name = "Edited Role" };
        var result = RoleLocalRepository.EditRole(editedRole, originalRole.Id);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Edited Role", result.Name);
        Assert.Single(RoleLocalRepository.Roles);
    }

    [Fact]
    public void FindRoleById_ShouldReturnRoleByValidId()
    {
        // Arrange
        var RoleLocalRepository = new RoleLocalRepository();
        var testRole = new Role { Id = Guid.NewGuid(), Name = "Test Role" };
        RoleLocalRepository.Roles.Add(testRole);

        // Act
        var foundRole = RoleLocalRepository.FindRoleById(testRole.Id);

        // Assert
        Assert.NotNull(foundRole);
        Assert.Equal(testRole.Id, foundRole.Id);
        Assert.Equal(testRole.Name, foundRole.Name);
    }

    [Fact]
    public void FindRoleById_ShouldThrowExceptionForInvalidId()
    {
        // Arrange
        var RoleLocalRepository = new RoleLocalRepository();

        // Act & Assert
        Assert.Throws<Exception>(() => RoleLocalRepository.FindRoleById(Guid.NewGuid()));
    }

    [Fact]
    public void GetRoles_ShouldReturnAllRoles()
    {
        // Arrange
        var RoleLocalRepository = new RoleLocalRepository();
        var testRole1 = new Role { Id = Guid.NewGuid(), Name = "Role 1" };
        var testRole2 = new Role { Id = Guid.NewGuid(), Name = "Role 2" };
        RoleLocalRepository.Roles.Add(testRole1);
        RoleLocalRepository.Roles.Add(testRole2);

        // Act
        var Roles = RoleLocalRepository.GetRoles();

        // Assert
        Assert.NotNull(Roles);
        Assert.Equal(2, Roles.Count);
        Assert.Contains(testRole1, Roles);
        Assert.Contains(testRole2, Roles);
    }

    [Fact]
    public void FindRoleById_ShouldThrowExceptionForNonExistentId()
    {
        // Arrange
        var RoleLocalRepository = new RoleLocalRepository();

        // Act & Assert
        Assert.Throws<Exception>(() => RoleLocalRepository.FindRoleById(Guid.NewGuid()));
    }
}
}