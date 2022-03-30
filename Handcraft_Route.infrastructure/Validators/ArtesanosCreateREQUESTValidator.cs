using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using  Handcraft_Route.domain.dtos.Requests;
using FluentValidation;

namespace Handcraft_Route.infrastructure.Validators
{
    public class ArtesanosCreateREQUESTValidator : AbstractValidator<ArtesanoCreateREQUEST>
    {
        public ArtesanosCreateREQUESTValidator()
        {
            //Aqui declaramos las validaciones que llevara nuestro create, las pondremos segun nuestros datos en la base de datos.

            RuleFor(a => a.NombreArtesano).NotNull().NotEmpty();
            RuleFor(a => a.MunicipioLocalidad).NotNull().NotEmpty().MaximumLength(10);
            RuleFor(a => a.TallerNegocio).NotNull().NotEmpty().Length(5, 100);
            RuleFor(a => a.LogotipoNegocio).NotNull().NotEmpty().Length(5, 100).Matches(".jpg").WithMessage("Falta la terminacion '.jpg' al archivo, favor de agregarsela");
            RuleFor(a => a.Correo).NotNull().NotEmpty().Length(5, 100).EmailAddress();
            RuleFor(a => a.RedesSociales).NotNull().NotEmpty().Length(5, 100);
            RuleFor(a => a.Ubicacion).NotNull().NotEmpty().Length(5, 100);
            RuleFor(a => a.GeoUbicacion).NotNull().NotEmpty().Length(5, 100);
        }
    }
}