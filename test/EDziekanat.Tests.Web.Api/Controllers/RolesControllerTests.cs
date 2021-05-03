﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EDziekanat.Application.Roles.Dto;
using EDziekanat.Core.Permissions;
using EDziekanat.Core.Roles;
using EDziekanat.EntityFramework;
using EDziekanat.Utilities.Collections;
using EDziekanat.Utilities.Extensions.PrimitiveTypes;
using Xunit;

namespace EDziekanat.Tests.Web.Api.Controllers
{
    public class RolesControllerTests : ApiTestBase
    {
        private readonly string _token;

        public RolesControllerTests()
        {
            _token = LoginAsAdminUserAndGetTokenAsync().Result;
        }

        [Fact]
        public async Task Should_Get_Roles()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/api/roles");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var responseGetRoles = await TestServer.CreateClient().SendAsync(requestMessage);
            Assert.Equal(HttpStatusCode.OK, responseGetRoles.StatusCode);

            var roles = await responseGetRoles.Content.ReadAsAsync<PagedList<RoleListOutput>>();
            Assert.True(roles.Items.Any());
        }

        [Fact]
        public async Task Should_Get_Role_For_Create()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/api/roles/" + Guid.Empty);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var responseGetRoles = await TestServer.CreateClient().SendAsync(requestMessage);
            Assert.Equal(HttpStatusCode.OK, responseGetRoles.StatusCode);

            var role = await responseGetRoles.Content.ReadAsAsync<GetRoleForCreateOrUpdateOutput>();
            Assert.True(string.IsNullOrEmpty(role.Role.Name));
        }

        [Fact]
        public async Task Should_Get_Role_For_Update()
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/api/roles/" + DefaultRoles.Member.Id);
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            var responseGetRoles = await TestServer.CreateClient().SendAsync(requestMessage);
            Assert.Equal(HttpStatusCode.OK, responseGetRoles.StatusCode);

            var role = await responseGetRoles.Content.ReadAsAsync<GetRoleForCreateOrUpdateOutput>();
            Assert.False(string.IsNullOrEmpty(role.Role.Name));
        }

        [Fact]
        public async Task Should_Create_Role()
        {
            var input = new CreateOrUpdateRoleInput
            {
                Role = new RoleDto
                {
                    Name = "TestRoleName_" + Guid.NewGuid()
                },
                GrantedPermissionIds = new List<Guid> { DefaultPermissions.MemberAccess.Id }
            };

            var requestMessage = new HttpRequestMessage(HttpMethod.Post, "/api/roles");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            requestMessage.Content = input.ToStringContent(Encoding.UTF8, "application/json");
            var responseAddRole = await TestServer.CreateClient().SendAsync(requestMessage);
            Assert.Equal(HttpStatusCode.Created, responseAddRole.StatusCode);

            var insertedRole = await DbContext.Roles.FirstAsync(r => r.Name == input.Role.Name);
            Assert.NotNull(insertedRole);
        }

        [Fact]
        public async Task Should_Update_Role()
        {
            var testRole = await CreateAndGetTestRoleAsync();

            var input = new CreateOrUpdateRoleInput
            {
                Role = new RoleDto
                {
                    Id = testRole.Id,
                    Name = "TestRoleName_Edited_" + Guid.NewGuid()
                },
                GrantedPermissionIds = new List<Guid> { DefaultPermissions.MemberAccess.Id }
            };

            var requestMessage = new HttpRequestMessage(HttpMethod.Put, "/api/roles");
            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            requestMessage.Content = input.ToStringContent(Encoding.UTF8, "application/json");
            var responseAddRole = await TestServer.CreateClient().SendAsync(requestMessage);
            Assert.Equal(HttpStatusCode.OK, responseAddRole.StatusCode);

            var dbContextFromAnotherScope = GetNewScopeServiceProvider().GetService<EDziekanatDbContext>();
            var editedTestRole = await dbContextFromAnotherScope.Roles.FindAsync(testRole.Id);
            Assert.Contains(editedTestRole.RolePermissions, rp => rp.PermissionId == DefaultPermissions.MemberAccess.Id);
        }

        [Fact]
        public async Task Should_Delete_Role()
        {
            var testRole = await CreateAndGetTestRoleAsync();
            var requestMessage = new HttpRequestMessage(HttpMethod.Delete, "/api/roles?id=" + testRole.Id);

            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _token);
            requestMessage.Content = new { id = testRole.Id }.ToStringContent(Encoding.UTF8, "application/json");
            var responseAddRole = await TestServer.CreateClient().SendAsync(requestMessage);
            Assert.Equal(HttpStatusCode.NoContent, responseAddRole.StatusCode);
        }
    }
}
