using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  Handcraft_Route.domain.dtos.Requests;
using FluentValidation;

namespace Handcraft_Route.infrastructure.Validators
{
    public class ArtesanoCOOPCreateRequestValidator : AbstractValidator<ArtesanoCOOPCREATERequest>
    {
        public ArtesanoCOOPCreateRequestValidator()
        {
            //Aqui declaramos las validaciones que llevara nuestro create, las pondremos segun nuestros datos en la base de datos.

            RuleFor(a => a.NombreComercio).NotNull().NotEmpty();
            RuleFor(a => a.Telefono).NotNull().NotEmpty().MaximumLength(10).MinimumLength(10).Matches("####-###-###").WithMessage("El formato que intenta ingresar no es el correcto, favor de escribir uno como en el ejemplo asignado '####-###-###'");
            RuleFor(a => a.Descripcion).NotNull().NotEmpty().Length(10, 400);
            RuleFor(a => a.Platillo1).NotNull().NotEmpty().Length(5, 100).Matches(".jpg").WithMessage("Falta la terminacion '.jpg' al archivo, favor de agregarsela");
            RuleFor(a => a.Platillo2).NotNull().NotEmpty().Length(5, 100).Matches(".jpg").WithMessage("Falta la terminacion '.jpg' al archivo, favor de agregarsela");
            RuleFor(a => a.Platillo3).NotNull().NotEmpty().Length(5, 100).Matches(".jpg").WithMessage("Falta la terminacion '.jpg' al archivo, favor de agregarsela");
            RuleFor(a => a.Ubicacion).NotNull().NotEmpty().Length(10, 100);
            RuleFor(a => a.GeoUbicacion).NotNull().NotEmpty().Length(10, 100);
        }
    }
}