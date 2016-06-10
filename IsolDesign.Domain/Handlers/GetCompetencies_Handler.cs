using IsolDesign.DataAccess;
using IsolDesign.DataAccess.DBContext;
using IsolDesign.DataAccess.Interfaces.IUnitOfWork;
using IsolDesign.Domain.Interfaces;
using IsolDesign.Domain.Models;
using System.Collections.Generic;
using IsolDesign.Domain.Helpers;
using System;

namespace IsolDesign.Domain.Handlers
{
    public class GetCompetencies_Handler : IGetCompetencies_Handler
    {
        private ApplicationDbContext _context;
        private IUnitOfWork _unitOfWork;

        public GetCompetencies_Handler()
        {
            this._context = new ApplicationDbContext();
            this._unitOfWork = new UnitOfWork(_context);
        }

        public IEnumerable<CompetencyModel> GetCompetencies()
        {
            var competencies = _unitOfWork.Competencies.GetAll();
            _unitOfWork.Dispose();

            var competencyModels = CompetencyConverter.ConvertToCompetencyModels2(competencies);

            return competencyModels;
        }

        public CompetencyModel GetCompetency(int? competencyId)
        {
            var id = Convert.ToInt32(competencyId);
            var competency = _unitOfWork.Competencies.Get(id);

            var competencyModel = CompetencyConverter.ConvertToCompetencyModel(competency);
            return competencyModel;
        }
    }
}

