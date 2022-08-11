using EMS.Application.Common.BaseHandler;
using EMS.Application.Common.Models;
using EMS.Application.Interfaces;
using EMS.Application.Queries.Employees;
using EMS.Entities.Dtos;
using EMS.Entities.Entities;
using MediatR;

namespace EMS.Application.Handlers.Employees
{
    public class EmployeeListQueryHandler : BaseHandler,
        IRequestHandler<EmployeeListQuery, ResponseDetail<List<EmployeeReadDto>>>
    {
        #region Public Constructors

        public EmployeeListQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<ResponseDetail<List<EmployeeReadDto>>> Handle(EmployeeListQuery request, CancellationToken cancellationToken)
        {
            var responseDetails = new ResponseDetail<List<EmployeeReadDto>>();
            var data = await _unitOfWork.EmployeeRepository.GetAll<EmployeeReadDto>();
            return responseDetails.SuccessResponse(data.ToList(), "Data Found Successfully");
        }

        #endregion Public Methods
    }
}
