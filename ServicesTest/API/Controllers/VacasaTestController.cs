using API.Utils;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class VacasaTestController : Controller
    {
        private readonly ILogger<VacasaTestController> _logger;
        private readonly IUtils _utils;

        public VacasaTestController(ILogger<VacasaTestController> logger, IUtils utils)
        {
            _logger = logger;
            _utils = utils;
        }
        [HttpGet("")]
        public ActionResult<string> SolvePuzzle(string q)
        {
            if(_utils.ValidateSumFormat(q)){
                return _utils.GenerateSimplePlus(q);
            }
            if(_utils.ValidateCountNumberOfWords(q)){
                return _utils.CountNumberOfWords(q);
            }
            if(_utils.ValidateListFormatCombination(q)){
                return _utils.GenerateOutputList(q);
            }
            if(_utils.Validate2D(q)){
                return _utils.VisualizeCharacters2D(q);
            }
            return _utils.GetRandomAnswer(q);
           
        }    

    
    }
}