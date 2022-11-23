using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IClassesService
    {
        IDataResult<ClassDto> GetById(int ClassId);
        IDataResult<List<ClassDto>> getList();
        IResult Add(ClassDto classDto);
        IResult Delete(ClassDto classDto);
        IResult Update(ClassDto classDto);
    }
}
