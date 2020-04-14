using System;
using System.Threading.Tasks;
using CodeCaseAzerionDynamicConfigStructure.DAL;
using CodeCaseAzerionDynamicConfigStructure.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodeCaseAzerionDynamicConfigStructure.UI.Controllers
{
    public abstract class BaseController<TModel> : Controller where TModel : BaseModel
    {
        public BaseRepository<TModel> BaseRepository { get; set; }
        private readonly ILogger<BaseController<TModel>> _logger;
        public BaseController(BaseRepository<TModel> baseRepository, ILogger<BaseController<TModel>> logger)
        {
            this.BaseRepository = baseRepository;
            _logger = logger;
        }

        public virtual IActionResult Index()
        {
            var list = this.BaseRepository.GetList();
            return View(list);
        }

        public virtual IActionResult Edit(string id)
        {
            var model = this.BaseRepository.GetById(id);
            return View(model);
        }

        [HttpPost]
        public virtual IActionResult Edit(string id, [Bind("Name,IsActive,Value,Type,ApplicationName,Id")] TModel model)
        {
            _logger.LogDebug($"Editing the model...");

            if (model == null)
            {
                _logger.LogError("Model binding error");
                return BadRequest();
            }
            else
            {
                try
                {
                    this.BaseRepository.Update(id, model);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception exception)
                {
                    _logger.LogError($"Model update error {exception.InnerException}");
                    return View();
                }
            }
        }

        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,IsActive,Value,Type,ApplicationName")]TModel model)
        {
            _logger.LogDebug($"Creating a new model...");

            if (model == null)
            {
                _logger.LogError("Model binding error");
                return BadRequest();
            }

            this.BaseRepository.Create(model);
            return RedirectToAction(nameof(Index));
        }
    }
}