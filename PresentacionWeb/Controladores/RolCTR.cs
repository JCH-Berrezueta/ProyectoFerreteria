using CapaEntidades;
using CapaDatos;
using Microsoft.AspNetCore.Mvc;
using PresentacionWeb.Datos;

namespace PresentacionWeb.Controladores
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolCTR : ControllerBase
    {
        private readonly FerreteriaPaBacpacContext context;

        public RolCTR(FerreteriaPaBacpacContext _dbcontxt)
        {
            context = _dbcontxt;
        }

        [HttpGet]
        [Route("Listar")]
        public IActionResult Listar()
        {
            List<CapaEntidades.Gestion.Rol> listRol = new List<CapaEntidades.Gestion.Rol>();
            try
            {
                listRol = context.Rols.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "rol", respuesta = listRol });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, respuesta = listRol });
            }
        }

        [HttpGet]
        [Route("Obtener")]
        public IActionResult Obtener(int idRol)
        {
            CapaEntidades.Gestion.Rol oRol = context.Rols.Find(idRol);
            if (oRol == null)
            {
                return BadRequest("Rol no encontrado");
            }
            try
            {
                oRol = context.Rols.Where(p => p.IdRol == idRol).FirstOrDefault();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "rol", respuesta = oRol });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, respuesta = oRol });
            }
        }

        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] CapaEntidades.Gestion.Rol objeto)
        {
            try
            {
                context.Rols.Add(objeto);
                context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "rol" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }


        [HttpPost]
        [Route("Editar")]
        public IActionResult Editar([FromBody] CapaEntidades.Gestion.Rol objeto)
        {
            CapaEntidades.Gestion.Rol oRol = context.Rols.Find(objeto.IdRol);
            if (oRol == null)
            {
                return BadRequest("Rol no encontrado");
            }
            try
            {
                oRol.Nombre = objeto.Nombre is null ? oRol.Nombre : objeto.Nombre;
                oRol.Cuenta = objeto.Cuenta is null ? oRol.Cuenta : objeto.Cuenta;


                context.Rols.Add(objeto);
                context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "rol" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }


        [HttpDelete]
        [Route("Eliminar")]
        public IActionResult Eliminar(int idRol)
        {
            CapaEntidades.Gestion.Rol oRol = context.Rols.Find(idRol);
            if (oRol == null)
            {
                return BadRequest("Rol no encontrado");
            }
            try
            {

                context.Rols.Remove(oRol);
                context.SaveChanges();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "rol" });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }



    }
}
