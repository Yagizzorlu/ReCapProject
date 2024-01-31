using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilites.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class OperationClaimManager : IOperationClaimService
    {
        IOperationClaimDal _operationClaimDal;

        public OperationClaimManager(IOperationClaimDal operationClaimDal)
        {
            _operationClaimDal = operationClaimDal;
        }

        [CacheRemoveAspect("IOperationClaimService.GetAll")]
        [ValidationAspect(typeof(OperationClaimValidator))]
        public IResult Add(OperationClaim operationClaim)
        {
            _operationClaimDal.Add(operationClaim);
            return new SuccessResult(Messages.OperationClaimAdded);
        }

        [CacheRemoveAspect("IOperationClaimService.Get")]
        public IResult Delete(OperationClaim OperationClaim)
        {
            _operationClaimDal.Delete(OperationClaim);
            return new SuccessResult(Messages.OperationClaimDeleted);
        }

        [CacheAspect]
        public IDataResult<List<OperationClaim>> GetAll()
        {
            return new SuccessDataResult<List<OperationClaim>>(_operationClaimDal.GetAll());
        }

        [CacheAspect]
        public IDataResult<OperationClaim> GetById(int id)
        {
            return new SuccessDataResult<OperationClaim>(_operationClaimDal.Get(c => c.Id == id));
        }

        [CacheRemoveAspect("IOperationClaimService.Get")]
        [ValidationAspect(typeof(OperationClaimValidator))]
        public IResult Update(OperationClaim OperationClaim)
        {
            _operationClaimDal.Update(OperationClaim);
            return new SuccessResult(Messages.OperationClaimUpdated);
        }
    }
}
