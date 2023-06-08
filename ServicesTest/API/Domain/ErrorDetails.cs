using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace API.Domain;

public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string Message { get; set;}
    public ErrorDetails(int _status)
    {
        StatusCode = _status;
        Message = GetDefaultMessage(_status);
    }
    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
    private static string GetDefaultMessage(int statusCode)
    {
            string v = statusCode switch
            {
                400 => "Has realizado una petición incorrecta.",
                401 => "Usuario no autorizado.",
                404 => "El recurso que has intentado solicitar no existe.",
                405 => "Este método HTTP no está permitido en el servidor.",
                500 => "Error en el servidor. Comunícate con el administrador",
                _ => "Error no controlado en el servidor. Comunícate con el administrador"
                            };
            return v;
    }
}