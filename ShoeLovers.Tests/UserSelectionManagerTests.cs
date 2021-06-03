using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShoeLovers.Repo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IntegrationTests
{
    [TestClass]
    public class UserSelectionManagerTests : IntegrationTestsBase
    {
        [TestMethod]
        public async Task AddUpdateUserSelection_TestDeleted()
        {

            var userId = Guid.NewGuid();

            await _userMgr.AddAsync(new UserSelectionEntity
            {
                UserId = userId,
                ShoeSizeId = 1
            });

            var readBack = await _userMgr.ListAsync(userId);

            Assert.AreEqual(1, readBack.Count());

            await Cleanup(userId);
        }

        [TestMethod]
        public async Task AddUpdateUserSelection_TestSameNotAdded()
        {

            var userId = Guid.NewGuid();

            await _userMgr.AddAsync(new UserSelectionEntity
            {
                UserId = userId,
                ShoeSizeId = 1
            });

            var readBack = await _userMgr.ListAsync(userId);

            Assert.AreEqual(1, readBack.Count());

            await _userMgr.AddAsync(new UserSelectionEntity
            {
                UserId = userId,
                ShoeSizeId = 1
            });

            readBack = await _userMgr.ListAsync(userId);

            Assert.AreEqual(1, readBack.Count());

            await Cleanup(userId);
        }

        [TestMethod]
        public async Task AddUpdateUserSelection_UpdateForLessSelections()
        {

            var userId = Guid.NewGuid();

            await _userMgr.AddRangeAsync(new List<UserSelectionEntity> {
                new UserSelectionEntity
                {
                    UserId = userId,
                    ShoeSizeId = 1
                },
                new UserSelectionEntity
                {
                    UserId = userId,
                    ShoeSizeId = 2
                },
                new UserSelectionEntity
                {
                    UserId = userId,
                    ShoeSizeId = 3
                }
            });

            var readBack = await _userMgr.ListAsync(userId);

            Assert.AreEqual(3, readBack.Count());

            await _userMgr.PersistRangeExactAsync(new List<UserSelectionEntity> {
                new UserSelectionEntity
                {
                    UserId = userId,
                    ShoeSizeId = 1
                }
            });

            readBack = await _userMgr.ListAsync(userId);

            Assert.AreEqual(1, readBack.Count());
            Assert.AreEqual(1, readBack.FirstOrDefault().ShoeSizeId);

            await Cleanup(userId);
        }

        [TestMethod]
        public async Task AddUpdateUserSelection_UpdateForMoreSelections()
        {

            var userId = Guid.NewGuid();

            await _userMgr.AddRangeAsync(new List<UserSelectionEntity> {
                new UserSelectionEntity
                {
                    UserId = userId,
                    ShoeSizeId = 1
                }
            });

            var readBack = await _userMgr.ListAsync(userId);

            Assert.AreEqual(1, readBack.Count());

            await _userMgr.PersistRangeExactAsync(new List<UserSelectionEntity> {
                new UserSelectionEntity
                {
                    UserId = userId,
                    ShoeSizeId = 1
                },
                new UserSelectionEntity
                {
                    UserId = userId,
                    ShoeSizeId = 2
                },
                new UserSelectionEntity
                {
                    UserId = userId,
                    ShoeSizeId = 3
                }
            });

            readBack = await _userMgr.ListAsync(userId);

            Assert.AreEqual(3, readBack.Count());

            await Cleanup(userId);
        }

        private async Task Cleanup(Guid userId)
        {
            await _userMgr.DeleteAsync(userId);

            var readBack = await _userMgr.ListAsync(userId);

            Assert.AreEqual(0, readBack.Count());
        }
    }
}
