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
    class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MessageService(IUnitOfWork unit, IMapper mapper)
        {
            this._unitOfWork = unit;
            this._mapper = mapper;
        }
        public void AddComplaint(int idTopic, int idMess , string desc)
        {
            try
            {
                Complaint complaint = new Complaint
                {
                    Id = _unitOfWork.ComplaintRepository.GetAll().Last().Id + 1,
                    Description = desc,
                    IsChecked = false,
                    IsClosed = false,
                    TopicComplaint = _unitOfWork.TopicRepository.GetByIdWithDetails(
                        idTopic).Result,
                    MessageComplaint = _unitOfWork.MessageRepository.GetByIdWithDetails(
                        idMess).Result
                };
                _unitOfWork.ComplaintRepository.AddAsync(complaint);
                _unitOfWork.MessageRepository.GetByIdAsync(idMess)
                    .Result.Complaints
                    .Add(complaint);
                _unitOfWork.MessageRepository.Update(
                    _unitOfWork.MessageRepository.GetByIdAsync(idMess).Result);
            }
            catch (Exception ex)
            {
                string message = "Cannot add complaint to message";
                throw new LogicException(message, ex);
            }
        }

        public void AddToTopic(int idTopic, MessageDTO mess)
        {
            try
            {
                _unitOfWork.MessageRepository.AddAsync(_mapper.Map<Message>(mess));
                _unitOfWork.TopicRepository.GetByIdAsync(idTopic).Result.Messages
                    .Add(_mapper.Map<Message>(mess));
            }
            catch (Exception ex)
            {
                string message = "Cannot add message to topic";
                throw new LogicException(message, ex);
            }
        }

        public void DeleteComplaint(int idTopic, int idMess, int idComp)
        {
            try
            {
                _unitOfWork.MessageRepository.GetByIdAsync(idMess).Result.Complaints
                    .Remove(_unitOfWork.ComplaintRepository.GetByIdAsync(idComp).Result);
                _unitOfWork.ComplaintRepository.DeleteByIdAsync(idComp);
            }
            catch (Exception ex)
            {
                string message = "Cannot delete message complaint";
                throw new LogicException(message, ex);
            }
        }

        public void DeleteFromTopic(int idTopic, int idMess)
        {
            try
            {
                _unitOfWork.TopicRepository.GetByIdWithDetails(idTopic).Result.Messages
                    .Remove(_unitOfWork.MessageRepository.GetByIdWithDetails(idMess)
                    .Result);
                _unitOfWork.MessageRepository.DeleteByIdAsync(idMess);
            }
            catch (Exception ex)
            {
                string message = "Cannot delete message from topic";
                throw new LogicException(message, ex);
            }
        }

        public IQueryable<MessageDTO> GetAllByTopic(int idTopic)
        {
            try
            {
                return _unitOfWork.TopicRepository.GetByIdWithDetails(idTopic).Result
                    .Messages.AsQueryable()
                    .Select(x => _mapper.Map<MessageDTO>(x))
                    .OrderBy(x => x.PostDate);
            }
            catch (Exception ex)
            {
                string message = "Cannot get messages by topic";
                throw new LogicException(message, ex);
            }
        }

        public IQueryable<ComplaintDTO> GetAllComplaints(int idTopic, int idMess)
        {
            try
            {
                return _unitOfWork.TopicRepository.GetByIdWithDetails(idTopic).Result
                    .Messages.AsQueryable()
                    .Where(x => x.Id == idMess)
                    .Select(x => x.Complaints)
                    .Select(x => _mapper.Map<ComplaintDTO>(x));
            }
            catch (Exception ex)
            {
                string message = "Cannot message complaints";
                throw new LogicException(message, ex);
            }
        }

        public MessageDTO GetByIdByTopic(int idTopic, int idMess)
        {
            try
            {
                return _mapper.Map<MessageDTO>(
                    _unitOfWork.TopicRepository.GetByIdWithDetails(idTopic).Result
                    .Messages
                    .FirstOrDefault(x => x.Id == idMess));
            }
            catch (Exception ex)
            {
                string message = "Cannot get message by topic";
                throw new LogicException(message, ex);
            }
        }

        public ComplaintDTO GetComplaintById(int idTopic, int idMess, int idComp)
        {
            try
            {
                return GetAllComplaints(idTopic, idMess)
                    .FirstOrDefault(x => x.Id == idComp);
            }
            catch (Exception ex)
            {
                string message = "Cannot get message complaint";
                throw new LogicException(message, ex);
            }
        }

        public void Update(int idTopic, int idMess)
        {
            try
            {
                _unitOfWork.MessageRepository.Update(
                _mapper.Map<Message>(GetByIdByTopic(
                    idTopic, idMess)));
            }
            catch (Exception ex)
            {
                string message = "Cannot update message";
                throw new LogicException(message, ex);
            }
        }
    }
}
