using System;
using System.Collections.Generic;
using AutoMapper;
using KarmaAPI.DTOS;
using KarmaAPI.Models;
using KarmaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace KarmaAPI.Controllers
{
    [Route("api/[controller]")]
    public class TaskController: Controller
    {
        private readonly IMapper _mapper;

        private readonly TaskService _service;

        public TaskController(IMapper mapper, TaskService service) {

            _mapper = mapper;
            _service = service;
            
        }

        [HttpGet]
        public IList<TaskDTO> get() {

        var tasks = _service.getAllTasks();

        return _mapper.Map<IList<TaskDTO>>(tasks);

        }

        [HttpPost]

        public TaskDTO add(Task task) {
        
            _service.createTask(task);
            return _mapper.Map<TaskDTO>(task);
        
        }
    }
}