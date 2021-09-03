using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using Xunit;
using Abp.Application.Services.Dto;
using Projeto.AspNet.Users;
using Projeto.AspNet.Users.Dto;
using Projeto.AspNet.Roles.Dto;
using System;

namespace Projeto.AspNet.Tests.Users
{
    public class UserAppService_Tests : AspNetTestBase
    {
        private readonly IUserAppService _userAppService;

        public UserAppService_Tests()
        {
            _userAppService = Resolve<IUserAppService>();
        }

        [Fact]
        public async Task GetUsers_Test()
        {
            // Act
            var output = await _userAppService.GetAllAsync(new PagedUserResultRequestDto { MaxResultCount = 20, SkipCount = 0 });

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task CreateUser_Test()
        {
            // Act
            await _userAppService.CreateAsync(
                new CreateUserDto
                {
                    EmailAddress = "john@volosoft.com",
                    IsActive = true,
                    Name = "John",
                    Surname = "Nash",
                    Password = "123qwe",
                    UserName = "john.nash"
                });

            await UsingDbContextAsync(async context =>
            {
                var johnNashUser = await context.Users.FirstOrDefaultAsync(u => u.UserName == "john.nash");

                // Assert
                johnNashUser.ShouldNotBeNull();
            });
        }

        [Fact]
        public async Task UpdateUser_Test()
        {
            // Creating User to be Updated
            var johnNashUser = await _userAppService.CreateAsync(
               new CreateUserDto
               {
                   EmailAddress = "john@volosoft.com",
                   IsActive = true,
                   Name = "John",
                   Surname = "Nash",
                   Password = "123qwe",
                   UserName = "john.nash"
               });

            // Act
            await _userAppService.UpdateAsync(
                new UserDto
                {
                    Id = johnNashUser.Id,
                    EmailAddress = "john.nash@gmail.com",
                    IsActive = true,
                    Name = "John",
                    Surname = "Nash",
                    UserName = "john.nash"
                });

            await UsingDbContextAsync(async context =>
            {
                var User = await context.Users.FirstOrDefaultAsync(u => u.UserName == "john.nash");

                // Assert
                User.EmailAddress.ShouldNotBe("john@volosoft.com");
            });
        }

        [Fact]
        public async Task DeleteUser_Test()
        {
            // Creating User to be Deleted
            var johnNashUser = await _userAppService.CreateAsync(
               new CreateUserDto
               {
                   EmailAddress = "john@volosoft.com",
                   IsActive = true,
                   Name = "John",
                   Surname = "Nash",
                   Password = "123qwe",
                   UserName = "john.nash"
               });

            // Act
            await _userAppService.DeleteAsync(
                new EntityDto<long>
                {
                    Id = johnNashUser.Id
                });

            // Assert
            await Assert.ThrowsAnyAsync<Exception>(() => _userAppService.GetEntityById(johnNashUser.Id));
        }

        [Fact]
        public async Task ActivateUser_Test()
        {
            // Creating User to be Activated
            var johnNashUser = await _userAppService.CreateAsync(
               new CreateUserDto
               {
                   EmailAddress = "john@volosoft.com",
                   IsActive = true,
                   Name = "John",
                   Surname = "Nash",
                   Password = "123qwe",
                   UserName = "john.nash"
               });

            // Act
            await _userAppService.Activate(
                new EntityDto<long>
                {
                    Id = johnNashUser.Id
                });

            await UsingDbContextAsync(async context =>
            {
                var User = await context.Users.FirstOrDefaultAsync(u => u.Id == johnNashUser.Id);

                // Assert
                User.IsActive.ShouldBeTrue();
            });
        }

        [Fact]
        public async Task DeactivateUser_Test()
        {
            // Creating User to be Activated
            var johnNashUser = await _userAppService.CreateAsync(
               new CreateUserDto
               {
                   EmailAddress = "john@volosoft.com",
                   IsActive = true,
                   Name = "John",
                   Surname = "Nash",
                   Password = "123qwe",
                   UserName = "john.nash"
               });

            // Act
            await _userAppService.DeActivate(
                new EntityDto<long>
                {
                    Id = johnNashUser.Id
                });

            await UsingDbContextAsync(async context =>
            {
                var User = await context.Users.FirstOrDefaultAsync(u => u.Id == johnNashUser.Id);

                // Assert
                User.IsActive.ShouldBeFalse();
            });
        }

        [Fact]
        public async Task GetRoles_Test()
        {
            // Act
            ListResultDto<RoleDto> Roles = await _userAppService.GetRoles();

            // Assert
            Roles.ShouldNotBeNull();
        }

        [Fact]
        public async Task ChangeLanguage_Test()
        {
            // Arrange
            ChangeUserLanguageDto Language = new ChangeUserLanguageDto
            {
                LanguageName = "English"
            };

            Exception ex = null;

            // Act
            try
            {
                await _userAppService.ChangeLanguage(Language);
            }
            catch (Exception e)
            {
                ex = e;
            };

            // Assert
            ex.ShouldBeNull();
        }

        [Fact]
        public async Task ChangePassword_Test()
        {
            // Arrange
            ChangePasswordDto dto = new ChangePasswordDto
            {
                CurrentPassword = "123qwe",
                NewPassword = "qwe123"
            };

            // Act
            var changed = await _userAppService.ChangePassword(dto);

            // Assert
            changed.ShouldBeTrue();
        }

        [Fact]
        public async Task ResetPassword_Test()
        {
            // Arrange
            ResetPasswordDto dto = new ResetPasswordDto
            {
                AdminPassword = "123qwe",
                UserId = 2,
                NewPassword = "qwe123"
            };

            // Act
            var changed = await _userAppService.ResetPassword(dto);

            // Assert
            changed.ShouldBeTrue();
        }

        [Fact]
        public async Task GetUser_Test()
        {
            // Arrange
            var User = await _userAppService.CreateAsync(
                new CreateUserDto
                {
                    EmailAddress = "john@volosoft.com",
                    IsActive = true,
                    Name = "John",
                    Surname = "Nash",
                    Password = "123qwe",
                    UserName = "john.nash"
                });

            // Act
            var UserById = await _userAppService.GetEntityById(User.Id);

            // Assert
            UserById.ShouldNotBeNull();
        }
    }
}
