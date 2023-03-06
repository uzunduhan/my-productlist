//using FluentValidation;
//using UrunSatisTeslimatSistemi.Dto.Dtos;

//namespace UrunSatisTeslimatSistemi.Service.Validations
//{
//    public class ProductDtoValidator : AbstractValidator<ProductDto>
//    {
//        public ProductDtoValidator()
//        {
//            RuleFor(x => x.Name).NotEmpty().MinimumLength(4);
//            RuleFor(x => x.Price).NotNull().GreaterThan(0);
//        }
//    }
//}
