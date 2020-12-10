using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unit, IMapper mapper)
        {
            this._unitOfWork = unit;
            this._mapper = mapper;
        }
        public void AddComplaint(int id, string desc)
        {
            try
            {
                Complaint complaint = new Complaint
                {
                    Id = _unitOfWork.ComplaintRepository.GetAll().Last().Id + 1,
                    Description = desc,
                    IsChecked = false,
                    IsClosed = false,
                    UserComplaint = _unitOfWork.UserRepository
                    .GetByIdWithDetails(id).Result
                };
                _unitOfWork.ComplaintRepository.AddAsync(complaint);
                _unitOfWork.UserRepository.GetByIdAsync(id)
                    .Result.Complaints
                    .Add(complaint);
                 _unitOfWork.UserRepository.Update(
                     _unitOfWork.UserRepository.GetByIdAsync(id).Result);
            }
            catch (Exception ex)
            {
                string message = "Cannot add user complaint";
                throw new LogicException(message, ex);
            }
        }

        public void AddUser(UserDTO user)
        {
            try
            {
                _unitOfWork.UserRepository.AddAsync(_mapper.Map<User>(user));
            }
            catch (Exception ex)
            {
                string message = "Cannot add user";
                throw new LogicException(message, ex);
            }
        }

        public void DeleteComplaint(int idUser, int idComp)
        {
            try
            {
                _unitOfWork.UserRepository.GetByIdAsync(idUser)
                    .Result.Complaints.Remove(_unitOfWork.ComplaintRepository.GetByIdAsync(idComp).Result);
                _unitOfWork.ComplaintRepository.DeleteByIdAsync(idComp);
            }
            catch (Exception ex)
            {
                string message = "Cannot delete user complaint";
                throw new LogicException(message, ex);
            }
        }

        public IQueryable<UserDTO> GetAll()
        {
            try
            {
                return _unitOfWork.UserRepository.GetAllWithDetails()
                    .Select(x => _mapper.Map<UserDTO>(x));
            }
            catch (Exception ex)
            {
                string message = "Cannot get users";
                throw new LogicException(message, ex);
            }
        }

        public IQueryable<ComplaintDTO> GetAllComplaints(int id)
        {
            try
            {
                return _unitOfWork.UserRepository.GetByIdWithDetails(id)
                    .Result.Complaints
                    .Select(x => _mapper.Map<ComplaintDTO>(x))
                    .AsQueryable();
            }
            catch (Exception ex)
            {
                string message = "Cannot get user complaints";
                throw new LogicException(message, ex);
            }
        }

        public UserDTO GetById(int id)
        {
            try
            {
                return _mapper.Map<UserDTO>(
                    _unitOfWork.UserRepository.GetByIdWithDetails(id));
            }
            catch (Exception ex)
            {
                string message = "Cannot get user";
                throw new LogicException(message, ex);
            }
        }

        public ComplaintDTO GetComplaintById(int idUser, int idComp)
        {
            try
            {
                return GetAllComplaints(idUser)
                    .FirstOrDefault(x => x.Id == idComp);
            }
            catch (Exception ex)
            {
                string message = "Cannot get user complaint";
                throw new LogicException(message, ex);
            }
        }

        public IQueryable<TopicDTO> GetOwnTopics(int id)
        {
            try
            {
                return _unitOfWork.UserRepository.GetByIdWithDetails(id)
                    .Result.MyTopics.AsQueryable()
                    .Select(x => _mapper.Map<TopicDTO>(x));
            }
            catch (Exception ex)
            {
                string message = "Cannot get own topics";
                throw new LogicException(message, ex);
            }
        }

        public IQueryable<TopicDTO> GetSubscribedTopics(int id)
        {
            try
            {
                return _unitOfWork.UserRepository.GetByIdWithDetails(id)
                    .Result.SubscribedTopics.AsQueryable()
                    .Select(x => _mapper.Map<TopicDTO>(x));
            }
            catch (Exception ex)
            {
                string message = "Cannot get subscribed topics";
                throw new LogicException(message, ex);
            }
        }

        public void SubscribeTopic(int idUser, int idTopic)
        {
            try
            {
                _unitOfWork.TopicRepository.GetByIdWithDetails(idTopic).Result
                    .Subscribers.Add(
                    _unitOfWork.UserRepository.GetByIdWithDetails(idUser).Result);

                _unitOfWork.UserRepository.GetByIdWithDetails(idUser).Result
                    .SubscribedTopics.Add(
                    _unitOfWork.TopicRepository.GetByIdWithDetails(idTopic).Result);
            }
            catch (Exception ex)
            {
                string message = "Cannot subscribe topic";
                throw new LogicException(message, ex);
            }
        }

        public void UnsubscribeTopic(int idUser, int idTopic)
        {
            try
            {
                _unitOfWork.TopicRepository.GetByIdWithDetails(idTopic).Result
                    .Subscribers.Remove(
                    _unitOfWork.UserRepository.GetByIdWithDetails(idUser).Result);

                _unitOfWork.UserRepository.GetByIdWithDetails(idUser).Result
                    .SubscribedTopics.Remove(
                    _unitOfWork.TopicRepository.GetByIdWithDetails(idTopic).Result);
            }
            catch (Exception ex)
            {
                string message = "Cannot unsubscribe topic";
                throw new LogicException(message, ex);
            }
        }
    }
}
