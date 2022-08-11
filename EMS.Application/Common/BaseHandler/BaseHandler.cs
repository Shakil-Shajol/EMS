using EMS.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMS.Application.Common.BaseHandler
{
    public abstract class BaseHandler
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected BaseHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
    }
}
