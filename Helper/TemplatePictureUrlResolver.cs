using AutoMapper;
using BisWork.Core.Entities;
using BisWork.DTOs;

namespace BisWork.Helper
{
    public class TemplatePictureUrlResolver : IValueResolver<Template, TemplateToReturnDto, string>
    {
        private readonly IConfiguration _configuration;

        public TemplatePictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Template source, TemplateToReturnDto destination, string destMember, ResolutionContext context)
        {
            if(!string.IsNullOrEmpty(source.PictureUrl))
            {
                return $"{_configuration["ApiBaseUrl"]}/{source.PictureUrl}";
            }
            return string.Empty;
        }
    }
}
