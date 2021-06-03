using ShoeLovers.Repo;
using ShoeLovers.Repo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoeLovers.Api.Managers
{
    public class UserSelectionManager : IUserSelectionManager
    {
        IUnitOfWork _uow;
        public UserSelectionManager(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task AddAsync(UserSelectionEntity entity)
        {
            if ((await _uow.UserSelectionRepository.ListAsync(entity.UserId)).All(e => e.ShoeSizeId != entity.ShoeSizeId))
            {
                var added = await _uow.UserSelectionRepository.AddAsync(entity);
                _uow.Complete();
            }
        }

        public async Task AddRangeAsync(IEnumerable<UserSelectionEntity> entitiesList)
        {
            foreach (var entity in entitiesList)
                await AddAsync(entity);
        }

        public async Task DeleteAsync(Guid userId)
        {
            await _uow.UserSelectionRepository.DeleteAsync(userId);
            _uow.Complete();
        }

        public async Task<IEnumerable<UserSelectionEntity>> ListAsync(Guid userId)
        {
            return await _uow.UserSelectionRepository.ListAsync(userId);
        }

        /// <summary>
        /// Compare input list to database list, 
        /// DELETE if not inside input list, but inside database
        /// ADD if not inside database, but inside input list
        /// </summary>
        /// <param name="entitiesList">all user selected shoe sizes</param>
        /// <returns></returns>
        public async Task PersistRangeExactAsync(IEnumerable<UserSelectionEntity> entitiesList)
        {
            //loop for each unique user id
            foreach (var userId in entitiesList.Select(e => e.UserId).Distinct())
            {
                var inputEntities = entitiesList.Where(e => e.UserId == userId);

                //loop through all database entities for the user id
                foreach (var databaseEntity in await _uow.UserSelectionRepository.ListAsync(userId).ConfigureAwait(false))
                    //delete from Database if not found inside input data
                    if (!inputEntities.Any(e => e.ShoeSizeId == databaseEntity.ShoeSizeId))
                    {
                        await _uow.UserSelectionRepository.DeleteAsync(databaseEntity);
                    }

                //add all input entities while checking for pre-existing database entries
                await AddRangeAsync(entitiesList);
            }

            _uow.Complete();
        }
    }
}
