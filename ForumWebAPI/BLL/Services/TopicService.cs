using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL.Services
{
    class TopicService : ITopicService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TopicService(IUnitOfWork unit, IMapper mapper)
        {
            this._unitOfWork = unit;
            this._mapper = mapper;
        }
        public void Add(TopicDTO topic)
        {
            try
            {
                _unitOfWork.TopicRepository.AddAsync(
                    _mapper.Map<Topic>(topic));
            }
            catch (Exception ex)
            {
                string message = "Cannot add topic";
                throw new LogicException(message, ex);
            }
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
                    TopicComplaint = _unitOfWork.TopicRepository.GetByIdWithDetails(id)
                        .Result
                };
                _unitOfWork.ComplaintRepository.AddAsync(complaint);
                _unitOfWork.TopicRepository.GetByIdAsync(id)
                    .Result.Complaints
                    .Add(complaint);
                _unitOfWork.TopicRepository.Update(
                    _unitOfWork.TopicRepository.GetByIdAsync(id).Result);
            }
            catch (Exception ex)
            {
                string message = "Cannot add topic complaint";
                throw new LogicException(message, ex);
            }
        }

        public void Delete(int id)
        {
            try
            {
                _unitOfWork.TopicRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                string message = "Cannot delete topic";
                throw new LogicException(message, ex);
            }
        }

        public void DeleteComplaint(int idTopic, int idComp)
        {
            try
            {
                _unitOfWork.TopicRepository.GetByIdAsync(idTopic).Result.Complaints
                    .Remove(_unitOfWork.ComplaintRepository.GetByIdAsync(idComp).Result);
                _unitOfWork.ComplaintRepository.DeleteByIdAsync(idComp);
            }
            catch (Exception ex)
            {
                string message = "Cannot delete topic complaint";
                throw new LogicException(message, ex);
            }
        }

        public IQueryable<TopicDTO> GetAll()
        {
            try
            {
                return _unitOfWork.TopicRepository.GetAllWithDetails()
                    .Select(x => _mapper.Map<TopicDTO>(x));
            }
            catch (Exception ex)
            {
                string message = "Cannot get topics";
                throw new LogicException(message, ex);
            }
        }

        public IQueryable<ComplaintDTO> GetAllComplaints(int idTopic)
        {
            try
            {
                return _mapper.Map<TopicDTO>(
                    _unitOfWork.TopicRepository
                    .GetByIdWithDetails(idTopic))
                    .Complaints.AsQueryable();
            }
            catch (Exception ex)
            {
                string message = "Cannot get topic complaints";
                throw new LogicException(message, ex);
            }
        }

        public TopicDTO GetById(int id)
        {
            try
            {
                return _mapper.Map<TopicDTO>(
                    _unitOfWork.TopicRepository
                    .GetByIdWithDetails(id));
            }
            catch (Exception ex)
            {
                string message = "Cannot get topic";
                throw new LogicException(message, ex);
            }
        }

        public ComplaintDTO GetComplaintById(int idTopic, int idComp)
        {
            try
            {
                return GetAllComplaints(idTopic).FirstOrDefault(x => x.Id == idComp);
            }
            catch (Exception ex)
            {
                string message = "Cannot get topic complaint";
                throw new LogicException(message, ex);
            }
        }

        public void Update(TopicDTO topic)
        {
            try
            {
                _unitOfWork.TopicRepository.Update(
                    _mapper.Map<Topic>(topic));
            }
            catch (Exception ex)
            {
                string message = "Cannot update topic";
                throw new LogicException(message, ex);
            }
        }
    }
}
