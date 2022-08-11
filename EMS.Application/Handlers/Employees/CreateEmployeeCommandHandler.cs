using EMS.Application.Commands.Employees.CreateEmployees;
using EMS.Application.Common.BaseHandler;
using EMS.Application.Common.Models;
using EMS.Application.Interfaces;
using EMS.Entities.Entities;
using MediatR;

namespace EMS.Application.Handlers.Employees
{
    public class CreateEmployeeCommandHandler : BaseHandler,
        IRequestHandler<CreateEmployeeCommand, ResponseDetail<Employee>>
    {
        #region Public Constructors

        public CreateEmployeeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<ResponseDetail<Employee>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var responseDetails = new ResponseDetail<Employee>();
            try
            {
                var employee = new Employee()
                {
                    Id = request.Id,
                    EmployeeName = request.EmployeeName,
                    DepartmentId = request.DepartmentId,
                    JoinDate = request.JoinDate,
                    MakeBy = "Anonymous",
                    UpdatedBy = "Anonymous"
                };
                var result = await _unitOfWork.EmployeeRepository.Update(employee);
                if (result > 0)
                {
                    responseDetails.SuccessResponse(employee);
                    return responseDetails;
                }
                return responseDetails.ErrorResponse("Data Not Saved!.");
            }
            catch (Exception ex)
            {
                responseDetails.ErrorResponse(ex);
                return responseDetails;
            }
        }

        #endregion Public Methods
    }
}
