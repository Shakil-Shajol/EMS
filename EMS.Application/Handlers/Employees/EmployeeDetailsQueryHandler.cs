using EMS.Application.Common.BaseHandler;
using EMS.Application.Common.Models;
using EMS.Application.Interfaces;
using EMS.Application.Queries.Employees;
using EMS.Entities.Entities;
using MediatR;

namespace EMS.Application.Handlers.Employees
{
    public class EmployeeDetailsQueryHandler : BaseHandler,
        IRequestHandler<EmployeeDetailsQuery, ResponseDetail<Employee>>
    {
        #region Public Constructors

        public EmployeeDetailsQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<ResponseDetail<Employee>> Handle(EmployeeDetailsQuery request, CancellationToken cancellationToken)
        {
            var responseDetails = new ResponseDetail<Employee>();
            var data = await _unitOfWork.EmployeeRepository.GetById(request.Id);
            return responseDetails.SuccessResponse(data, "Data Found Successfully");
        }

        #endregion Public Methods
    }
}
