using EMS.Application.Common.BaseHandler;
using EMS.Application.Common.Models;
using EMS.Application.Interfaces;
using EMS.Application.Queries.Departments;
using EMS.Application.Queries.Employees;
using EMS.Entities.Entities;
using MediatR;

namespace EMS.Application.Handlers.Employees
{
    public class DepartmentListQueryHandler : BaseHandler,
        IRequestHandler<DepartmentListQuery, ResponseDetail<List<Department>>>
    {
        #region Public Constructors

        public DepartmentListQueryHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion Public Constructors

        #region Public Methods

        public async Task<ResponseDetail<List<Department>>> Handle(DepartmentListQuery request, CancellationToken cancellationToken)
        {
            var responseDetails = new ResponseDetail<List<Department>>();
            var result = await _unitOfWork.DepartmentRepository.GetAll();
            return responseDetails.SuccessResponse(result.ToList(), "Data Found Successfully");
        }

        #endregion Public Methods
    }
}
