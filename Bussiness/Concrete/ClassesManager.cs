using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using Bussiness.Constant;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ClassesManager:IClassesService
    {
        private IClassesDao _classesDao;

        public ClassesManager(IClassesDao classesDao)
        {
            _classesDao = classesDao;
        }
        public IDataResult<ClassDto> GetById(int ClassId)
        {
            return new SuccessDataResult<ClassDto>(_classesDao.Get(p => p.ClassId == ClassId));
        }

        public IDataResult<List<ClassDto>> getList()
        {
            return new SuccessDataResult<List<ClassDto>>(_classesDao.GetList().ToList());
        }

        public IResult Add(ClassDto classDto)
        {
            _classesDao.Add(classDto);
            return new SuccessResult(Messages.ClassAdded);
        }

        public IResult Delete(ClassDto classDto)
        {
            _classesDao.Update(classDto);
            return new SuccessResult(Messages.ClassDeleted);
        }

        public IResult Update(ClassDto classDto)
        {
            _classesDao.Update(classDto);
            return new SuccessResult(Messages.ClassUpdated);
        }
    }
}
