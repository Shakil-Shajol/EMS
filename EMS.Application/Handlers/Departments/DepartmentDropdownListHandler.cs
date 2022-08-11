using EMS.Application.Common.BaseHandler;
using EMS.Application.Common.Models;
using EMS.Application.Interfaces;
using EMS.Application.Queries.Departments;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Handlers.Departments
{
    public class DepartmentDropdownListHandler : BaseHandler,
        IRequestHandler<DepartmentDropdownListQuery, ResponseDetail<List<DropDown>>>
    {
        public DepartmentDropdownListHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public async Task<ResponseDetail<List<DropDown>>> Handle(DepartmentDropdownListQuery request, CancellationToken cancellationToken)
        {
            var responseDetails = new ResponseDetail<List<DropDown>>();
            var result = await _unitOfWork.DepartmentRepository.GetAll();
            var dropdownList = result.Select(i => new DropDown()
            {
                Value = i.Id,
                Text = i.DepartmentName
            }).ToList();

            return responseDetails.SuccessResponse(dropdownList, "Data Found Successfully");
        }
    }
}
