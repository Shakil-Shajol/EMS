using EMS.Application.Common.BaseHandler;
using EMS.Application.Common.Models;
using EMS.Application.Interfaces;
using EMS.Application.Queries.Employees;
using EMS.Entities.Dtos;
using EMS.Entities.Entities;
using MediatR;

namespace EMS.Application.Handlers.Employees
{
    public class EmployeeDetailsQueryHandler : BaseHandler,
        IRequestHandler<EmployeeDetailsQuery, ResponseDetail<EmployeeReadDto>>
    {
        #region Public Constructors

        public EmployeeDetailsQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<ResponseDetail<EmployeeReadDto>> Handle(EmployeeDetailsQuery request, CancellationToken cancellationToken)
        {
            var responseDetails = new ResponseDetail<EmployeeReadDto>();
            var data = await _unitOfWork.EmployeeRepository.GetById<EmployeeReadDto>(request.Id);
            return responseDetails.SuccessResponse(data, "Data Found Successfully");
        }

        #endregion Public Methods
    }
}
