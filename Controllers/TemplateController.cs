using AutoMapper;
using BisWork.Core.Entities;
using BisWork.Core.Repository.Contract;
using BisWork.Core.Specification;
using BisWork.DTOs;
using BisWork.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BisWork.Controllers
{
   
    public class TemplateController : BaseController
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TemplateController(IUnitOfWork unitOfWork , IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<Template>>> GetTemplates([FromQuery]TemplateSpecPrames SpecPrames)
        {
            var spec = new TemplateWithCategorySpecification(SpecPrames);
            var templates = await _unitOfWork.Repository<Template>().GetAllWithSpecAsync(spec);
            var data = _mapper.Map<IReadOnlyCollection<Template>, IReadOnlyCollection<TemplateToReturnDto>>(templates);
            var SpecCount = new TemplateWithFiltrationForCountSpecification(SpecPrames);
            var Count = await _unitOfWork.Repository<Template>().GetCountAsync(spec);
            return Ok(new Pagination<TemplateToReturnDto>(SpecPrames.PageSize , SpecPrames.PageIndex , Count , data));
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Template>> GetTemplate(int id)
        {
            var spec = new TemplateWithCategorySpecification(id);
            var template = await _unitOfWork.Repository<Template>().GetWithSpecAsync(spec);
            return Ok(_mapper.Map<Template , TemplateToReturnDto>(template));
        }


        [HttpPost]
        public async Task<ActionResult<Template>> AddTemplate(TemplateDto template) 
        {
            var mappedTemplate = _mapper.Map<TemplateDto, Template>(template);
              _unitOfWork.Repository<Template>().Add(mappedTemplate);
         
            return Ok(template);
        }

        [HttpDelete]
        public async Task<ActionResult<string>> DeleteTemplate(int id)
        {
            var template = await _unitOfWork.Repository<Template>().GetAsync(id);
             _unitOfWork.Repository<Template>().Delete(template);
            return "Deleted Successfuly";
        }


    }
}
