using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  Handcraft_Route.domain.dtos.Requests;
using FluentValidation;

namespace Handcraft_Route.infrastructure.Validators
{
    public class ProductosArtCreateREQUESTValidator : AbstractValidator<ProductoArtCreateREQUEST>
    {
        public ProductosArtCreateREQUESTValidator()
        {
            //Aqui declaramos las validaciones que llevara nuestro create, las pondremos segun nuestros datos en la base de datos.

            RuleFor(a => a.NombreProducto).NotNull().NotEmpty();
            RuleFor(a => a.Descripcion).NotNull().NotEmpty();
            RuleFor(a => a.MaterialElaborado).NotNull().NotEmpty().Length(10, 100);
            RuleFor(a => a.Fotografia).NotNull().NotEmpty().Length(5, 100).Matches(".jpg").WithMessage("Falta la terminacion '.jpg' al archivo, favor de agregarsela");
        }
    }
}