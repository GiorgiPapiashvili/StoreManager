﻿using StoreManager.Service.Interfaces.Repositories;
using StoreManager.Service.Interfaces.Services;

namespace StoreManager.Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Register(int employeeId, string username, string password)
        {
            if (username == null) throw new ArgumentNullException(nameof(username));
            if (password == null) throw new ArgumentNullException(nameof(password));

            try
            {
                _unitOfWork.BeginTransaction();
                _unitOfWork.UserRepository.Register(employeeId, username, password);
                _unitOfWork.CommitTransaction();
            }
            catch
            {
                _unitOfWork.RollBackTransaction();
                throw;
            }
        }

        public bool Login(string username, string password)
        {
            return _unitOfWork.UserRepository.Login(username, password);
        }

        public void ResetPassword(string username, string currentPassword, string newPassword)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _unitOfWork.UserRepository.ResetPassword(username, currentPassword, newPassword);
                _unitOfWork.CommitTransaction();
            }
            catch
            {
                _unitOfWork.RollBackTransaction();
                throw;
            }
        }

        public int GetId(string username)
        {
            return _unitOfWork.UserRepository.GetId(username);
        }

        public void LockUser(string username)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _unitOfWork.UserRepository.LockUser(username);
                _unitOfWork.CommitTransaction();
            }
            catch
            {
                _unitOfWork.RollBackTransaction();
                throw;
            }
        }

        public void UnlockUser(string username)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                _unitOfWork.UserRepository.UnlockUser(username);
                _unitOfWork.CommitTransaction();
            }
            catch
            {
                _unitOfWork.RollBackTransaction();
                throw;
            }
        }
    }
}
