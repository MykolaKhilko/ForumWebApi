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
    class AdminService : IAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminService(IUnitOfWork unit, IMapper mapper)
        {
            this._unitOfWork = unit;
            this._mapper = mapper;
        }
        public void AcceptComplaint(int id)
        {
            try
            {
                var com = _mapper.Map<ComplaintDTO>(
                    _unitOfWork.ComplaintRepository.GetByIdAsync(id));
                com.IsChecked = true;
                com.IsClosed = true;
                if (com.UserComplaint is null)
                {
                    if (com.MessageComplaint is null)
                    {
                        com.TopicComplaint.IsDeleted = true;
                    }
                    else
                    {
                        com.MessageComplaint.IsDeleted = true;
                    }
                }
                else
                {
                    com.UserComplaint.IsBlocked = true;
                }
                _unitOfWork.ComplaintRepository.Update(_mapper
                    .Map<Complaint>(com));
            }
            catch(Exception ex)
            {
                string message = "Cannot accept complaint(admin)";
                throw new LogicException(message, ex);
            }
        }

        public void DiscardComplaint(int id)
        {
            try
            {
                _unitOfWork.ComplaintRepository.DeleteByIdAsync(id);
            }
            catch (Exception ex)
            {
                string message = "Cannot discard complaint(admin)";
                throw new LogicException(message, ex);
            }
        }

        public IQueryable<ComplaintDTO> GetAllComplaints()
        {
            try
            {
                return _unitOfWork.ComplaintRepository.GetAllWithDetails()
                .Select(x => _mapper.Map<ComplaintDTO>(x));
            }
            catch (Exception ex)
            {
                string message = "Cannot get all complaints(admin)";
                throw new LogicException(message, ex);
            }
        }

        public ComplaintDTO GetComplaintById(int id)
        {
            try
            {
                return _mapper.Map<ComplaintDTO>(_unitOfWork.
                ComplaintRepository.GetByIdWithDetails(id));
            }
            catch (Exception ex)
            {
                string message = "Cannot get complaint by id(admin)";
                throw new LogicException(message, ex);
            }
        }
    }
}
